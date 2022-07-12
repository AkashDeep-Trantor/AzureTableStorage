using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Contracts
{
    public interface IEmployeeServices
    {
        int GetAllEmployees(string StorageName, string StorageKey, string TableName, out string jsonData);
        Task<Employee> GetEmployeeById(string department, string id);
        Employee UpsertEmployee(Employee employee);
        void DeleteEmployee(string department,  string id);
    }
}
