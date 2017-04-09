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
        public IList<IList<object>> values = new List<IList<object>>();
        public int delay = 0;
        public void add_value(params object[] args)
        {

            values.Add(new List<object>(args));
        }
    }
}
