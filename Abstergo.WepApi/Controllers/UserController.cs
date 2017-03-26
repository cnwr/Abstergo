using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abstergo.Core.Service;
using Abstergo.Entities.Args;

namespace Abstergo.WepApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            this._service = service;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Gokhan", "Gorlen" };
        }

        [HttpGet("{id}")]
        public async Task<string> Get([FromQuery]int id)
            => await _service.GetUsersAsync();


        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<ArgsUser>> GetUsers()
            => await _service.GetUsersAsync();

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
