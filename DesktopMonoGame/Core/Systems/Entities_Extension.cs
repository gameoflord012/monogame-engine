using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using System.Collections;
using System.Collections.Generic;

namespace CruZ.Components
{
    static class Entities_Extension
    {
        public static IEnumerable<T> GetAllComponents<T>(this EntitySystem system, ComponentMapper<T> mapper) where T : class
        {
            foreach(var e in system.ActiveEntities)
            {
                yield return mapper.Get(e);
            }

            yield break;
        }
    }
}