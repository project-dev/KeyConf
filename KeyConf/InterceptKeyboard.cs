using System;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace KeyConf
{
    class InterceptKeyboard : AbstractInterceptKeyboard
    {
        #region InputEvent
        public class OriginalKeyEventArg : EventArgs
        {
            public int KeyCode { get; private set; }

            public OriginalKeyEventArg(int keyCode)
            {
                KeyCode = keyCode;
            }
        }
        public delegate void KeyEventHandler(object sender, OriginalKeyEventArg e);
        public event KeyEventHandler KeyDownEvent;
        public event KeyEventHandler KeyUpEvent;
        private uint prevKeyDownCode = 0;
        private uint prevKeyUpCode = 0;

        protected void OnKeyDownEvent(int keyCode)
        {
            if(KeyDownEvent == null){
                return;
            }
            KeyDownEvent.Invoke(this, new OriginalKeyEventArg(keyCode));
        }
        protected void OnKeyUpEvent(int keyCode)
        {
            if (KeyUpEvent == null)
            {
                return;
            }
            KeyUpEvent.Invoke(this, new OriginalKeyEventArg(keyCode));
        }
        #endregion

        public override IntPtr HookProcedure(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (BTUtil.IsConnected("ELECOM Bluetooth Keyboard") == false)
            {
                return base.HookProcedure(nCode, wParam, lParam);
            }


            var num = 0;
            INPUT[] inp = null;
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                var kb = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));

                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("kb.dwExtraInfo : {0}", kb.dwExtraInfo);
                Console.WriteLine("kb.flags       : {0}", kb.flags);
                Console.WriteLine("kb.scanCode    : {0}", kb.scanCode);
                Console.WriteLine("kb.time        : {0}", kb.time);
                Console.WriteLine("kb.vkCode      : {0}", kb.vkCode);
                
                
                if ((int)kb.dwExtraInfo == dwExtraInfoNumber)
                {
                    // この処理で発生したキーイベントは処理しない
                    return base.HookProcedure(nCode, wParam, lParam);
                }
                Console.WriteLine("{0},0x{1:X}({1})", nCode, kb.vkCode);

                switch (kb.vkCode)
                {
                    case 172:
                        // 0xAC
                        //ESCに変換
                        num = 1;
                        inp = new INPUT[num];
                        inp[0].type = INPUT_KEYBOARD;
                        inp[0].ki.wVk = (short)VK_ESCAPE;
                        inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                        inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYDOWN;
                        inp[0].ki.dwExtraInfo = dwExtraInfoNumber;
                        inp[0].ki.time = 0;
                        break;
                    case 170:
                        // 0xAA
                        // F2
                        num = 1;
                        inp = new INPUT[num];
                        inp[0].type = INPUT_KEYBOARD;
                        inp[0].ki.wVk = (short)VK_F2;
                        inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                        inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYDOWN;
                        inp[0].ki.dwExtraInfo = dwExtraInfoNumber;
                        inp[0].ki.time = 0;
                        break;
                    case 177:
                        // 0xB1
                        // F3
                        num = 1;
                        inp = new INPUT[num];
                        inp[0].type = INPUT_KEYBOARD;
                        inp[0].ki.wVk = (short)VK_F3;
                        inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                        inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYDOWN;
                        inp[0].ki.dwExtraInfo = dwExtraInfoNumber;
                        inp[0].ki.time = 0;
                        break;
                    case 179:
                        // B3
                        // F4
                        num = 1;
                        inp = new INPUT[num];
                        inp[0].type = INPUT_KEYBOARD;
                        inp[0].ki.wVk = (short)VK_F4;
                        inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                        inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYDOWN;
                        inp[0].ki.dwExtraInfo = dwExtraInfoNumber;
                        inp[0].ki.time = 0;
                        break;
                    case 176:
                        // 0xB0
                        // F5
                        num = 1;
                        inp = new INPUT[num];
                        inp[0].type = INPUT_KEYBOARD;
                        inp[0].ki.wVk = (short)VK_F5;
                        inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                        inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYDOWN;
                        inp[0].ki.dwExtraInfo = dwExtraInfoNumber;
                        inp[0].ki.time = 0;
                        break;
                    case 173:
                        // 0xAD
                        // F6
                        num = 1;
                        inp = new INPUT[num];
                        inp[0].type = INPUT_KEYBOARD;
                        inp[0].ki.wVk = (short)VK_F6;
                        inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                        inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYDOWN;
                        inp[0].ki.dwExtraInfo = dwExtraInfoNumber;
                        inp[0].ki.time = 0;
                        break;
                    case 174:
                        // 0xAE
                        // F7
                        num = 1;
                        inp = new INPUT[num];
                        inp[0].type = INPUT_KEYBOARD;
                        inp[0].ki.wVk = (short)VK_F7;
                        inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                        inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYDOWN;
                        inp[0].ki.dwExtraInfo = dwExtraInfoNumber;
                        inp[0].ki.time = 0;
                        break;
                    case 175:
                        //0xAF
                        // F8
                        num = 1;
                        inp = new INPUT[num];
                        inp[0].type = INPUT_KEYBOARD;
                        inp[0].ki.wVk = (short)VK_F8;
                        inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                        inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYDOWN;
                        inp[0].ki.dwExtraInfo = dwExtraInfoNumber;
                        inp[0].ki.time = 0;
                        break;
                    case 91:
                        // 0x5B
                        break;
                    case 9:
                        // 0x09                        // F9 91(VK_LWIN)→9(VK_TAB)の順番
                        if (prevKeyDownCode == 91)
                        //if(GetKeyState(91) < 0)
                        {
                            num = 1;
                            inp = new INPUT[num];
                            inp[0].type = INPUT_KEYBOARD;
                            inp[0].ki.wVk = (short)VK_F9;
                            inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                            inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYDOWN;
                            inp[0].ki.dwExtraInfo = dwExtraInfoNumber;
                            inp[0].ki.time = 0;
                        }
                        break;
                    case 44:
                        // 0x2C
                        // F10
                        // スクリーンショットと被るので、ctrl/alt/shiftを押していないときだけF10に変換する
                        switch(prevKeyDownCode){
                            case 0xA0:
                                // SHift
                                // VK_LSHIFT
                                break;
                            case 0xA1:
                                // VK_RSHIFT
                                break;
                            case 0x11:
                                // Control
                                break;
                            case 0xA2:
                                // VK_LCONTROL
                                break;
                            case 0xA3:
                                // VK_RCONTROL
                                break;
                            case 0x12:
                                // ALT
                                break;
                            case 0xA4:
                                // VK_LMENU
                                break;
                            case 0xA5:
                                // VK_RMENU
                                break;
                            default:
                                num = 1;
                                inp = new INPUT[num];
                                inp[0].type = INPUT_KEYBOARD;
                                inp[0].ki.wVk = (short)VK_F10;
                                inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                                inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYDOWN;
                                inp[0].ki.dwExtraInfo = dwExtraInfoNumber;
                                inp[0].ki.time = 0;
                                break;
                        }
                        break;
                        
                }
                prevKeyDownCode = kb.vkCode;

                if (num > 0)
                {
                    SendInput(num, ref inp[0], Marshal.SizeOf(inp[0]));
                    return (IntPtr)1;
                }

//                Marshal.StructureToPtr(kb, lParam, true);
//                var vkCode = (int)kb.vkCode;
//                OnKeyDownEvent(vkCode);
            }
            else if (nCode >= 0 && (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP))
            {
                var kb = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
                if ((int)kb.dwExtraInfo == dwExtraInfoNumber)
                {
                    // この処理で発生したキーイベントは処理しない
                    return base.HookProcedure(nCode, wParam, lParam);
                }
                switch (kb.vkCode)
                {
                    case 172:
                        //ESCに変換
                        num = 1;
                        inp = new INPUT[num];
                        inp[0].type = INPUT_KEYBOARD;
                        inp[0].ki.wVk = (short)VK_ESCAPE;
                        inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                        inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP;
                        inp[0].ki.dwExtraInfo = 0;
                        inp[0].ki.time = 0;
                        break;
                    case 170:
                        // F2
                        num = 1;
                        inp = new INPUT[num];
                        inp[0].type = INPUT_KEYBOARD;
                        inp[0].ki.wVk = (short)VK_F2;
                        inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                        inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP;
                        inp[0].ki.dwExtraInfo = 0;
                        inp[0].ki.time = 0;
                        break;
                    case 177:
                        // F3
                        num = 1;
                        inp = new INPUT[num];
                        inp[0].type = INPUT_KEYBOARD;
                        inp[0].ki.wVk = (short)VK_F3;
                        inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                        inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP;
                        inp[0].ki.dwExtraInfo = 0;
                        inp[0].ki.time = 0;
                        break;
                    case 179:
                        // F4
                        num = 1;
                        inp = new INPUT[num];
                        inp[0].type = INPUT_KEYBOARD;
                        inp[0].ki.wVk = (short)VK_F4;
                        inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                        inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP;
                        inp[0].ki.dwExtraInfo = 0;
                        inp[0].ki.time = 0;
                        break;
                    case 176:
                        // F5
                        num = 1;
                        inp = new INPUT[num];
                        inp[0].type = INPUT_KEYBOARD;
                        inp[0].ki.wVk = (short)VK_F5;
                        inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                        inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP;
                        inp[0].ki.dwExtraInfo = 0;
                        inp[0].ki.time = 0;
                        break;
                    case 173:
                        // F6
                        num = 1;
                        inp = new INPUT[num];
                        inp[0].type = INPUT_KEYBOARD;
                        inp[0].ki.wVk = (short)VK_F6;
                        inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                        inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP;
                        inp[0].ki.dwExtraInfo = 0;
                        inp[0].ki.time = 0;
                        break;
                    case 174:
                        // F7
                        num = 1;
                        inp = new INPUT[num];
                        inp[0].type = INPUT_KEYBOARD;
                        inp[0].ki.wVk = (short)VK_F7;
                        inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                        inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP;
                        inp[0].ki.dwExtraInfo = 0;
                        inp[0].ki.time = 0;
                        break;
                    case 175:
                        // F8
                        num = 1;
                        inp = new INPUT[num];
                        inp[0].type = INPUT_KEYBOARD;
                        inp[0].ki.wVk = (short)VK_F8;
                        inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                        inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP;
                        inp[0].ki.dwExtraInfo = 0;
                        inp[0].ki.time = 0;
                        break;
/*                    
                    case 91:
                        prevKeyUpCode = 91;
                        break;
                    case 9:
                        // F9 91(VK_LWIN)→9(VK_TAB)の順番
                        if (prevKeyUpCode == 91)
                        {
                            num = 1;
                            inp = new INPUT[num];
                            inp[0].type = INPUT_KEYBOARD;
                            inp[0].ki.wVk = (short)VK_F9;
                            inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                            inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP;
                            inp[0].ki.dwExtraInfo = 0;
                            inp[0].ki.time = 0;
                        }
                        break;
*/
                    case 44:
                        // F10
                        num = 1;
                        inp = new INPUT[num];
                        inp[0].type = INPUT_KEYBOARD;
                        inp[0].ki.wVk = (short)VK_F10;
                        inp[0].ki.wScan = (short)MapVirtualKey(inp[0].ki.wVk, 0);
                        inp[0].ki.dwFlags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP;
                        inp[0].ki.dwExtraInfo = 0;
                        inp[0].ki.time = 0;
                        break;
                }
                prevKeyUpCode = kb.vkCode;
                if (num > 0)
                {
                    SendInput(num, ref inp[0], Marshal.SizeOf(inp[0]));
                    return (System.IntPtr)1;
                }
            }

            return base.HookProcedure(nCode, wParam, lParam);
        }
    }
}
