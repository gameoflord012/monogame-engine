using CruZ.Components;
using CruZ.Serialization;
using MonoGame.Extended.Entities;
using Newtonsoft.Json;
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
            te.AddComponent(new SpriteComponent());
            te.AddComponent(new String("halloboys"));

            //te.AddComponent(new AnimatedSpriteComponent(null));

            string json = JsonConvert.SerializeObject(
                te,
                Newtonsoft.Json.Formatting.Indented,
                new TransformEntityJsonConverter());

            Console.Write(json);
        }
    }
}