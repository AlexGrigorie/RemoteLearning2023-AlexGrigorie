using System.Text;
using System.Xml;
using System.Xml.Serialization;
using VendingMachine.Business.Interfaces;

namespace VendingMachine.Business.Serialization
{
    internal class ReportXmlSerialization : IFileSerialization
    {
        private readonly string reportPath;
        private readonly string reportType;
        private const string identationType = "\t";

        public ReportXmlSerialization(string reportPath, string reportType)
        {
            this.reportPath = reportPath;
            this.reportType = reportType;
        }

        public void Serilizer(object obj, string reportName)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = identationType,
            };
            string fullPath = Path.Combine(reportPath, reportName + reportType);
            using (StreamWriter streamWriter = new StreamWriter(fullPath, false, Encoding.UTF8))
            using (XmlWriter xmlWriter = XmlWriter.Create(streamWriter, settings))
            {
                serializer.Serialize(xmlWriter, obj);
            }
        }
    }
}
