using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruZ
{
    internal partial class CruZ
    {
        private static CruZ _instance;
        public static CruZ Instance()
        {
            if (_instance == null)
                _instance = new CruZ();
            return _instance;
        }
    }
}
