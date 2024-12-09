using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication2.ActionClaas.Account;
using WebApplication2.ActionClaas.HelperClass.DTO;
using WebApplication2.Interfes;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClient _Iclient;
        public ClientController( IClient iclient) => _Iclient = iclient;

        [HttpGet("clients")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<AccountDTO> Get() =>  _Iclient.GetClient();

        [HttpDelete("user/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<string>>> Delete(long id) => await Task.FromResult(_Iclient.DeleteUser(id));

        [HttpGet("clients/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> Get(long id) => await Task.FromResult(_Iclient.GetClient(id));

        [HttpPost("user/addAccount")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)] 
        public async Task<ActionResult<List<string>>> Post(AccountCreate userData) => await Task.FromResult(_Iclient.AddAccount(userData));
    }
}
