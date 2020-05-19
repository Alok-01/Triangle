using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Triangle.AzureFunction
{
    public static class InsertIntoCosmo
    {
        //[FunctionName("InsertIntoCosmo")]
        //public static HttpResponseMessage Run(
        //    [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequestMessage req,
        //    [CosmosDB(
        //                databaseName: "ManualIssuanceData",
        //                collectionName: "ToDoList", //BankNote
        //                ConnectionStringSetting = "ConnectionStringSetting")] out ToDoItem document, ILogger log)
        //{
        //    log.LogInformation("InsertIntoCosmo Function called");
        //    var content = req.Content;
        //    string jsonContent = content.ReadAsStringAsync().Result;
        //    document = JsonConvert.DeserializeObject<ToDoItem>(jsonContent);

        //    return new HttpResponseMessage(HttpStatusCode.Created);

        //}

        //[FunctionName("GetCosmo")]
        //public static async Task<IActionResult> Run(
        //    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequestMessage req,
        //    [CosmosDB(
        //                databaseName: "ManualIssuanceData",
        //                collectionName: "BankNote",
        //                ConnectionStringSetting = "ConnectionStringSetting",
        //                SqlQuery ="Select * from Items"                      )
        //    ] IEnumerable<ToDoItem> documents
        //    , ILogger log)
        //{
        //    log.LogInformation("Get Cosomos called");
        //    var data = documents;


        //    return new OkObjectResult(data);

        //}

        [FunctionName("GetItemById")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetItem/{id}")] HttpRequestMessage req,
            [CosmosDB(
                databaseName: "ManualIssuanceData",
                collectionName: "ToDoList",
                ConnectionStringSetting = "ConnectionStringSetting",
                Id = "{id}")
            ]ToDoItem toDoItem,
            ILogger log)
        {
            log.LogInformation($"Function triggered");
            var data = toDoItem;
            if (toDoItem == null)
            {
                log.LogInformation($"Item not found");
                return new NotFoundObjectResult("Id not found in collection");
            }
            else
            {
                log.LogInformation($"Found ToDo item {toDoItem.Description}");
                return new OkObjectResult(toDoItem);
            }

        }

        //[FunctionName("GetCosmoById")]
        //public static async Task<IActionResult> Run(
        //    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetItem/{id}")] HttpRequestMessage req,
        //    [CosmosDB(
        //                databaseName: "ManualIssuanceData",
        //                collectionName: "BankNote",
        //                ConnectionStringSetting = "ConnectionStringSetting",
        //                Id = "{id}" //SqlQuery ="Select * from Items"                      
        //    )
        //    ] ToDoItem documents
        //    , ILogger log)
        //{
        //    log.LogInformation("Get GetCosmoById called");
        //    var data = documents;


        //    return new OkObjectResult(data);

        //}
    }
}
