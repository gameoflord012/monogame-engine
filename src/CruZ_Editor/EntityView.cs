using CruZ.Components;
using CurZ.Editor;
using ImGuiNET;
using Newtonsoft.Json;
using System.Numerics;

namespace CruZ.Editor
{
    public class EntityView : IViewDrawCallback
    {
        public void DrawView()
        {
            #region RIP
            //ImGui.Begin("##rect-view");
            //var drawList = ImGui.GetWindowDrawList();

            //var rectCoord = _binding.GetRectCoord();

            //var pMin = CruZ.CoordinateToPoint(rectCoord.TopLeft);
            //var pMax = CruZ.CoordinateToPoint(rectCoord.BottomRight);

            //var center = CruZ.CoordinateToPoint(rectCoord.Center);
            //var col = ImGui.ColorConvertFloat4ToU32(new Vector4(1, 0, 0, 1));

            //drawList.AddRect(new(pMin.X, pMin.Y), new(pMax.X, pMax.Y), col);
            //drawList.AddCircle(new(center.X, center.Y), 3, col);

            //drawList.AddText(
            //    new(center.X, center.Y), 
            //    col, 
            //    string.Format("({0}, {1})", 
            //        rectCoord.Center.X, rectCoord.Center.Y));

            //ImGui.End();
            #endregion


        }
        [JsonIgnore]
        private TransformEntity _binding;
        [JsonIgnore]
        public TransformEntity Binding { get => _binding; set => _binding = value; }
    }
}