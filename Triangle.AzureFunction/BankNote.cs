using Newtonsoft.Json;

namespace Triangle.AzureFunction
{
    public class ToDoItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("iscomplete")]
        public bool IsComplete { get; set; }
    }
}