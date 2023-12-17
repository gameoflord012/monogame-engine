using MonoGame.Extended.Entities;
using CruZ.Components;

namespace Test
{
    [TestClass]
    public class ComponentTest
    {
        World _w;

        public ComponentTest()
        {
            _w = new WorldBuilder().Build();
        }
        [TestMethod]
        public void CreateTransformEntity()
        {
            TransformEntity e = _w.CreateTransformEntity();
        }
    }
}