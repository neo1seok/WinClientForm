using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4Remote
{
    public class ClassRemote : IRemote
    {
        protected Dictionary<int, string>      VK_CODE = new Dictionary<Int32, string>(){
                {0x08 , "backspace"},
    {0x09 , "tab"},
    {0x0C , "clear"},
    {0x0D , "enter"},
    {0x10 , "shift"},
    {0x11 , "ctrl"},
    {0x12 , "alt"},
    {0x13 , "pause"},
    {0x14 , "caps_lock"},
    {0x1B , "esc"},
    {0x20 , "spacebar"},
    {0x21 , "page_up"},
    {0x22 , "page_down"},
    {0x23 , "end"},
    {0x24 , "home"},
    {0x25 , "left_arrow"},
    {0x26 , "up_arrow"},
    {0x27 , "right_arrow"},
    {0x28 , "down_arrow"},
    {0x29 , "select"},
    {0x2A , "print"},
    {0x2B , "execute"},
    {0x2C , "print_screen"},
    {0x2D , "ins"},
    {0x2E , "del"},
    {0x2F , "help"},
    {0x30 , "0"},
    {0x31 , "1"},
    {0x32 , "2"},
    {0x33 , "3"},
    {0x34 , "4"},
    {0x35 , "5"},
    {0x36 , "6"},
    {0x37 , "7"},
    {0x38 , "8"},
    {0x39 , "9"},
    {0x41 , "a"},
    {0x42 , "b"},
    {0x43 , "c"},
    {0x44 , "d"},
    {0x45 , "e"},
    {0x46 , "f"},
    {0x47 , "g"},
    {0x48 , "h"},
    {0x49 , "i"},
    {0x4A , "j"},
    {0x4B , "k"},
    {0x4C , "l"},
    {0x4D , "m"},
    {0x4E , "n"},
    {0x4F , "o"},
    {0x50 , "p"},
    {0x51 , "q"},
    {0x52 , "r"},
    {0x53 , "s"},
    {0x54 , "t"},
    {0x55 , "u"},
    {0x56 , "v"},
    {0x57 , "w"},
    {0x58 , "x"},
    {0x59 , "y"},
    {0x5A , "z"},
    {0x60 , "numpad_0"},
    {0x61 , "numpad_1"},
    {0x62 , "numpad_2"},
    {0x63 , "numpad_3"},
    {0x64 , "numpad_4"},
    {0x65 , "numpad_5"},
    {0x66 , "numpad_6"},
    {0x67 , "numpad_7"},
    {0x68 , "numpad_8"},
    {0x69 , "numpad_9"},
    {0x6A , "multiply_key"},
    {0x6B , "add_key"},
    {0x6C , "separator_key"},
    {0x6D , "subtract_key"},
    {0x6E , "decimal_key"},
    {0x6F , "divide_key"},
    //{0x70 , "F1"},
    //{0x71 , "F2"},
    //{0x72 , "F3"},
    //{0x73 , "F4"},
    //{0x74 , "F5"},
    //{0x75 , "F6"},
    //{0x76 , "F7"},
    //{0x77 , "F8"},
    //{0x78 , "F9"},
    //{0x79 , "F10"},
    //{0x7A , "F11"},
    //{0x7B , "F12"},
    //{0x7C , "F13"},
    //{0x7D , "F14"},
    //{0x7E , "F15"},
    //{0x7F , "F16"},
    //{0x80 , "F17"},
    //{0x81 , "F18"},
    //{0x82 , "F19"},
    //{0x83 , "F20"},
    //{0x84 , "F21"},
    //{0x85 , "F22"},
    //{0x86 , "F23"},
    //{0x87 , "F24"},
    //{0x90 , "num_lock"},
    //{0x91 , "scroll_lock"},
    //{0xA0 , "left_shift"},
    //{0xA1 , "right_shift"},
    //{0xA2 , "left_control"},
    //{0xA3 , "right_control"},
    //{0xA4 , "left_menu"},
    //{0xA5 , "right_menu"},
    //{0xA6 , "browser_back"},
    //{0xA7 , "browser_forward"},
    //{0xA8 , "browser_refresh"},
    //{0xA9 , "browser_stop"},
    //{0xAA , "browser_search"},
    //{0xAB , "browser_favorites"},
    //{0xAC , "browser_start_and_home"},
    //{0xAD , "volume_mute"},
    //{0xAE , "volume_Down"},
    //{0xAF , "volume_up"},
    //{0xB0 , "next_track"},
    //{0xB1 , "previous_track"},
    //{0xB2 , "stop_media"},
    //{0xB3 , "play/pause_media"},
    //{0xB4 , "start_mail"},
    //{0xB5 , "select_media"},
    //{0xB6 , "start_application_1"},
    //{0xB7 , "start_application_2"},
    //{0xF6 , "attn_key"},
    //{0xF7 , "crsel_key"},
    //{0xF8 , "exsel_key"},
    //{0xFA , "play_key"},
    //{0xFB , "zoom_key"},
    //{0xFE , "clear_key"},
    //{0xBB , "+"},
    //{0xBC , ","},
    //{0xBD , "-"},
    //{0xBE , "."},
    //{0xBF , "/"},
    //{0xC0 , "`"},
    //{0xBA , ";"},
    //{0xDB , "["},
    //{0xDC , "\\"},
    //{0xDD , "]"},
    //{0xDE , "'"},
    //{0xC0 , "`"}

   };

        Dictionary<string, int> map_cmd = new Dictionary<string, int>()
            {

                { "start_event",0x20},
                { "end_event",0x21},
                { "move",0x10},
                { "ldown",0x11},
                { "lup",0x12},
                { "rdown",0x13},
                { "rup",0x14},
                { "keydown",0x15},
                { "keyup",0x16},
                { "input_string",0x17},
            };

        protected enum EVNET
        {
            MOVE,
            LDOWN,
            LUP,
            RDOWN,
            RUP,
            KEYDOWN,
            KEYUP,

        }
        protected struct POINT
        {
            public  EVNET @event;
            public int x;
            public int y;
            public int vkey;
            //public int delay;
         }
        protected struct SIZE
        {
            public int dx;
            public int dy;
        }
        protected IList<ClassRemotePacket> listRemote = new List<ClassRemotePacket>();

        protected Queue<POINT> quemoue = new Queue<POINT>();
        protected SIZE screensize = new SIZE();

        public string InputString(string input)
        {
           var classRemotePacket = new ClassRemotePacket(){cmd = "input_string"};
            classRemotePacket.add_value(input, "");
            listRemote.Add(classRemotePacket);
            string ret = JsonConvert.SerializeObject(listRemote);

            return ret;

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
        
        public void KeyDown(int vk_key)
        {
            quemoue.Enqueue(new POINT()
            {
                @event = EVNET.KEYDOWN,
                vkey = vk_key
                

            });
            //var classRemotePacket = new ClassRemotePacket() { cmd = "kbd_event" };
            //classRemotePacket.add_value(VK_CODE[vk_key], "down");

            //listRemote.Add(classRemotePacket);
            //listRemote.Add(new ClassRemotePacket()
            //{
            //    cmd = "kbd_event",
            //    values = new List<object>() { VK_CODE[vk_key], "down"}

            //});
        }

        public void KeyUp(int vk_key)
        {
            quemoue.Enqueue(new POINT()
            {
                @event = EVNET.KEYUP,
                vkey = vk_key


            });

            //var classRemotePacket = new ClassRemotePacket() { cmd = "kbd_event" };
            //classRemotePacket.add_value(VK_CODE[vk_key], "up");
            //listRemote.Add(classRemotePacket);
            //listRemote.Add(new ClassRemotePacket()
            //{
            //    cmd = "kbd_event",
            //    values = new List<object>() { VK_CODE[vk_key], "up" }

            //});
        }

        public void MouseLeftDown(int x, int y)
        {
            quemoue.Enqueue(new POINT()
            {
                @event = EVNET.LDOWN,
                x = x,
                y = y,
       //         delay = 0

            });

            //listRemote.Add(new ClassRemotePacket()
            //{
            //    cmd = "mouse_event",
            //    values = new List<object>() { "left", "down" }

            //});
        }

       

        public void MouseMove(int x, int y)
        {

            quemoue.Enqueue(new POINT() {
                @event = EVNET.MOVE,
                x = x,
                y = y,
        //        delay = delay
            });
            //listRemote.Add(new ClassRemotePacket()
            //{
            //    cmd = "mouse_move",
            //    values = new List<object>() {x,y }

            //});
        }
        public void SetSize(int width,int height)
        {
            screensize.dx = width;
            screensize.dy = height;

        }
        public void MouseMoveAbs(int x, int y,int width,int height)
        {
            //listRemote.Add(new ClassRemotePacket()
            //{
            //    cmd = "mouse_move_abs",
            //    values = new List<object>() { x, y , width , height }

            //});
        }
        public void MouseLeftUp(int x, int y)
        {
            quemoue.Enqueue(new POINT()
            {
                @event = EVNET.LDOWN,
                x = x,
                y = y,
              //  delay = 0

            });
            //listRemote.Add(new ClassRemotePacket()
            //{
            //    cmd = "mouse_event",
            //    values = new List<object>() { "left", "up" }

            //});
        }
        public void MouseRigthDown(int x, int y)
        {
            quemoue.Enqueue(new POINT()
            {
                @event = EVNET.RDOWN,
                x = x,
                y = y,
                //delay = 0

            });
            //listRemote.Add(new ClassRemotePacket()
            //{
            //    cmd = "mouse_event",
            //    values = new List<object>() { "right", "down" }

            //});
        }

        public void MouseRightUp(int x, int y)
        {
            quemoue.Enqueue(new POINT()
            {
                @event = EVNET.RUP,
                x = x,
                y = y,
                //delay = 0

            });
   
        }

        public byte[] InputEventBytes()
        {
            return new byte[0];
        }

        public int Count
        {
            get
            {
                return listRemote.Count;
            }
        }
        public bool IS_INPUTQUE
        {
            get
            {
                if (quemoue.Count > 0) return true;
                return false;
            }            
        }
        byte [] conv_short_to_bytes(short input)
        {
            byte [] ret = BitConverter.GetBytes(input);
            Array.Reverse(ret);
            return ret;

        }
        public byte [] make_buff(string cmd_name, short p1, short p2, byte [] value= null)
        {

            List<byte> sndbuff = new List<byte>();

            if (value == null) value = new byte[0];

            int cmd = map_cmd[cmd_name];
            short length =(short) value.Length;


            //sndbuff = b'\x02'
            sndbuff.Add(0x02);

            //sndbuff += cmd.to_bytes(1, 'big');
            sndbuff.Add((byte)cmd);


            //sndbuff += conv_short_to_bytes(p1)
            sndbuff.AddRange(conv_short_to_bytes(p1));


            //sndbuff += conv_short_to_bytes(p2)
            sndbuff.AddRange(conv_short_to_bytes(p2));


            //sndbuff += conv_short_to_bytes(length)
            sndbuff.AddRange(conv_short_to_bytes(length));

            //sndbuff += value
            sndbuff.AddRange(value);

            //sndbuff += b'\x03'
            sndbuff.Add(0x03);

            return sndbuff.ToArray();


        }
	
	

    }
}
