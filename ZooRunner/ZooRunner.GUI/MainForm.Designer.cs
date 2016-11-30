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
            this._controlPanel = new ZooRunner.GUI.ControlPanel();
            this._zooViewPort = new ZooRunner.ZooViewPortControl();
            this._viewPortDemoControl = new ZooRunner.GUI.ViewPortDemoControl();
            this.SuspendLayout();
            // 
            // _controlPanel
            // 
            this._controlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._controlPanel.Location = new System.Drawing.Point(14, 443);
            this._controlPanel.Name = "_controlPanel";
            this._controlPanel.Size = new System.Drawing.Size(1216, 101);
            this._controlPanel.TabIndex = 4;
            // 
            // _zooViewPort
            // 
            this._zooViewPort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._zooViewPort.BoxCount = 20;
            this._zooViewPort.Location = new System.Drawing.Point(352, 12);
            this._zooViewPort.Name = "_zooViewPort";
            this._zooViewPort.Size = new System.Drawing.Size(876, 423);
            this._zooViewPort.TabIndex = 3;
            this._zooViewPort.Text = "_zooViewPortControl";
            // 
            // _viewPortDemoControl
            // 
            this._viewPortDemoControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._viewPortDemoControl.BackColor = System.Drawing.SystemColors.ControlDark;
            this._viewPortDemoControl.Location = new System.Drawing.Point(14, 14);
            this._viewPortDemoControl.Margin = new System.Windows.Forms.Padding(5);
            this._viewPortDemoControl.Name = "_viewPortDemoControl";
            this._viewPortDemoControl.ShowGridLines = true;
            this._viewPortDemoControl.Size = new System.Drawing.Size(330, 421);
            this._viewPortDemoControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1240, 556);
            this.Controls.Add(this._controlPanel);
            this.Controls.Add(this._zooViewPort);
            this.Controls.Add(this._viewPortDemoControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "ZooRunner";
            this.ResumeLayout(false);

        }

        #endregion
        private ViewPortDemoControl _viewPortDemoControl;
        private ControlPanel _controlPanel;
        private ZooViewPortControl _zooViewPort;
    }
}

