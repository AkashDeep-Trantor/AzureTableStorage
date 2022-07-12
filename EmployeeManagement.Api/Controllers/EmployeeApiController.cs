using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Services.Contracts;
using EmployeeManagement.Services.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeManagement.Api.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        // Azure Storage Information

        string StorageName = "contenthierarchydev";
        string StorageKey = "AOJbEUCCs5RD/aW9URijH+M0IP6YU7H6ezuNV7SjeVwLQd6VvVgCi4sU5PVIzrsAoRFipas3hxIVn5+vaiYV8w==";
        string TableName = "SampleAzureTableStorage";

        // Dependency Injection
        private readonly IEmployeeServices _employeeServices;
        public EmployeeApiController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        // GET: api/EmployeeApi
        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            string jsonData;
            _employeeServices.GetAllEmployees(StorageName, StorageKey, TableName, out jsonData);
            List<Employee> employee = JsonConvert.DeserializeObject<List<Employee>>(jsonData);
            return employee;
        }

        // GET: api/EmployeeApi/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EmployeeApi
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/EmployeeApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
