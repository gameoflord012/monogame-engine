using Box2D.NetStandard.Common;
using CruZ.Components;
using CruZ.Serialization;
using CurZ;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using Newtonsoft.Json;
namespace CruZ.Demos
{
    [DemoName("SceneSerizationDemo")]
    public class SceneSerizationDemo : CruZ_App
    {
        public SceneSerizationDemo()
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
                    var te1 = Core.World.CreateTransformEntity();
                    te1.AddComponent(new SpriteComponent("image"));
                    te1.AddComponent(new String("halloboys"));
                    te1.Transform.Position = new Microsoft.Xna.Framework.Vector3(10, 10, 0);

                    var te2 = Core.World.CreateTransformEntity();
                    te2.Transform.Position = new Microsoft.Xna.Framework.Vector3(-100, -100, 0);
                    te2.AddComponent(new SpriteComponent("homelander"));
                    te2.Transform.Scale = new Microsoft.Xna.Framework.Vector3(5f, 5f, 1);

                    _scene.AddEntity(te1);
                    _scene.AddEntity(te2);

                    json = JsonConvert.SerializeObject(_scene, _settings);

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
                _scene = JsonConvert.DeserializeObject<GameScene>(json, _settings);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //_te.Transform.Position += Vector3.UnitX;
        }

        protected override void OnExit(object sender, EventArgs args)
        {
            using (var writer = new StreamWriter("transform.json", false))
            {
                var json = JsonConvert.SerializeObject(_scene, _settings);
                writer.Write(json);
            }
        }

        JsonSerializerSettings _settings;
        GameScene _scene = new();
    }
}