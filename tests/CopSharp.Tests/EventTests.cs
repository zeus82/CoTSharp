using CotSharp;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Xunit;

namespace CopSharp.Tests
{
    public class EventTests
    {
        [Fact]
        public void CanSerialize()
        {
            var test = new Event
            {
                Point = new Point
                {
                    Lat = 12,
                    Lon = 32
                }
            };

            using (var ms = new MemoryStream())
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");



                var serializer = new XmlSerializer(typeof(Event));
                serializer.Serialize(ms, test, ns);
                var text = Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}
