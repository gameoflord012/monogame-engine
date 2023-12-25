using CruZ.UI;
using CurZ.Editor;
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
            _logView = new LoggingView();

            _views.Add(_sceneView);
            _views.Add(_logView);

            for(int i = 0; i < _views.Count; i++)
            {
                var loadedView = GlobalSerializer.DeserializeFromFile(
                    GetSerializePath(_views[i]), _views[i].GetType());

                if (loadedView == null) continue;
                _views[i] = loadedView;
            }

            Core.OnDraw += Draw;
        }

        private void Draw(GameTime gameTime)
        {
            _imgui.BeforeLayout(gameTime);

            foreach (var view in _views)
            {
                if (view is IViewDrawCallback)
                    ((IViewDrawCallback)view).DrawView();
            }

            _imgui.AfterLayout();
        }

        protected override void OnExit(object sender, EventArgs args)
        {
            for (int i = 0; i < _views.Count; i++)
            {
                GlobalSerializer.SerializeToFile(_views[i], GetSerializePath(_views[i]));
            }
        }

        private string GetSerializePath(object o)
        {
            return string.Format("Editor\\{0}.json", o.GetType().ToString());
        }

        private ImGuiRenderer _imgui;
        private SceneSelectionView _sceneView;
        private LoggingView _logView;

        private List<object> _views = new();
    }
}