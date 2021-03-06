// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Parkmeter.SDK
{
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ParkmeterApi.
    /// </summary>
    public static partial class ParkmeterApiExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parkingId'>
            /// </param>
            public static Parking GetParking(this IParkmeterApi operations, int parkingId)
            {
                return operations.GetParkingAsync(parkingId).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parkingId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Parking> GetParkingAsync(this IParkmeterApi operations, int parkingId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetParkingWithHttpMessagesAsync(parkingId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parkingId'>
            /// </param>
            public static void DeleteParking(this IParkmeterApi operations, int parkingId)
            {
                operations.DeleteParkingAsync(parkingId).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parkingId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteParkingAsync(this IParkmeterApi operations, int parkingId, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteParkingWithHttpMessagesAsync(parkingId, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parkingName'>
            /// </param>
            public static PersistenceResult CreateParking(this IParkmeterApi operations, string parkingName = default(string))
            {
                return operations.CreateParkingAsync(parkingName).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parkingName'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<PersistenceResult> CreateParkingAsync(this IParkmeterApi operations, string parkingName = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateParkingWithHttpMessagesAsync(parkingName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<Parking> GetParkingsList(this IParkmeterApi operations)
            {
                return operations.GetParkingsListAsync().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<Parking>> GetParkingsListAsync(this IParkmeterApi operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetParkingsListWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='vehicleType'>
            /// </param>
            /// <param name='specialAttribute'>
            /// </param>
            /// <param name='parkingID'>
            /// </param>
            /// <param name='id'>
            /// </param>
            public static void CreateSpace(this IParkmeterApi operations, int? vehicleType = default(int?), int? specialAttribute = default(int?), int? parkingID = default(int?), int? id = default(int?))
            {
                operations.CreateSpaceAsync(vehicleType, specialAttribute, parkingID, id).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='vehicleType'>
            /// </param>
            /// <param name='specialAttribute'>
            /// </param>
            /// <param name='parkingID'>
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task CreateSpaceAsync(this IParkmeterApi operations, int? vehicleType = default(int?), int? specialAttribute = default(int?), int? parkingID = default(int?), int? id = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.CreateSpaceWithHttpMessagesAsync(vehicleType, specialAttribute, parkingID, id, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parkingId'>
            /// </param>
            /// <param name='number'>
            /// </param>
            public static void CreateSpaces(this IParkmeterApi operations, int parkingId, int number)
            {
                operations.CreateSpacesAsync(parkingId, number).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parkingId'>
            /// </param>
            /// <param name='number'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task CreateSpacesAsync(this IParkmeterApi operations, int parkingId, int number, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.CreateSpacesWithHttpMessagesAsync(parkingId, number, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parkingId'>
            /// </param>
            public static ParkingStatus GetParkingStatus(this IParkmeterApi operations, int parkingId)
            {
                return operations.GetParkingStatusAsync(parkingId).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parkingId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ParkingStatus> GetParkingStatusAsync(this IParkmeterApi operations, int parkingId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetParkingStatusWithHttpMessagesAsync(parkingId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parkingId'>
            /// </param>
            /// <param name='vehicleId'>
            /// </param>
            public static void RegisterVehicleIn(this IParkmeterApi operations, int parkingId, string vehicleId)
            {
                operations.RegisterVehicleInAsync(parkingId, vehicleId).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parkingId'>
            /// </param>
            /// <param name='vehicleId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task RegisterVehicleInAsync(this IParkmeterApi operations, int parkingId, string vehicleId, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.RegisterVehicleInWithHttpMessagesAsync(parkingId, vehicleId, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parkingId'>
            /// </param>
            /// <param name='vehicleId'>
            /// </param>
            public static void RegisterVehicleOut(this IParkmeterApi operations, int parkingId, string vehicleId)
            {
                operations.RegisterVehicleOutAsync(parkingId, vehicleId).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parkingId'>
            /// </param>
            /// <param name='vehicleId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task RegisterVehicleOutAsync(this IParkmeterApi operations, int parkingId, string vehicleId, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.RegisterVehicleOutWithHttpMessagesAsync(parkingId, vehicleId, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}
