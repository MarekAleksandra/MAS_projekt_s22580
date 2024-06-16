using MAS_projekt_s22580.Context;
using MAS_projekt_s22580.Models;
using MAS_projekt_s22580.Models.Clients;
using Microsoft.EntityFrameworkCore;
using MAS_projekt_s22580.Shared.DTOs;

namespace MAS_projekt_s22580.Server.Services
{
    public interface IClientService
     {
        /// <summary>
        /// Retrieves all clients from the database.
        /// </summary>
        /// <returns>A collection of BasicClient objects.</returns>
        Task<IEnumerable<BasicClient>> GetAllClients();
        
        /// <summary>
        /// Retrieves a client by their ID.
        /// </summary>
        /// <param name="id">The ID of the client to retrieve.</param>
        /// <returns>A BasicClient object.</returns>
        Task<BasicClient> GetClientById(int id);

        /// <summary>
        /// Retrieves a list of clients with basic information.
        /// </summary>
        /// <returns>A collection of ClientForList objects.</returns>
        Task<IEnumerable<ClientForList>> GetClientsForList();

        /// <summary>
        /// Retrieves the orders for a specific client.
        /// </summary>
        /// <param name="id">The ID of the client whose orders are to be retrieved.</param>
        /// <returns>A collection of Order objects.</returns>
        Task<IEnumerable<Order>> GetClientsOrders(int id);

        /// <summary>
        /// Checks if a client exists by their ID.
        /// </summary>
        /// <param name="id">The ID of the client to check.</param>
        /// <returns>A boolean value indicating whether the client exists.</returns>
        Task<bool> DoesClientExists(int id);
    }
    public class ClientService : IClientService
    {

        private readonly DatabaseContext _databaseContext;

        public ClientService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <inheritdoc />
        public async Task<bool> DoesClientExists(int id)
        {
            return _databaseContext.Clients.Any(e => e.Id == id);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<BasicClient>> GetAllClients()
        {
            return await _databaseContext.Clients.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<BasicClient> GetClientById(int id)
        {
            return await _databaseContext.Clients.FirstOrDefaultAsync(o => o.Id == id);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ClientForList>> GetClientsForList()
        {
            return await _databaseContext.Clients
                .Select(c => new ClientForList
                {
                    Id = c.Id,
                    FirstName = c.Person.FirstName,
                    LastName = c.Person.LastName
                })
                .ToListAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Order>> GetClientsOrders(int id)
        {
           return await _databaseContext.Orders
                .Where(c => c.ClientID == id)
                .ToListAsync();
        }
    }
}
