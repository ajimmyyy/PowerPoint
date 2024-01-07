using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class ShapeConverterTests
    {
        //測試判斷型態
        [TestMethod()]
        public void CanConvertTest()
        {
            ShapeConverter converter = new ShapeConverter();
            bool result = converter.CanConvert(typeof(Shape));

            Assert.IsTrue(result);
        }

        //測試讀取JSON
        [TestMethod()]
        public void ReadJsonTest()
        {
            ShapeConverter converter = new ShapeConverter();
            JObject shapeJson = JObject.Parse("{ \"ShapeName\": \"圓形\", \"Info\": \"((1, 2), (3, 4))\" }");

            using (StringReader stringReader = new StringReader(shapeJson.ToString()))
            using (JsonTextReader jsonReader = new JsonTextReader(stringReader))
            {
                object result = converter.ReadJson(jsonReader, typeof(Shape), null, new JsonSerializer());

                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(Shape));
            }
        }

        //測試寫入JSON
        [TestMethod()]
        public void WriteJsonTest()
        {
            ShapeConverter converter = new ShapeConverter();
            Shape shape = new Circle(1, 2, 3, 4);
            StringWriter stringWriter = new StringWriter();
            using (JsonWriter jsonWriter = new JsonTextWriter(stringWriter))
            {
                converter.WriteJson(jsonWriter, shape, new JsonSerializer());
            }
            string resultJson = stringWriter.ToString();
            JObject resultObject = JObject.Parse(resultJson);

            Assert.AreEqual("圓形", resultObject.GetValue(nameof(Shape.ShapeName)));
            Assert.AreEqual("((1, 2), (3, 4))", resultObject.GetValue(nameof(Shape.Info)));

        }
    }
}