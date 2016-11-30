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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dllPath = new System.Windows.Forms.Button();
            this.openDllDialog = new System.Windows.Forms.OpenFileDialog();
            this.createAnimals = new System.Windows.Forms.Button();
            this.menuGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gameLoop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.gameLoopTimer = new System.Windows.Forms.Timer(this.components);
            this._viewPortDemoControl = new ZooRunner.GUI.ViewPortDemoControl();
            this._zooViewPort = new ZooRunner.ZooViewPortControl();
            this.menuGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // dllPath
            // 
            this.dllPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dllPath.BackColor = System.Drawing.Color.Transparent;
            this.dllPath.Location = new System.Drawing.Point(161, 43);
            this.dllPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dllPath.Name = "dllPath";
            this.dllPath.Size = new System.Drawing.Size(93, 32);
            this.dllPath.TabIndex = 0;
            this.dllPath.Text = "DLL";
            this.dllPath.UseVisualStyleBackColor = false;
            this.dllPath.Click += new System.EventHandler(this.DllPath_Click);
            // 
            // createAnimals
            // 
            this.createAnimals.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.createAnimals.Enabled = false;
            this.createAnimals.Location = new System.Drawing.Point(259, 43);
            this.createAnimals.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createAnimals.Name = "createAnimals";
            this.createAnimals.Size = new System.Drawing.Size(137, 32);
            this.createAnimals.TabIndex = 1;
            this.createAnimals.Text = "Create animals";
            this.createAnimals.UseVisualStyleBackColor = true;
            this.createAnimals.Click += new System.EventHandler(this.CreateAnimals_Click);
            // 
            // menuGroupBox
            // 
            this.menuGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuGroupBox.Controls.Add(this.label2);
            this.menuGroupBox.Controls.Add(this.gameLoop);
            this.menuGroupBox.Controls.Add(this.label1);
            this.menuGroupBox.Controls.Add(this.trackBar);
            this.menuGroupBox.Controls.Add(this.dllPath);
            this.menuGroupBox.Controls.Add(this.createAnimals);
            this.menuGroupBox.Location = new System.Drawing.Point(0, 503);
            this.menuGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.menuGroupBox.Name = "menuGroupBox";
            this.menuGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.menuGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuGroupBox.Size = new System.Drawing.Size(1240, 91);
            this.menuGroupBox.TabIndex = 2;
            this.menuGroupBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(663, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Slow";
            // 
            // gameLoop
            // 
            this.gameLoop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameLoop.Enabled = false;
            this.gameLoop.Location = new System.Drawing.Point(403, 43);
            this.gameLoop.Margin = new System.Windows.Forms.Padding(4);
            this.gameLoop.Name = "gameLoop";
            this.gameLoop.Size = new System.Drawing.Size(100, 32);
            this.gameLoop.TabIndex = 5;
            this.gameLoop.Text = "Game loop";
            this.gameLoop.UseVisualStyleBackColor = true;
            this.gameLoop.Click += new System.EventHandler(this.gameLoop_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(1045, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fast";
            // 
            // trackBar
            // 
            this.trackBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.trackBar.Enabled = false;
            this.trackBar.Location = new System.Drawing.Point(711, 43);
            this.trackBar.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(325, 56);
            this.trackBar.TabIndex = 2;
            this.trackBar.Value = 1;
            this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // gameLoopTimer
            // 
            this.gameLoopTimer.Interval = 10000;
            this.gameLoopTimer.Tick += new System.EventHandler(this.gameLoopTimer_Tick);
            // 
            // _viewPortDemoControl
            // 
            this._viewPortDemoControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._viewPortDemoControl.BackColor = System.Drawing.SystemColors.ControlDark;
            this._viewPortDemoControl.Location = new System.Drawing.Point(56, 44);
            this._viewPortDemoControl.Margin = new System.Windows.Forms.Padding(5);
            this._viewPortDemoControl.Name = "_viewPortDemoControl";
            this._viewPortDemoControl.ShowGridLines = true;
            this._viewPortDemoControl.Size = new System.Drawing.Size(270, 264);
            this._viewPortDemoControl.TabIndex = 0;
            this._viewPortDemoControl.Visible = false;
            // 
            // _zooViewPort
            // 
            this._zooViewPort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._zooViewPort.BoxCount = 20;
            this._zooViewPort.Location = new System.Drawing.Point(334, 21);
            this._zooViewPort.Name = "_zooViewPort";
            this._zooViewPort.Size = new System.Drawing.Size(876, 492);
            this._zooViewPort.TabIndex = 3;
            this._zooViewPort.Text = "zooViewPortControl1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1240, 594);
            this.Controls.Add(this._zooViewPort);
            this.Controls.Add(this._viewPortDemoControl);
            this.Controls.Add(this.menuGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "ZooRunner";
            this.menuGroupBox.ResumeLayout(false);
            this.menuGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button dllPath;
        private System.Windows.Forms.OpenFileDialog openDllDialog;
        private System.Windows.Forms.Button createAnimals;
        private System.Windows.Forms.GroupBox menuGroupBox;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button gameLoop;
        private System.Windows.Forms.Timer gameLoopTimer;
        private ViewPortDemoControl _viewPortDemoControl;
        private ZooViewPortControl _zooViewPort;
    }
}

