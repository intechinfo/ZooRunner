namespace ZooRunner.GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._zooViewPortControl = new ZooRunner.ZooViewPortControl();
            this._controlPanel = new ZooRunner.GUI.ControlPanel();
            this.SuspendLayout();
            // 
            // _zooViewPortControl
            // 
            this._zooViewPortControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._zooViewPortControl.BackColor = System.Drawing.SystemColors.Control;
            this._zooViewPortControl.BoxCount = 20;
            this._zooViewPortControl.Enabled = false;
            this._zooViewPortControl.Location = new System.Drawing.Point(12, 12);
            this._zooViewPortControl.Name = "_zooViewPortControl";
            this._zooViewPortControl.ShowGridLines = false;
            this._zooViewPortControl.Size = new System.Drawing.Size(775, 427);
            this._zooViewPortControl.TabIndex = 5;
            this._zooViewPortControl.Text = "zooViewPortControl";
            this._zooViewPortControl.MouseLeaveControl += new System.EventHandler(this.OnMouseLeaveControl);
            // 
            // _controlPanel
            // 
            this._controlPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._controlPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this._controlPanel.Location = new System.Drawing.Point(12, 444);
            this._controlPanel.Margin = new System.Windows.Forms.Padding(2);
            this._controlPanel.Name = "_controlPanel";
            this._controlPanel.Size = new System.Drawing.Size(775, 101);
            this._controlPanel.TabIndex = 4;
            this._controlPanel.UserGivesDll += new System.EventHandler<ZooRunner.ZooAdapter>(this.OnUserGivesDll);
            this._controlPanel.TimerTick += new System.EventHandler(this.OnTimerTick);
            this._controlPanel.BoxCountChange += new System.EventHandler<int>(this.OnBoxCountChange);
            this._controlPanel.ShowGridLines += new System.EventHandler<bool>(this.OnShowGridLines);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(798, 556);
            this.Controls.Add(this._zooViewPortControl);
            this.Controls.Add(this._controlPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "ZooRunner";
            this.ResumeLayout(false);

        }

        #endregion
        private ControlPanel _controlPanel;
        private ZooViewPortControl _zooViewPortControl;
    }
}

