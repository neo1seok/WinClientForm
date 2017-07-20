using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4Remote
{
    public class ClassRemoteUDP : ClassRemote
    {
        
   

        public string InputString(string input)
        {
           var classRemotePacket = new ClassRemotePacket(){cmd = "input_string"};
            classRemotePacket.add_value(input, "");
            listRemote.Add(classRemotePacket);
            string ret = JsonConvert.SerializeObject(listRemote);

            return ret;

        }
        public byte[] InputEventBytes()
        {
            throw new NotImplementedException();
        }

        public string InputEvent()
        {

            var classRemotePacket = new ClassRemotePacket() { cmd = "set_size" };
            classRemotePacket.add_value(this.screensize.dx, this.screensize.dy);
            listRemote.Add(classRemotePacket);

            if (quemoue.ToList().Count > 0)
            {
                


                classRemotePacket = new ClassRemotePacket() { cmd = "input_event" };

                quemoue.ToList().ForEach(n => {
                    switch(n.@event)
                    {
                        case EVNET.KEYDOWN:
                        case EVNET.KEYUP:
                            classRemotePacket.add_value(n.@event.ToString().ToLower(), VK_CODE[n.vkey]);
                            break;
                         default:
                            classRemotePacket.add_value(n.@event.ToString().ToLower(), n.x, n.y);
                            break;
                    }

                    
                    
                });
                listRemote.Add(classRemotePacket);
                quemoue.Clear();



            }

        
            string ret = JsonConvert.SerializeObject(listRemote);
            listRemote.Clear();
            return ret;
        }
        
      
        public void MouseMoveAbs(int x, int y,int width,int height)
        {
            //listRemote.Add(new ClassRemotePacket()
            //{
            //    cmd = "mouse_move_abs",
            //    values = new List<object>() { x, y , width , height }

            //});
        }
    

    }
}
