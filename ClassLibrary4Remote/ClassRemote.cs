﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4Remote
{
    public class ClassRemote : IRemote
    {
        Dictionary<int, string>      VK_CODE = new Dictionary<Int32, string>(){
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


        IList<ClassRemotePacket> listRemote = new List<ClassRemotePacket>();
        public void InputString(string input)
        {
            listRemote.Add(new ClassRemotePacket()
            {
                cmd = "input_string",
                values = new List<object>() { input, "" }

            });

        }

        public string Invoke()
        {
            string ret = JsonConvert.SerializeObject(listRemote);
            listRemote.Clear();
            return ret;
        }
        
        public void KeyDown(int vk_key)
        {
            listRemote.Add(new ClassRemotePacket()
            {
                cmd = "kbd_event",
                values = new List<object>() { VK_CODE[vk_key], "down"}

            });
        }

        public void KeyUp(int vk_key)
        {
            listRemote.Add(new ClassRemotePacket()
            {
                cmd = "kbd_event",
                values = new List<object>() { VK_CODE[vk_key], "up" }

            });
        }

        public void MouseDown()
        {
            listRemote.Add(new ClassRemotePacket()
            {
                cmd = "mouse_event",
                values = new List<object>() { "left", "down" }

            });
        }

       

        public void MouseMove(int x, int y)
        {
            listRemote.Add(new ClassRemotePacket()
            {
                cmd = "mouse_move",
                values = new List<object>() {x,y }

            });
        }

        public void MouseUp()
        {
            listRemote.Add(new ClassRemotePacket()
            {
                cmd = "mouse_event",
                values = new List<object>() { "left", "up" }

            });
        }
        public void MouseRigthDown()
        {
            listRemote.Add(new ClassRemotePacket()
            {
                cmd = "mouse_event",
                values = new List<object>() { "right", "down" }

            });
        }

        public void MouseRightUp()
        {
            listRemote.Add(new ClassRemotePacket()
            {
                cmd = "mouse_event",
                values = new List<object>() { "right", "up" }

            });
        }
    }
}