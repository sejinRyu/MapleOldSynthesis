using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;

namespace SynthesisMacro
{
    class MouseValue
    {
        public static int Left = 0;
        public static int Right = 1;
        public static int Wheel = 2;
    }
    class EventGeneration
    {
        [DllImport("user32.dll")]
        private static extern void keybd_event(uint vk, uint scan, uint flags, uint extraInfo);

        [DllImport("user32.dll")]
        private static extern uint MapVirtualKey(int wCode, int wMapType);

        [DllImport("user32.dll")] // 입력 제어
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, int dwData, int dwExtraInfo);

        [DllImport("user32.dll")] // 커서 위치 제어
        private static extern int SetCursorPos(int x, int y);

        [DllImport("user32")]
        public static extern UInt16 GetAsyncKeyState(Int32 vKey);

        public static int GetInventoryPointX(int y)
        {
            return 26 + (y * 36);
        }
        public static int GetInventoryPointY(int x)
        {
            return 66 + (x * 36);
        }

        public static void KeybdEvent(uint vk, int pushTime = 200)
        {
            //KeyDown
            keybd_event(vk, MapVirtualKey((int)vk, 0), 0, 0);  

            Thread.Sleep(pushTime);

            //KeyUp
            keybd_event(vk, MapVirtualKey((int)vk, 0), 2, 0);
        }

        public static void KeybdEventAwithB(uint vk1, uint vk2, int pushTime = 200)
        {
            //KeyDown
            keybd_event(vk1, MapVirtualKey((int)vk1, 0), 0, 0);

            KeybdEvent(vk2, pushTime);

            //KeyUp
            keybd_event(vk1, MapVirtualKey((int)vk1, 0), 2, 0);
        }

        public static void MouseClick(int x, int y,int mouseValue , int clickTime)
        {
            //Mouse Move
            SetCursorPos(x, y);

            //Left
            if(mouseValue.Equals(MouseValue.Left))
            {
                //Left Down
                mouse_event(0x00000002 | 0x00008000, 0, 0, 0, 0);

                Thread.Sleep(clickTime);

                //Left Up
                mouse_event(0x00000004 | 0x00008000, 0, 0, 0, 0);
            }
            //Right
            else if(mouseValue.Equals(MouseValue.Right))
            {
                mouse_event(0x00000008 | 0x00008000, 0, 0, 0, 0);

                Thread.Sleep(clickTime);
                
                mouse_event(0x000000010 | 0x00008000, 0, 0, 0, 0);
            }
            //Wheel
            else if(mouseValue.Equals(MouseValue.Wheel))
            {
                mouse_event(0x00000020 | 0x00008000, 0, 0, 0, 0);

                Thread.Sleep(clickTime);
             
                mouse_event(0x00000040 | 0x00008000, 0, 0, 0, 0);
            }
        }

        


//            void Synthesis(const Point& point1, const Point& point2)
//{

//    MouseClick(point1, Status::Mouse::Left, 200);

//    MouseClick({ 650,405 }, Status::Mouse::Left, 200);


//    MouseClick(point2, Status::Mouse::Left, 200);

//    MouseClick({ 715,405 }, Status::Mouse::Left, 200);


//    MouseClick({ 660,462 }, Status::Mouse::Left, 200);


//    Sleep(300);

//    KeybdEvent(VK_RETURN, 6666);

//    KeybdEvent(VK_RETURN);

//    }
    }
}
