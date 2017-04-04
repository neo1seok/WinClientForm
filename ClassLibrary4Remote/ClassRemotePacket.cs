using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4Remote
{
    public class ClassRemotePacket
    {
        public string cmd = "";
        public IList<Object> values = new List<Object>();
        public int delay = 100;
    }
}
