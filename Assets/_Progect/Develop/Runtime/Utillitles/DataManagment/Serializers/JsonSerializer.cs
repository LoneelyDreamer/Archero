using Newtonsoft.Json;

namespace Assets._Progect.Develop.Runtime.Utillitles.DataManagment.Serializers
{
    public class JsonSerializer : IDataSerializer
    {
        public TData Deserialize<TData>(string SerializedData)
        {
            return JsonConvert.DeserializeObject<TData>(SerializedData, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
            });
        }

        public string Serialize<TData>(TData data)
        {
            return JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto,
            });
        }
    }
}
