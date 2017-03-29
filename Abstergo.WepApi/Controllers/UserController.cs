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
        //private IUserService _service;

        //public UserController(IUserService service) {
        //    _service = service;
        //}

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //[HttpGet]
        //public async Task<IEnumerable<ArgsUser>> GetUsers()
        //   => await _service.GetUsersAsync();
        

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// This method returns the found documents from Elasticsearch
        /// </summary>
        /// <param name="value">center Longitude </param>
        /// <param name="id">center Latitude </param>
        /// <returns>All the documents which were found</returns>
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value,[FromQuery]int id)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
