using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4Remote
{
    public interface IRemote
    {
        void SetSize(int width, int height);
        void MouseLeftDown(int x, int y);
        void MouseLeftUp(int x, int y);
        void MouseRigthDown(int x, int y);
        void MouseRightUp(int x, int y);
        void MouseMove(int x, int y);
        void MouseMoveAbs(int x, int y, int width, int height);


        void KeyDown(int vk_key);
        void KeyUp(int vk_key);
        string InputString(string  input);
        string InputEvent();
        bool IS_INPUTQUE { get; }
        //  int Count { get; }
    }
}
