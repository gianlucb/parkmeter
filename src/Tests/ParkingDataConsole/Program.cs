﻿using Microsoft.Azure.CosmosDB.BulkExecutor;
using Microsoft.Azure.CosmosDB.BulkExecutor.BulkImport;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using Parkmeter.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Parkmeter.ParkingDataConsole
{
    public class Program
    {
        private const string EndpointUrl = "https://localhost:8081";
        private const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private DocumentClient client;

        public static void Main(string[] args)
        {

            try
            {
                Program p = new Program();
                p.LoadTestData().Wait();
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Console.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
            }
            finally
            {
                Console.WriteLine("End of demo, press any key to exit.");
                Console.ReadKey();
            }
        }

        private async Task LoadTestData()
        {
            ConnectionPolicy connectionPolicy = new ConnectionPolicy
            {
                ConnectionMode = ConnectionMode.Direct,
                ConnectionProtocol = Protocol.Tcp
            };
            client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey, connectionPolicy);



            string dbName = "ParkingLedger";
            string collectionName = "VehicleAccesses";
            var partitionKeys = new System.Collections.ObjectModel.Collection<string>();
            partitionKeys.Add("/Access/ParkingID");
            await this.client.CreateDatabaseIfNotExistsAsync(new Database { Id = dbName });
            var collection = await this.client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(dbName), 
                new DocumentCollection { Id = collectionName, PartitionKey = new PartitionKeyDefinition() { Paths = partitionKeys } });

            // manual update
            //var list = CreateAccessesList();
            //Parallel.ForEach(list, (x) =>
            //{
            //    RegisterVehicleAccess(dbName, collectionName, x);
            //});


            // Set retry options high during initialization (default values).
            client.ConnectionPolicy.RetryOptions.MaxRetryWaitTimeInSeconds = 30;
            client.ConnectionPolicy.RetryOptions.MaxRetryAttemptsOnThrottledRequests = 9;

            IBulkExecutor bulkExecutor = new BulkExecutor(client, collection);
            await bulkExecutor.InitializeAsync();

            // Set retries to 0 to pass complete control to bulk executor.
            client.ConnectionPolicy.RetryOptions.MaxRetryWaitTimeInSeconds = 0;
            client.ConnectionPolicy.RetryOptions.MaxRetryAttemptsOnThrottledRequests = 0;

            var list = CreateAccessesList();
            var listOfStrings = list.Select(item => JsonConvert.SerializeObject(item)).ToList();
            var documents = JsonConvert.SerializeObject(list);

            BulkImportResponse bulkImportResponse = await bulkExecutor.BulkImportAsync(
              documents: listOfStrings,
              enableUpsert: true,
              disableAutomaticIdGeneration: true,
              maxConcurrencyPerPartitionKeyRange: null,
              maxInMemorySortingBatchSize: null);

            Console.WriteLine("Bulk import completed:");
            Console.WriteLine($"\tImported: { bulkImportResponse.NumberOfDocumentsImported}");
            Console.WriteLine($"\tErrors: { bulkImportResponse.BadInputDocuments.Count}");
            Console.WriteLine($"\tRequestUnits: { bulkImportResponse.TotalRequestUnitsConsumed}");
            Console.WriteLine($"\tTime taken: { bulkImportResponse.TotalTimeTaken}");

        }

        private List<VehicleAccessDocument> CreateAccessesList()
        {
            List<VehicleAccessDocument> list = new List<VehicleAccessDocument>();

            for (int month = 1; month <= 12; month++)
            {
                for (int day = 1; day <= 28; day++)
                {
                    Random parkingHours = new Random(DateTime.Now.TimeOfDay.Seconds);
                    Random numOfVehicles = new Random(DateTime.Now.TimeOfDay.Seconds);
                    Random parkId = new Random(DateTime.Now.TimeOfDay.Seconds);

                    DateTime parkingDay = new DateTime(2018, month, day,0,0,0);

                    // less parking on weekends
                    int numberOfVehicles = numOfVehicles.Next(30, 50) + numOfVehicles.Next(34, 70);
                    if (parkingDay.DayOfWeek == DayOfWeek.Sunday || parkingDay.DayOfWeek == DayOfWeek.Saturday)
                        numberOfVehicles = numOfVehicles.Next(5, 15);

                    for (; numberOfVehicles > 0; numberOfVehicles--)
                    {
                        var inDate = parkingDay.AddHours(parkingHours.Next(6, 10));
                        string vehicleId = $"BD{day}{day}AS{numberOfVehicles}";
                        int pID = parkId.Next(1, 4);
                        VehicleAccess @in = new VehicleAccess
                        {
                            Direction = AccessDirections.In,
                            ParkingID = pID,
                            SpaceID = day,
                            VehicleID = vehicleId,
                            TimeStamp = inDate,
                            VehicleType = VehicleTypes.Car
                        };
                        VehicleAccess @out = new VehicleAccess
                        {
                            Direction = AccessDirections.Out,
                            ParkingID = pID,
                            SpaceID = day,
                            VehicleID = vehicleId,
                            TimeStamp = inDate.AddHours(parkingHours.Next(1,8)), //max 8 hours of parking
                            VehicleType = VehicleTypes.Car
                        };
                        list.Add(new VehicleAccessDocument() { Access = @in, id = Guid.NewGuid().ToString() });
                        list.Add(new VehicleAccessDocument() { Access = @out, id = Guid.NewGuid().ToString() });
                    }


                }
            }

            Console.WriteLine($"Created a list with {list.Count} vehicle accesses");

            return list;
        }

        // for manual import
        private async Task RegisterVehicleAccess(string databaseName, string collectionName, VehicleAccess access)
        {
            try
            {
                var doc = await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), access);
                Console.WriteLine($"Added new access: {doc.Resource.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to register a new vechicle access: " + ex.Message);
            }
        }


    }
}
