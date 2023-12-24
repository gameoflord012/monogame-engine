using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruZ
{
    public partial class CruZ
    {
        private static CruZ _instance;
        public static CruZ Instance()
        {
            if (_instance == null)
                _instance = new CruZ();
            return _instance;
        }

        public static readonly int VIRTUAL_WIDTH = 1920;
        public static readonly int VIRTUAL_HEIGHT = 1080;
        public static readonly string CONTENT_ROOT = "Content";
    }
}
