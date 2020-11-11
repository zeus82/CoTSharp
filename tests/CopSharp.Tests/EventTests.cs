using CotSharp;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Xunit;

namespace CopSharp.Tests
{
    public class EventTests
    {
        [Fact]
        public void CanDeserialize()
        {
            const string xml = @"<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>
  <event version=""2.0"" uid=""S-1-5-21-42813538-1400557536-1095981526-1001"" type=""a-f-G-U-C-I"" time=""2020-11-07T15:56:55.13Z"" start=""2020-11-07T15:56:55.13Z"" stale=""2020-11-07T16:03:10.13Z"" how=""h-g-i-g-o"">
  <point lat=""0"" lon=""0"" hae=""0"" ce=""9999999"" le=""9999999""/>
  <detail>
    <takv version=""4.1.0.231"" platform=""WinTAK-CIV"" os=""Microsoft Windows 10 Pro"" device=""Dell Inc. Latitude 5401""/>
    <contact callsign=""JEEV"" endpoint=""*:thumbsdown:stcp"" xmppUsername=""""/>
    <uid Droid=""JEEV""/>
    <__group name=""Cyan"" role=""Team Member""/>
    <status battery=""100""/>
    <track course=""0.00000000"" speed=""0.00000000""/>
  </detail>
</event>";

            using (var ms = new MemoryStream())
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                ms.Write(Encoding.UTF8.GetBytes(xml));
                ms.Seek(0, SeekOrigin.Begin);

                var serializer = new XmlSerializer(typeof(Event));
                var result = (Event)serializer.Deserialize(ms);
            }
        }

        [Fact]
        public void CanSerialize()
        {
            var test = new Event
            {
                Point = new Point
                {
                    Lat = 12,
                    Lon = 32
                },
                Detail = new Detail
                {
                    Any = new object[]
                    {
                        new Contact
                        {
                            Callsign = "jeev"
                        }
                    }
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
