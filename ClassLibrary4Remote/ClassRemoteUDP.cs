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

		Dictionary<EVNET, int> map_cmd = new Dictionary<EVNET, int>()
            {

            {EVNET.START,0x20},
			{EVNET.END,  0x21},
			{EVNET.MOVE, 0x10},
			{EVNET.LDOWN,0x11},
			{EVNET.LUP,  0x12},
			{EVNET.RDOWN,0x13},
			{EVNET.RUP,  0x14},
			{EVNET.KEYDOWN,0x15},
			{EVNET.KEYUP,0x16},
			{EVNET.INPUT_STR,0x17},
            {EVNET.WHEEL,0x18},

            };
		
	
       override public void InputString(string input)
        {

			quemoue.Enqueue(new POINT()
			{
				@event = EVNET.START,
				values = input,
				//  delay = 0

			});
          

        }
        override public void MouseWheel(int delta)
        {
            quemoue.Enqueue(new POINT()
            {
                @event = EVNET.WHEEL,
                delta = delta,
                //  delay = 0

            });

         
        }
        override public void SetSize(int width, int height)
		{
			screensize.dx = width;
			screensize.dy = height;
			quemoue.Enqueue(new POINT()
			{
				@event = EVNET.START,
				x = width,
				y = height,
				//  delay = 0

			});

		}
		

        override public byte[] InputEventBytes()
        {

			if (quemoue.ToList().Count == 0) return null;
			
			var point = quemoue.Dequeue();
			string cmd = "";
			short p1 =0;
			short p2 =0;
			byte[] value = new byte[0];

			switch (point.@event)
			{
                case EVNET.WHEEL:
                    p1 = (short)point.delta;
                    break;
				case EVNET.KEYDOWN:
				case EVNET.KEYUP:
					p1 = (short)point.vkey;
					break;
				case EVNET.START:
				case EVNET.MOVE:
				case EVNET.LDOWN:
				case EVNET.LUP:
				case EVNET.RDOWN:
				case EVNET.RUP:
					p1 = (short)point.x;
					p2 = (short)point.y;

					break;
				case EVNET.INPUT_STR:
					value = Encoding.UTF8.GetBytes(point.values);
					
					break;


				default:
					break;
			}
			int count = quemoue.ToList().Count;
			status = string.Format("cmd:{0} p1:{1} p2:{2}  que:{3}", point.@event, p1, p2, count);


			return make_buff(point.@event, p1, p2, value);
			
        }

    
		byte[] conv_short_to_bytes(short input)
		{
			byte[] ret = BitConverter.GetBytes(input);
			Array.Reverse(ret);
			return ret;

		}
		byte[] make_buff(EVNET cmd_name, short p1, short p2, byte[] value = null)
		{

			List<byte> sndbuff = new List<byte>();

			if (value == null) value = new byte[0];

			int cmd = map_cmd[cmd_name];
			short length = (short)value.Length;


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
