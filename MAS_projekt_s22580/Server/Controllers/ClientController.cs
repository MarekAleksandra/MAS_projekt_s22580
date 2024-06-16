using MAS_projekt_s22580.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace MAS_projekt_s22580.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Retrieves all clients.
        /// </summary>
        /// <returns>A list of all clients.</returns>
        [HttpGet("allClients")]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clientService.GetAllClients();
            return Ok(clients);
        }

        /// <summary>
        /// Retrieves all orders for a specific client.
        /// </summary>
        /// <param name="id">The ID of the client whose orders are to be retrieved.</param>
        /// <returns>A list of orders for the specified client.</returns>
        [HttpGet("orders/{id}")]
        public async Task<IActionResult> GetClientsOrders(int id) {

            if (!await _clientService.DoesClientExists(id)) return NotFound();
            return Ok(await _clientService.GetClientsOrders(id));
        }

        /// <summary>
        /// Retrieves a simplified list of clients for display purposes.
        /// </summary>
        /// <returns>A simplified list of clients.</returns>
        [HttpGet]
        public async Task<IActionResult> GetClientsForList()
        {
            var clients = await _clientService.GetClientsForList();
            return Ok(clients);
        }

        /// <summary>
        /// Retrieves detailed information for a specific client.
        /// </summary>
        /// <param name="id">The ID of the client to retrieve.</param>
        /// <returns>Detailed information of the specified client.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            if (!await _clientService.DoesClientExists(id)) return NotFound();
            return Ok(await _clientService.GetClientById(id));
        }

      

}
}
