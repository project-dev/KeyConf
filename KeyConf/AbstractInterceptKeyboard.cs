using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace KeyConf
{
    abstract class AbstractInterceptKeyboard
    {
        protected const int dwExtraInfoNumber = 0xF0;

        #region Win32 Constants
        protected const int WH_KEYBOARD_LL = 0x000D;
        protected const int WM_KEYDOWN = 0x0100;
        protected const int WM_KEYUP = 0x0101;
        protected const int WM_SYSKEYDOWN = 0x0104;
        protected const int WM_SYSKEYUP = 0x0105;


        protected const int VK_ESCAPE = 0x1B;
        protected const int VK_F1 = 0x70;
        protected const int VK_F2 = 0x71;
        protected const int VK_F3 = 0x72;
        protected const int VK_F4 = 0x73;
        protected const int VK_F5 = 0x74;
        protected const int VK_F6 = 0x75;
        protected const int VK_F7 = 0x76;
        protected const int VK_F8 = 0x77;
        protected const int VK_F9 = 0x78;
        protected const int VK_F10 = 0x79;
        protected const int VK_F11 = 0x7A;
        protected const int VK_F12 = 0x7B;
        protected const int VK_F13 = 0x7C;
        protected const int VK_F14 = 0x7D;
        protected const int VK_F15 = 0x7E;
        #endregion

        #region Win32API Structures
        [StructLayout(LayoutKind.Sequential)]
        public class KBDLLHOOKSTRUCT
        {
            public uint vkCode;
            public uint scanCode;
            public KBDLLHOOKSTRUCTFlags flags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        [Flags]
        public enum KBDLLHOOKSTRUCTFlags : uint
        {
            KEYEVENTF_EXTENDEDKEY = 0x0001,
            KEYEVENTF_KEYUP = 0x0002,
            KEYEVENTF_SCANCODE = 0x0008,
            KEYEVENTF_UNICODE = 0x0004,
        }
        #endregion

        #region Win32 Methods
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, KeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        protected static extern long PostMessage(
          IntPtr hWnd,    // 送信先ウィンドウのハンドル
          uint Msg,       // メッセージ
          uint wParam,    // メッセージの最初のパラメータ
          uint lParam     // メッセージの 2 番目のパラメータ
        );

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        protected static extern short GetKeyState(int nVirtKey);

        
        #endregion

        #region Delegate
        private delegate IntPtr KeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        #endregion

        #region Fields
        private KeyboardProc proc;
        private IntPtr hookId = IntPtr.Zero;
        #endregion

        // マウスイベント(mouse_eventの引数と同様のデータ)
        [StructLayout(LayoutKind.Sequential)]
        protected struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public int dwExtraInfo;
        };

        // キーボードイベント(keybd_eventの引数と同様のデータ)
        [StructLayout(LayoutKind.Sequential)]
        protected struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public int dwExtraInfo;
        };

        // ハードウェアイベント
        [StructLayout(LayoutKind.Sequential)]
        protected struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        };
        // 各種イベント(SendInputの引数データ)
        [StructLayout(LayoutKind.Explicit)]
        protected struct INPUT
        {
            [FieldOffset(0)]
            public int type;
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            [FieldOffset(4)]
            public KEYBDINPUT ki;
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
        };

        [DllImport("user32.dll")]
        protected extern static void SendInput(int nInputs, ref INPUT pInputs, int cbsize);

        // 仮想キーコードをスキャンコードに変換
        [DllImport("user32.dll", EntryPoint = "MapVirtualKeyA")]
        protected extern static int MapVirtualKey(
            int wCode, int wMapType);

        protected const int INPUT_MOUSE = 0;                  // マウスイベント
        protected const int INPUT_KEYBOARD = 1;               // キーボードイベント
        protected const int INPUT_HARDWARE = 2;               // ハードウェアイベント

        protected const int MOUSEEVENTF_MOVE = 0x1;           // マウスを移動する
        protected const int MOUSEEVENTF_ABSOLUTE = 0x8000;    // 絶対座標指定
        protected const int MOUSEEVENTF_LEFTDOWN = 0x2;       // 左　ボタンを押す
        protected const int MOUSEEVENTF_LEFTUP = 0x4;         // 左　ボタンを離す
        protected const int MOUSEEVENTF_RIGHTDOWN = 0x8;      // 右　ボタンを押す
        protected const int MOUSEEVENTF_RIGHTUP = 0x10;       // 右　ボタンを離す
        protected const int MOUSEEVENTF_MIDDLEDOWN = 0x20;    // 中央ボタンを押す
        protected const int MOUSEEVENTF_MIDDLEUP = 0x40;      // 中央ボタンを離す
        protected const int MOUSEEVENTF_WHEEL = 0x800;        // ホイールを回転する
        protected const int WHEEL_DELTA = 120;                // ホイール回転値

        protected const int KEYEVENTF_KEYDOWN = 0x0;          // キーを押す
        protected const int KEYEVENTF_KEYUP = 0x2;            // キーを離す
        protected const int KEYEVENTF_EXTENDEDKEY = 0x1;      // 拡張コード
        protected const int VK_SHIFT = 0x10;                  // SHIFTキー        

        public void Hook()
        {
            if (hookId == IntPtr.Zero)
            {
                proc = HookProcedure;
                using (var curProcess = Process.GetCurrentProcess())
                {
                    using (ProcessModule curModule = curProcess.MainModule)
                    {
                        hookId = SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
                    }
                }
            }
        }

        public void UnHook()
        {
            UnhookWindowsHookEx(hookId);
            hookId = IntPtr.Zero;
        }

        public virtual IntPtr HookProcedure(int nCode, IntPtr wParam, IntPtr lParam)
        {
            return CallNextHookEx(hookId, nCode, wParam, lParam);
        }
    }
}
