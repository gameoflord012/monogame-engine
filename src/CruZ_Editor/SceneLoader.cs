using CruZ.Serialization;
using CurZ;
using Newtonsoft.Json;

namespace CruZ.Editor
{
    public static class SceneLoader
    {
        public static GameScene? GetSceneFromFile(string scenePath)
        {
            using(var fileReader = new StreamReader(scenePath))
            {
                var json = fileReader.ReadToEnd();
                return JsonConvert.DeserializeObject<GameScene>(json, _settings);
            }    
        }

        public static bool LoadScene(GameScene scene)
        {
            if (_currentScene != null) return false;
            _currentScene = scene;

            foreach(var e in scene.Entities)
            {
                e.IsActive = true;
            }

            return true;
        }

        public static void UnloadCurrentScene()
        {
            if (_currentScene == null) return;

            foreach (var e in _currentScene.Entities)
            {
                e.IsActive = false;
            }

            _currentScene = null;
        }
      
        static SceneLoader()
        {
            _settings = new();
            _settings.Converters.Add(new SerializableJsonConverter());
            _settings.Formatting = Newtonsoft.Json.Formatting.Indented;
        }

        static JsonSerializerSettings _settings;
        static GameScene? _currentScene;
    }
}