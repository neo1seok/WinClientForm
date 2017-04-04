using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4Remote
{
    interface IRemote
    {
        void MouseDown();
        void MouseUp();
        void MouseRigthDown();
        void MouseRightUp();
        void MouseMove(int x, int y);
       
        void KeyDown(int vk_key);
        void KeyUp(int vk_key);
        void InputString(string  input);
        string Invoke();
    }
}
