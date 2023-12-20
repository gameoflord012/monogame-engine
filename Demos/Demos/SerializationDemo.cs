using CruZ.Components;
using CruZ.Serialization;
using MonoGame.Extended.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CruZ.Demos
{
    [DemoName("SerializeDemo")]
    public class SerializationDemo : CruZ_App
    {
        public class Example
        {
            public Example(int a) { }

            private int a = 1;
            public List<int> b = new() { 1, 2, 3, 4, 5, 6 };
            int c = 2;

            SpriteComponent p = new SpriteComponent();

            public int A { get => a; set => a = value; }
        }
        public SerializationDemo()
        {
            Core.Run();
            
        }

        public override void Initialize()
        {
            base.Initialize();

            var te = Core.World.CreateTransformEntity();
            var sp = new SpriteComponent("image");
            var ex = new Example(1);

            te.AddComponent(new SpriteComponent("image"));
            te.AddComponent(new String("halloboys"));

            //te.AddComponent(new AnimatedSpriteComponent(null));

            string json = JsonConvert.SerializeObject(
                te,
                Newtonsoft.Json.Formatting.Indented,
                new SerializableJsonConverter(),
                new TransformEntityJsonConverter());


            Console.Write(json);
            //json = JsonConvert.SerializeObject(ex);
            //ex = JsonConvert.DeserializeObject<Example>(json);

            te = JsonConvert.DeserializeObject<TransformEntity>(json,
                new SerializableJsonConverter());

        }
    }
}