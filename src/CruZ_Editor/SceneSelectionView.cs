﻿using CurZ.Editor;
using ImGuiNET;
using Newtonsoft.Json;

namespace CruZ.Editor
{
    public class SceneSelectionView : IViewDrawCallback
    {
        public void DrawView()
        {
            ImGui.SetNextWindowSize(new System.Numerics.Vector2(400, 300), ImGuiCond.FirstUseEver);
            ImGui.Begin("Scene Selection");

            float sceneListWidth = ImGui.GetContentRegionAvail().X;

            ImGui.Text("Scenes:");
            ImGui.SameLine();
            AddSceneButton(sceneListWidth);

            ImGui.PushItemWidth(sceneListWidth);
            if (ImGui.BeginListBox("", new System.Numerics.Vector2(sceneListWidth, ImGui.GetContentRegionAvail().Y)))
            {
                foreach (var file in _sceneFiles)
                {
                    var relative = Path.GetFileName(file);
                    if (ImGui.Selectable(relative))
                    {
                        LoadScene(file);
                    }
                }
                ImGui.EndListBox();
            }
            ImGui.PopItemWidth();

            ImGui.End();

            void AddSceneButton(float total_X)
            {
                string text = "Add Scene";
                ImGui.SameLine(total_X - ImGui.CalcTextSize(text).X);
                if (ImGui.Button(text))
                {
                    var files = Dialog.SelectSceneFiles();
                    foreach (var file in files)
                    {
                        AddSceneFile(file);
                    }
                }
            }
        }

        private void AddSceneFile(string file)
        {
            if (!_sceneFiles.Contains(file)) _sceneFiles.Add(file);
            _sceneFiles.Sort();
        }

        private void LoadScene(string scenePath)
        {
            var scene = SceneManager.GetSceneFromFile(scenePath);
            if (scene == null) return;

            SceneManager.LoadScene(scene);
        }

        [JsonProperty]
        private List<string> _sceneFiles = new();
    }
}