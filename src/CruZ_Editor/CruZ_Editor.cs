using CruZ.UI;
using Microsoft.Xna.Framework;

namespace CruZ.Editor
{
    class CruZ_Editor : CruZ_App
    {
        public override void Initialize()
        {
            base.Initialize();
            _imgui = new(Core);
            _imgui.RebuildFontAtlas();
            _sceneView = new SceneSelectionView();

            Core.OnDraw += Draw;
        }

        private void Draw(GameTime gameTime)
        {
            _imgui.BeforeLayout(gameTime);
            _sceneView.DrawView();
            _imgui.AfterLayout();
        }

        private ImGuiRenderer _imgui;
        private SceneSelectionView _sceneView;
    }
}