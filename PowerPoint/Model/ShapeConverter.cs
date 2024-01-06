using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PowerPoint
{
    public class ShapeConverter : JsonConverter
    {
        const string SHAPE_TYPE = "ShapeName";
        const string SHAPE_INFO = "Info";

        //可轉化
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Shape));
        }

        //讀取Json
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject shape = JObject.Load(reader);

            string shapeName = shape[SHAPE_TYPE].ToString();
            string info = shape[SHAPE_INFO].ToString();

            return Factory.CreateShape(shapeName, info);
        }

        //轉為Json
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Shape shape = (Shape)value;

            JObject file = new JObject(
                new JProperty(nameof(Shape.ShapeName), shape.ShapeName),
                new JProperty(nameof(Shape.Info), shape.Info)
            );

            file.WriteTo(writer);
        }
    }
}
