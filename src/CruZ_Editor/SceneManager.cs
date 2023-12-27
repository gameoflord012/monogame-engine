﻿using CruZ.Serialization;
using CurZ;
using Newtonsoft.Json;

namespace CruZ.Editor
{
    public static class SceneManager
    {
        public static GameScene? GetSceneFromFile(string scenePath)
        {
            using(var fileReader = new StreamReader(scenePath))
            {
                var json = fileReader.ReadToEnd();
                GameScene? scene = JsonConvert.DeserializeObject<GameScene>(json, _settings);

                if (scene == null) return null;

                scene.Name = Path.GetFileName(scenePath);
                return scene;
            }
        }

        public static void LoadScene(GameScene scene)
        {
            if (_currentScene != null)
            {
                UnloadCurrentScene();
            }

            _currentScene = scene;

            foreach(var e in scene.Entities)
            {
                e.IsActive = true;
            }

            OnSceneLoaded?.Invoke(_currentScene);
            Logging.PushMsg(String.Format("Scene {0} Loaded", scene.Name));
        }

        public static void UnloadCurrentScene()
        {
            if (_currentScene == null) return;

            foreach (var e in _currentScene.Entities)
            {
                e.RemoveFromWorld();
            }

            var unloadScene = _currentScene;
            _currentScene = null;

            OnCurrentSceneUnLoaded?.Invoke(unloadScene);
            Logging.PushMsg(String.Format("Scene {0} Unloaded", unloadScene.Name));
        }

        static SceneManager()
        {
            _settings = new();
            _settings.Converters.Add(new SerializableJsonConverter());
            _settings.Formatting = Newtonsoft.Json.Formatting.Indented;
        }

        static JsonSerializerSettings _settings;
        static GameScene? _currentScene;

        public static event Action<GameScene>? OnSceneLoaded;
        public static event Action<GameScene>? OnCurrentSceneUnLoaded;
    }
}