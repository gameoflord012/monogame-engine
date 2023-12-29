using CruZ_Engine.UI;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Num = System.Numerics;


namespace CruZ_Engine.Demos
{
    [DemoName("ImguiIntegrationDemo")]
    internal class ImguiIntegrationDemo : CruZ_App
    {
        public ImguiIntegrationDemo()
        {
            Core.Run();
        }
        public override void Initialize()
        {
            base.Initialize();

            _imgui = new(Core);
            _imgui.RebuildFontAtlas();

            Core.OnDraw += Draw;
        }

        float a = 0;

        private void Draw(GameTime gameTime)
        {
            _imgui.BeforeLayout(gameTime);

            // Draw our UI
            {
                ImGui.Begin("test",
                    ImGuiWindowFlags.NoTitleBar);

                var io = ImGui.GetIO();

                ImGui.Text(io.MousePos.ToString());
                ImGui.Text(a.ToString());

                ImGui.PushItemWidth(50);
                ImGui.SliderFloat("Slider", ref a, 0.0f, 1.0f);
                ImGui.PopItemWidth();

                ImGui.End();
            }

            // Call AfterLayout now to finish up and draw all the things
            _imgui.AfterLayout();
        }

        ImGuiRenderer _imgui;

        private float f = 0.0f;

        private bool show_test_window = false;
        private bool show_another_window = false;
        private Num.Vector3 clear_color = new Num.Vector3(114f / 255f, 144f / 255f, 154f / 255f);
        private byte[] _textBuffer = new byte[100];



        unsafe float[] _cameraView = new float[16]
           { 1.0f, 0.0f, 0.0f, 0.0f,
             0.0f, 1.0f, 0.0f, 0.0f,
             0.0f, 0.0f, 1.0f, 0.0f,
             0.0f, 0.0f, 0.0f, 1.0f };

        unsafe float[] _projection = new float[16]
           { 1.0f, 0.0f, 0.0f, 0.0f,
             0.0f, 1.0f, 0.0f, 0.0f,
             0.0f, 0.0f, 1.0f, 0.0f,
             0.0f, 0.0f, 0.0f, 1.0f };
        
        unsafe float[] _identity = new float[16]
           { 1.0f, 0.0f, 0.0f, 0.0f,
             0.0f, 1.0f, 0.0f, 0.0f,
             0.0f, 0.0f, 1.0f, 0.0f,
             0.0f, 0.0f, 0.0f, 1.0f };
    }
}
