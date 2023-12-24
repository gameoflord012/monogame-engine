using Box2D.NetStandard.Common;
using CruZ.Components;
using CruZ.Serialization;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using Newtonsoft.Json;
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
            var json = "";
            _settings = new();
            _settings.Converters.Add(new SerializableJsonConverter());
            _settings.Formatting = Newtonsoft.Json.Formatting.Indented;

            if (!File.Exists("transform.json"))
            {
                File.Create("transform.json").Close();
            }

            bool loaded = false;
            using (var reader = new StreamReader("transform.json"))
            {
                var s = reader.ReadToEnd();

                if (String.IsNullOrEmpty(s))
                {
                    _te = Core.World.CreateTransformEntity();
                    _te.AddComponent(new SpriteComponent("image"));
                    _te.AddComponent(new String("halloboys"));
                    _te.AddComponent(new Example(1));

                    json = JsonConvert.SerializeObject(_te, _settings);

                    Console.WriteLine("Created new Entity");
                    Console.WriteLine(json);
                }
                else
                {
                    json = s;
                    Console.WriteLine("Json loaded");
                    Console.WriteLine(json);
                    loaded = true;
                }
            }

            if (loaded)
            {
                _te = JsonConvert.DeserializeObject<TransformEntity>(json, _settings);
            }
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _te.Transform.Position += Vector3.UnitX;
        }

        protected override void OnExit(object sender, EventArgs args)
        {
            using (var writer = new StreamWriter("transform.json", false))
            {
                var json = JsonConvert.SerializeObject(_te, _settings);
                writer.Write(json);
            }
        }

        TransformEntity _te;
        JsonSerializerSettings _settings;
    }
}