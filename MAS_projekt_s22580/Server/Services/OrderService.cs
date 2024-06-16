namespace MAS_projekt_s22580.Services
{
    using global::MAS_projekt_s22580.Context;
    using global::MAS_projekt_s22580.Models;
    using global::MAS_projekt_s22580.Shared.DTOs;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace MAS_projekt_s22580.Services
    {
        public interface IOrderService
        {
            /// <summary>
            /// Retrieves all orders from the database.
            /// </summary>
            /// <returns>A collection of Order objects.</returns>
            Task<IEnumerable<Order>> GetAllOrders();

            /// <summary>
            /// Retrieves orders for a specific client.
            /// </summary>
            /// <param name="clientId">The ID of the client whose orders are to be retrieved.</param>
            /// <returns>A collection of OrderForList objects.</returns>
            Task<IEnumerable<OrderForList>> GetOrdersForClient(int clientId);

        /// <summary>
        /// Retrieves orders for a specific client by client ID.
        /// </summary>
        /// <param name="Id">The ID of the client.</param>
        /// <returns>A collection of OrderForList objects.</returns>
            Task<Order> GetOrderById(int id);

            /// <summary>
            /// Retrieves detailed information for an order by its ID.
            /// </summary>
            /// <param name="id">The ID of the order to retrieve details for.</param>
            /// <returns>An OrderDetails object.</returns>
            Task<OrderDetails> GetOrderDetailsById(int id);

            /// <summary>
            /// Updates the status of an order.
            /// </summary>
            /// <param name="id">The ID of the order to update.</param>
            /// <param name="newStatus">The new status to set for the order.</param>
            Task UpdateOrderStatus(int id, Status newStatus);

            /// <summary>
            /// Retrieves all orders with basic information.
            /// </summary>
            /// <returns>A collection of OrderForList objects.</returns>
            Task<IEnumerable<OrderForList>> GetAllOrdersForList();

            /// <summary>
            /// Checks if a client exists by their ID.
            /// </summary>
            /// <param name="id">The ID of the client to check.</param>
            /// <returns>A boolean value indicating whether the client exists.</returns>
            Task<bool> DoesClientExists(int id);

            /// <summary>
            /// Checks if a order exists by its ID.
            /// </summary>
            /// <param name="id">The ID of the order to check.</param>
            /// <returns>A boolean value indicating whether the order exists.</returns>
            Task<bool> DoesOrderExists(int id);

        }
        public class OrderService : IOrderService
        {
            private readonly DatabaseContext _databaseContext;

            public OrderService(DatabaseContext databaseContext)
            {
                _databaseContext = databaseContext;
            }

            /// <inheritdoc />
            public async Task<bool> DoesClientExists(int id)
            {
                return _databaseContext.Clients.Any(e => e.Id == id);
            }

            /// <inheritdoc />
            public async Task<bool> DoesOrderExists(int id)
            {
                return _databaseContext.Orders.Any(e => e.Id == id);
            }

            /// <inheritdoc />
            public async Task<IEnumerable<Order>> GetAllOrders()
            {
                return await _databaseContext.Orders
                    .OrderBy(o=> o.OrderNumber)
                    .ToListAsync();
            }

            /// <inheritdoc />
            public async Task<Order> GetOrderById(int id)
            {
                return await _databaseContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
            }

            /// <inheritdoc />
            public async Task<OrderDetails> GetOrderDetailsById(int id)
            {
                var order = await _databaseContext.Orders
                    .Include(o => o.Client)
                    .ThenInclude(c => c.Person)
                    .FirstOrDefaultAsync(o => o.Id == id);

                if (order == null)
                {
                    throw new Exception("Order not found"); 
                }

                return new OrderDetails
                {
                    Id = order.Id,
                    OrderNumber = order.OrderNumber,
                    ClientFirstName = order.Client?.Person?.FirstName ?? "",
                    ClientLastName = order.Client?.Person?.LastName ?? "",
                    ClientID = order.ClientID,
                    Status = order.Status
                };
            }

            /// <inheritdoc />
            public async Task<IEnumerable<OrderForList>> GetOrdersForClient(int clientId)
            {
                return await _databaseContext.Orders
                                .Where(o => o.ClientID == clientId)
                                .Select(o => new OrderForList
                                {
                                    Id = o.Id,
                                    OrderNumber = o.OrderNumber,
                                    Status = o.Status
                                })
                                .ToListAsync();
            }

            /// <inheritdoc />
            public async Task<IEnumerable<OrderForList>> GetAllOrdersForList()
            {
                return await _databaseContext.Orders
                                .Select(o => new OrderForList
                                {
                                    Id = o.Id,
                                    OrderNumber = o.OrderNumber,
                                    Status = o.Status
                                })
                                .ToListAsync();
            }

            /// <inheritdoc />
            public async Task UpdateOrderStatus(int id, Status newStatus)
            {
                var order = await GetOrderById(id);
                if (order.Status != Status.Received && newStatus != order.Status) { 
                order.Status = newStatus;
                _databaseContext.Orders.Update(order);
                await _databaseContext.SaveChangesAsync();
                }
            }
        }
    }

}
