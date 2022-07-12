using EmployeeManagement.Models;
using EmployeeManagement.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Implementation
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EmployeeServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }        

        public int GetAllEmployees(string StorageName, string StorageKey, string TableName, out string jsonData)
        {
            List<Employee> employees = new List<Employee>();
            string uri = @"https://" + StorageName + ".table.core.windows.net/" + TableName;
            var clientRequest = _httpClientFactory.CreateClient(uri);            
            //HttpWebRequest clientRequest = (HttpWebRequest)HttpWebRequest.Create(uri);

            int query = TableName.IndexOf("?");
            if(query > 0)
            {
                TableName = TableName.Substring(0, query);
            }

            clientRequest = getRequestHeaders("GET", clientRequest, StorageName, StorageKey, TableName);
           /*
            try
            {
                var response = clientRequest.GetAsync("api/EmployeeApi");
                if(response.IsCompletedSuccessfully)
                {
                   //var result = response.Content.ReadAsStringAsync();
                    
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return 0;*/
            
            try
            {
                using (var response = clientRequest.GetStringAsync(uri))
                //using (HttpWebResponse response = (HttpWebResponse)clientRequest.GetResponse())
                {
                    using (StreamReader r = new StreamReader(response.Result))
                    {
                        jsonData = r.ReadToEnd();
                        return (int)response.Status;
                    }
                }
            }
            catch(WebException e)
            {
                using (StreamReader sr = new StreamReader(e.Response.GetResponseStream()))
                {
                    jsonData = sr.ReadToEnd();
                }
                return (int)e.Status;
            }
        }        

        public Task<Employee> GetEmployeeById(string department, string id)
        {
            throw new NotImplementedException();
        }

        public Employee UpsertEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
        public void DeleteEmployee(string department, string id)
        {
            throw new NotImplementedException();
        }

        public HttpClient getRequestHeaders(string requestType, HttpClient newClient, string storageAccount, string accessKey, string resourcePath, int Length = 0)
        {
            HttpClient clientRequest = newClient;
            var requestDate = DateTime.UtcNow.ToString("R", CultureInfo.InvariantCulture);

            //clientRequest.DefaultRequestHeaders.Accept.Clear();
            //if (clientRequest.DefaultRequestHeaders.Contains("x-ms-date"))
            //    clientRequest.DefaultRequestHeaders.Remove("x-ms-date");
            //clientRequest.DefaultRequestHeaders.Add("x-ms-date", requestDate);

            //if (clientRequest.DefaultRequestHeaders.Contains("x-ms-date"))
            //    clientRequest.DefaultRequestHeaders.Remove("x-ms-date");
            //clientRequest.DefaultRequestHeaders.Add("x-ms-date", requestDate);

            //if (clientRequest.DefaultRequestHeaders.Contains("x-ms-date"))
            //    clientRequest.DefaultRequestHeaders.Remove("x-ms-date");
            //clientRequest.DefaultRequestHeaders.Add("x-ms-date", requestDate);

            //if (clientRequest.DefaultRequestHeaders.Contains("x-ms-date"))
            //    clientRequest.DefaultRequestHeaders.Remove("x-ms-date");
            //clientRequest.DefaultRequestHeaders.Add("x-ms-date", requestDate);

            //if (clientRequest.DefaultRequestHeaders.Contains("x-ms-date"))
            //    clientRequest.DefaultRequestHeaders.Remove("x-ms-date");
            //clientRequest.DefaultRequestHeaders.Add("x-ms-date", requestDate);

            //if (clientRequest.DefaultRequestHeaders.Contains("x-ms-date"))
            //    clientRequest.DefaultRequestHeaders.Remove("x-ms-date");
            //clientRequest.DefaultRequestHeaders.Add("x-ms-date", requestDate);
            

            switch (requestType.ToUpper())
            {
                case "GET":
                    //clientRequest.DefaultRequestHeaders.Add("Method","GET");
                    //clientRequest.DefaultRequestHeaders.Add("ContentType","application/json");
                    //clientRequest.DefaultRequestHeaders.Add("ContentLength", "Length");
                    //clientRequest.DefaultRequestHeaders.Add("Accept","application/json;odata=metadata");
                    ///*clientRequest.DefaultRequestHeaders.Accept.Add(
                    //    new MediaTypeWithQualityHeaderValue(
                    //        "application/json;"));
                    //    // ("application/json;odata=nometadata"));*/
                    //clientRequest.DefaultRequestHeaders.Add("x-ms-date", requestDate);
                    //clientRequest.DefaultRequestHeaders.Add("x-ms-version", "2015-12-11");
                    //clientRequest.DefaultRequestHeaders.Add("Accept-Charset", "UTF-8");
                    //clientRequest.DefaultRequestHeaders.Add("MaxDataServiceVersion", "3.0;NetFx");
                    //clientRequest.DefaultRequestHeaders.Add("DataServiceVersion", "1.0;NetFx");
                    if (clientRequest.DefaultRequestHeaders.Contains("Method"))
                        clientRequest.DefaultRequestHeaders.Remove("Method");
                    clientRequest.DefaultRequestHeaders.Add("Method", "GET");

                    if (clientRequest.DefaultRequestHeaders.Contains("ContentType"))
                        clientRequest.DefaultRequestHeaders.Remove("ContentType");
                    clientRequest.DefaultRequestHeaders.Add("ContentType", "application/json");

                    if (clientRequest.DefaultRequestHeaders.Contains("ContentLength"))
                        clientRequest.DefaultRequestHeaders.Remove("ContentLength");
                    clientRequest.DefaultRequestHeaders.Add("ContentLength", "Length");

                    if (clientRequest.DefaultRequestHeaders.Contains("Accept"))
                        clientRequest.DefaultRequestHeaders.Remove("Accept");
                    clientRequest.DefaultRequestHeaders.Add("Accept", "application/json;odata=metadata");
                    
                    //if (clientRequest.DefaultRequestHeaders.Contains("Authorization"))
                    //    clientRequest.DefaultRequestHeaders.Remove("Authorization");

                    //var canonicalizedStringToBuild = string.Format("{0}\n{1}", requestDate, $"/{storageAccount}/{.AbsolutePath.TrimStart('/')}");
                    //string signature;
                    //using (var hmac = new HMACSHA256(Convert.FromBase64String(accessKey)))
                    //{
                    //    byte[] dataToHmac = Encoding.UTF8.GetBytes(canonicalizedStringToBuild);
                    //    signature = Convert.ToBase64String(hmac.ComputeHash(dataToHmac));
                    //}

                    //string authorizationHeader = string.Format($"{storageAccount}:" + signature);
                    //clientRequest.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SharedKeyLite", authorizationHeader);

                    clientRequest.DefaultRequestHeaders.Accept.Clear();
                    clientRequest.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    if (clientRequest.DefaultRequestHeaders.Contains("x-ms-version"))
                        clientRequest.DefaultRequestHeaders.Remove("x-ms-version");
                    clientRequest.DefaultRequestHeaders.Add("x-ms-version", "2015-12-11");

                    if (clientRequest.DefaultRequestHeaders.Contains("DataServiceVersion"))
                        clientRequest.DefaultRequestHeaders.Remove("DataServiceVersion");
                    clientRequest.DefaultRequestHeaders.Add("DataServiceVersion", "3.0;NetFx");

                    if (clientRequest.DefaultRequestHeaders.Contains("MaxDataServiceVersion"))
                        clientRequest.DefaultRequestHeaders.Remove("MaxDataServiceVersion");
                    clientRequest.DefaultRequestHeaders.Add("MaxDataServiceVersion", "3.0;NetFx");
                    break;
            }

            
            string sAuthorization = getAuthToken(clientRequest, storageAccount, accessKey, resourcePath);
            clientRequest.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", sAuthorization);
            return clientRequest;
        }

        public string getAuthToken(HttpClient client, string storageAccount, string accessKey, string resourcePath)
        {
            try
            {
                string sAuthToken = "";                
                var stringToSign = DateTime.UtcNow.ToString("R", CultureInfo.InvariantCulture) + "\n";

                stringToSign += "/" + storageAccount + "/" + resourcePath;

                HMACSHA256 hasher = new HMACSHA256(Convert.FromBase64String(accessKey));
                sAuthToken = "SharedKeyLite" + storageAccount + ":" + 
                    Convert.ToBase64String(hasher.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
                return sAuthToken;
            }
            catch(Exception e)
            {
                throw e;
            }            
        }

        // Worked in Home:

//        public HttpClient getRequestHeaders(string requestType, HttpClient newClient, string storageAccount, string accessKey, string resourcePath, int Length = 0)
//        {
//            HttpClient clientRequest = newClient;
//            var requestDate = DateTime.UtcNow.ToString("R", CultureInfo.InvariantCulture);
//            var requestUri = new Uri("SampleAzureTableStorage(PartitionKey='Department',RowKey='EmployeeId ')");

//            /*if (clientRequest.DefaultRequestHeaders.Contains("x-ms-date"))
//                clientRequest.DefaultRequestHeaders.Remove("x-ms-date");
//            clientRequest.DefaultRequestHeaders.Add("x-ms-date", requestDate);

//            if (clientRequest.DefaultRequestHeaders.Contains("Authorization"))
//                clientRequest.DefaultRequestHeaders.Remove("Authorization");

//            var canonicalizedStringToBuild = string.Format("{0}\n{1}", requestDate, $"/{storageAccount}/{requestUri.AbsolutePath.TrimStart('/')}");
//            string signature;
//            using (var hmac = new HMACSHA256(Convert.FromBase64String(accessKey)))
//            {
//                byte[] dataToHmac = Encoding.UTF8.GetBytes(canonicalizedStringToBuild);
//                signature = Convert.ToBase64String(hmac.ComputeHash(dataToHmac));
//            }

//            string authorizationHeader = string.Format($"{storageAccount}:" + signature);
//            clientRequest.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SharedKeyLite", authorizationHeader);

//            clientRequest.DefaultRequestHeaders.Accept.Clear();
//            clientRequest.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//            if (clientRequest.DefaultRequestHeaders.Contains("x-ms-version"))
//                clientRequest.DefaultRequestHeaders.Remove("x-ms-version");

//            clientRequest.DefaultRequestHeaders.Add("x-ms-version", "2015-12-11");

//            if (clientRequest.DefaultRequestHeaders.Contains("DataServiceVersion"))
//                clientRequest.DefaultRequestHeaders.Remove("DataServiceVersion");
//            clientRequest.DefaultRequestHeaders.Add("DataServiceVersion", "3.0;NetFx");

//            if (clientRequest.DefaultRequestHeaders.Contains("MaxDataServiceVersion"))
//                clientRequest.DefaultRequestHeaders.Remove("MaxDataServiceVersion");
//            clientRequest.DefaultRequestHeaders.Add("MaxDataServiceVersion", "3.0;NetFx");

//            /*if (httpMethod == HttpMethod.Delete || httpMethod == HttpMethod.Put)
//            {
//                if (clientRequest.DefaultRequestHeaders.Contains("If-Match"))
//                    clientRequest.DefaultRequestHeaders.Remove("If-Match");
//                // Currently I'm not using optimistic concurrency :-(
//                clientRequest.DefaultRequestHeaders.Add("If-Match", "*");
//            }*/

//            switch (requestType.ToUpper())
//            {
//                case "GET":
//                    /*clientRequest.DefaultRequestHeaders.Add("Method","GET");
//                    clientRequest.DefaultRequestHeaders.Add("ContentType","application/json");
//                    clientRequest.DefaultRequestHeaders.Add("ContentLength", "Length");
//                    clientRequest.DefaultRequestHeaders.Accept.Add(
//                        new MediaTypeWithQualityHeaderValue("application/json"));
//                    clientRequest.DefaultRequestHeaders.Add("x-ms-date", requestDate);
//                    //clientRequest.DefaultRequestHeaders.Add(
//                    //    "x-ms-date", DateTime.UtcNow.ToString("R", 
//                    //    System.Globalization.CultureInfo.InvariantCulture));
//                    clientRequest.DefaultRequestHeaders.Add("x-ms-version", "2015-12-11");
//                    clientRequest.DefaultRequestHeaders.Add("Accept-Charset", "UTF-8");
//                    clientRequest.DefaultRequestHeaders.Add("MaxDataServiceVersion", "3.0;NetFx");
//                    clientRequest.DefaultRequestHeaders.Add("DataServiceVersion", "1.0;NetFx");*/

//                    if (clientRequest.DefaultRequestHeaders.Contains("x-ms-date"))
//                        clientRequest.DefaultRequestHeaders.Remove("x-ms-date");
//                    clientRequest.DefaultRequestHeaders.Add("x-ms-date", requestDate);

//                    if (clientRequest.DefaultRequestHeaders.Contains("Authorization"))
//                        clientRequest.DefaultRequestHeaders.Remove("Authorization");

//                    var canonicalizedStringToBuild = string.Format("{0}\n{1}", requestDate, $"/{storageAccount}/{requestUri.AbsolutePath.TrimStart('/')}");
//                    string signature;
//                    using (var hmac = new HMACSHA256(Convert.FromBase64String(accessKey)))
//                    {
//                        byte[] dataToHmac = Encoding.UTF8.GetBytes(canonicalizedStringToBuild);
//                        signature = Convert.ToBase64String(hmac.ComputeHash(dataToHmac));
//                    }

//                    string authorizationHeader = string.Format($"{storageAccount}:" + signature);
//                    clientRequest.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SharedKeyLite", authorizationHeader);

//                    clientRequest.DefaultRequestHeaders.Accept.Clear();
//                    clientRequest.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//                    if (clientRequest.DefaultRequestHeaders.Contains("x-ms-version"))
//                        clientRequest.DefaultRequestHeaders.Remove("x-ms-version");

//                    clientRequest.DefaultRequestHeaders.Add("x-ms-version", "2015-12-11");

//                    if (clientRequest.DefaultRequestHeaders.Contains("DataServiceVersion"))
//                        clientRequest.DefaultRequestHeaders.Remove("DataServiceVersion");
//                    clientRequest.DefaultRequestHeaders.Add("DataServiceVersion", "3.0;NetFx");

//                    if (clientRequest.DefaultRequestHeaders.Contains("MaxDataServiceVersion"))
//                        clientRequest.DefaultRequestHeaders.Remove("MaxDataServiceVersion");
//                    clientRequest.DefaultRequestHeaders.Add("MaxDataServiceVersion", "3.0;NetFx");
//                    break;
//            }

//            string sAuthorization = getAuthToken(clientRequest, storageAccount, accessKey, resourcePath);
//            clientRequest.DefaultRequestHeaders.Add("Authorization", sAuthorization);
//            return clientRequest;
//        }

//        public string getAuthToken(HttpClient client, string storageAccount, string accessKey, string resourcePath)
//        {
//            try
//            {
//                string sAuthToken = "";
//                var stringToSign = DateTime.UtcNow.ToString("R", CultureInfo.InvariantCulture) + "\n";

//                stringToSign += "/" + storageAccount + "/" + resourcePath;

//                HMACSHA256 hasher = new HMACSHA256(Convert.FromBase64String(accessKey));
//                sAuthToken = "SharedKeyLite" + storageAccount + ":" +
//                    Convert.ToBase64String(hasher.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
//                return sAuthToken;
//            }
//            catch (Exception e)
//            {
//                throw e;
//            }
//        }
    }
}