using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;

namespace KeyConf
{
    public partial class NotifyIconWrapper : Component
    {

        InterceptKeyboard ik = null;
        
        public NotifyIconWrapper()
        {
            InitializeComponent();
            this.subMenuView.Click += this.subMenuView_Click;
            this.subMenuExit.Click += this.subMenuExit_Click;

            ik = new InterceptKeyboard();
            ik.KeyDownEvent += OnKeyDownHookProc;
            ik.KeyUpEvent += OnKeyUpHookProc;
            ik.Hook();
            BTUtil.StartCheckBTDevice();
        }

        public NotifyIconWrapper(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void subMenuView_Click(object sender, EventArgs e)
        {
            // MainWindow を生成、表示
            var wnd = new MainWindow();
            wnd.Show();
        }

        private void subMenuExit_Click(object sender, EventArgs e)
        {
            ik.UnHook();
            BTUtil.StopCheckBTDevice();

            // 現在のアプリケーションを終了
            Application.Current.Shutdown();
        }

        private void OnKeyDownHookProc(object sender, InterceptKeyboard.OriginalKeyEventArg e)
        {
            Console.WriteLine("Keydown KeyCode {0}", e.KeyCode);
        }
        private void OnKeyUpHookProc(object sender, InterceptKeyboard.OriginalKeyEventArg e)
        {
            Console.WriteLine("Keyup KeyCode {0}", e.KeyCode);
        }
    
    }
}
