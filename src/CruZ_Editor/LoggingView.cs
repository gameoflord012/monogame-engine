﻿using CurZ.Editor;
using ImGuiNET;

namespace CruZ.Editor
{
    class LoggingView : IViewDrawCallback
    {
        public void DrawView()
        {
            var bound = CruZ.Instance().GraphicsDevice.Viewport.Bounds;

            ImGui.SetNextWindowSize(new System.Numerics.Vector2(bound.Width, bound.Height));
            ImGui.SetNextWindowPos(new System.Numerics.Vector2(0, 0));
            ImGui.Begin("##log-window", 
                ImGuiWindowFlags.NoMove | 
                ImGuiWindowFlags.NoTitleBar | 
                ImGuiWindowFlags.NoBackground |
                ImGuiWindowFlags.NoInputs);

            foreach (var msg in Logging.GetMsgs())
            {
                ImGui.Text(msg);
            }
        }
    }
}