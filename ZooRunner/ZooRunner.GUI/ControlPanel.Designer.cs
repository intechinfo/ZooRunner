namespace ZooRunner.GUI
{
    partial class ControlPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this._fastLabel = new System.Windows.Forms.Label();
            this._slowLabel = new System.Windows.Forms.Label();
            this._timerTrackBar = new System.Windows.Forms.TrackBar();
            this._gameLoopBouton = new System.Windows.Forms.Button();
            this._createAnimalsBouton = new System.Windows.Forms.Button();
            this._dllBouton = new System.Windows.Forms.Button();
            this._dllOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._gameLoopTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._timerTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this._fastLabel);
            this.panel1.Controls.Add(this._slowLabel);
            this.panel1.Controls.Add(this._timerTrackBar);
            this.panel1.Controls.Add(this._gameLoopBouton);
            this.panel1.Controls.Add(this._createAnimalsBouton);
            this.panel1.Controls.Add(this._dllBouton);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 105);
            this.panel1.TabIndex = 0;
            // 
            // _fastLabel
            // 
            this._fastLabel.AutoSize = true;
            this._fastLabel.Enabled = false;
            this._fastLabel.Location = new System.Drawing.Point(740, 46);
            this._fastLabel.Name = "_fastLabel";
            this._fastLabel.Size = new System.Drawing.Size(35, 17);
            this._fastLabel.TabIndex = 5;
            this._fastLabel.Text = "Fast";
            // 
            // _slowLabel
            // 
            this._slowLabel.AutoSize = true;
            this._slowLabel.Enabled = false;
            this._slowLabel.Location = new System.Drawing.Point(314, 46);
            this._slowLabel.Name = "_slowLabel";
            this._slowLabel.Size = new System.Drawing.Size(37, 17);
            this._slowLabel.TabIndex = 4;
            this._slowLabel.Text = "Slow";
            // 
            // _timerTrackBar
            // 
            this._timerTrackBar.Enabled = false;
            this._timerTrackBar.Location = new System.Drawing.Point(357, 38);
            this._timerTrackBar.Minimum = 1;
            this._timerTrackBar.Name = "_timerTrackBar";
            this._timerTrackBar.Size = new System.Drawing.Size(379, 56);
            this._timerTrackBar.TabIndex = 2;
            this._timerTrackBar.Value = 1;
            this._timerTrackBar.ValueChanged += new System.EventHandler(this._timerTrackBar_ValueChanged);
            // 
            // _gameLoopBouton
            // 
            this._gameLoopBouton.Enabled = false;
            this._gameLoopBouton.Location = new System.Drawing.Point(213, 38);
            this._gameLoopBouton.Name = "_gameLoopBouton";
            this._gameLoopBouton.Size = new System.Drawing.Size(95, 32);
            this._gameLoopBouton.TabIndex = 2;
            this._gameLoopBouton.Text = "Game loop";
            this._gameLoopBouton.UseVisualStyleBackColor = true;
            this._gameLoopBouton.Click += new System.EventHandler(this._gameLoopBouton_Click);
            // 
            // _createAnimalsBouton
            // 
            this._createAnimalsBouton.Enabled = false;
            this._createAnimalsBouton.Location = new System.Drawing.Point(84, 38);
            this._createAnimalsBouton.Name = "_createAnimalsBouton";
            this._createAnimalsBouton.Size = new System.Drawing.Size(123, 32);
            this._createAnimalsBouton.TabIndex = 1;
            this._createAnimalsBouton.Text = "Create Animals";
            this._createAnimalsBouton.UseVisualStyleBackColor = true;
            this._createAnimalsBouton.Click += new System.EventHandler(this._createAnimalsBouton_Click);
            // 
            // _dllBouton
            // 
            this._dllBouton.Location = new System.Drawing.Point(3, 38);
            this._dllBouton.Name = "_dllBouton";
            this._dllBouton.Size = new System.Drawing.Size(75, 32);
            this._dllBouton.TabIndex = 0;
            this._dllBouton.Text = "DLL";
            this._dllBouton.UseVisualStyleBackColor = true;
            this._dllBouton.Click += new System.EventHandler(this._dllBouton_Click);
            // 
            // _gameLoopTimer
            // 
            this._gameLoopTimer.Interval = 10000;
            this._gameLoopTimer.Tick += new System.EventHandler(this._gameLoopTimer_Tick);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ControlPanel";
            this.Size = new System.Drawing.Size(783, 110);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._timerTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _dllBouton;
        private System.Windows.Forms.Button _createAnimalsBouton;
        private System.Windows.Forms.Button _gameLoopBouton;
        private System.Windows.Forms.TrackBar _timerTrackBar;
        private System.Windows.Forms.Label _fastLabel;
        private System.Windows.Forms.Label _slowLabel;
        private System.Windows.Forms.OpenFileDialog _dllOpenFileDialog;
        private System.Windows.Forms.Timer _gameLoopTimer;
    }
}
