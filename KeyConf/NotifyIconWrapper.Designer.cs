namespace KeyConf
{
    partial class NotifyIconWrapper
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyIconWrapper));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.subMenuView = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenu.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenuStrip = this.ctxMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Key Config";
            this.notifyIcon.Visible = true;
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuView,
            this.subMenuExit});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(128, 52);
            // 
            // subMenuView
            // 
            this.subMenuView.Name = "subMenuView";
            this.subMenuView.Size = new System.Drawing.Size(127, 24);
            this.subMenuView.Text = "表示(&V)";
            // 
            // subMenuExit
            // 
            this.subMenuExit.Name = "subMenuExit";
            this.subMenuExit.Size = new System.Drawing.Size(127, 24);
            this.subMenuExit.Text = "終了(&X)";
            this.ctxMenu.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem subMenuView;
        private System.Windows.Forms.ToolStripMenuItem subMenuExit;
    }
}
