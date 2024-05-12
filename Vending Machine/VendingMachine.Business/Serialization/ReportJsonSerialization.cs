using Newtonsoft.Json;
using System.Text;
using VendingMachine.Business.Interfaces;

namespace VendingMachine.Business.Serialization
{
    internal class ReportJsonSerialization : IFileSerialization
    {
        private readonly string reportPath;
        private readonly string reportType;


        public ReportJsonSerialization(string reportPath, string reportType)
        {
            this.reportPath = reportPath;
            this.reportType = reportType;
        }
        public void Serilizer(object obj, string reportName)
        {
            JsonSerializer serializer = new JsonSerializer();
            string fullPath = Path.Combine(reportPath, reportName + reportType);
            using (StreamWriter streamWriter = new StreamWriter(fullPath, false, Encoding.UTF8))
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter)
            {
                Formatting = Formatting.Indented,
                Indentation = 4
            })
            {
                serializer.Serialize(jsonWriter, obj);
            }
        }
    }
}
