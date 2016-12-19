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
            this._representationButton = new System.Windows.Forms.Button();
            this._showGridLinesCheckBox = new System.Windows.Forms.CheckBox();
            this._boxCountLabel = new System.Windows.Forms.Label();
            this._boxCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._fastLabel = new System.Windows.Forms.Label();
            this._slowLabel = new System.Windows.Forms.Label();
            this._timerTrackBar = new System.Windows.Forms.TrackBar();
            this._gameLoopBouton = new System.Windows.Forms.Button();
            this._createAnimalsBouton = new System.Windows.Forms.Button();
            this._dllBouton = new System.Windows.Forms.Button();
            this._dllOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._gameLoopTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._boxCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._timerTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._representationButton);
            this.panel1.Controls.Add(this._showGridLinesCheckBox);
            this.panel1.Controls.Add(this._boxCountLabel);
            this.panel1.Controls.Add(this._boxCountNumericUpDown);
            this.panel1.Controls.Add(this._fastLabel);
            this.panel1.Controls.Add(this._slowLabel);
            this.panel1.Controls.Add(this._timerTrackBar);
            this.panel1.Controls.Add(this._gameLoopBouton);
            this.panel1.Controls.Add(this._createAnimalsBouton);
            this.panel1.Controls.Add(this._dllBouton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 148);
            this.panel1.TabIndex = 0;
            // 
            // _representationButton
            // 
            this._representationButton.Enabled = false;
            this._representationButton.Location = new System.Drawing.Point(213, 38);
            this._representationButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._representationButton.Name = "_representationButton";
            this._representationButton.Size = new System.Drawing.Size(131, 32);
            this._representationButton.TabIndex = 9;
            this._representationButton.Text = "Representation";
            this._representationButton.UseVisualStyleBackColor = true;
            this._representationButton.Click += new System.EventHandler(this._representationButton_Click);
            // 
            // _showGridLinesCheckBox
            // 
            this._showGridLinesCheckBox.AutoSize = true;
            this._showGridLinesCheckBox.Enabled = false;
            this._showGridLinesCheckBox.Location = new System.Drawing.Point(215, 95);
            this._showGridLinesCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._showGridLinesCheckBox.Name = "_showGridLinesCheckBox";
            this._showGridLinesCheckBox.Size = new System.Drawing.Size(125, 21);
            this._showGridLinesCheckBox.TabIndex = 8;
            this._showGridLinesCheckBox.Text = "Show grid lines";
            this._showGridLinesCheckBox.UseVisualStyleBackColor = true;
            this._showGridLinesCheckBox.CheckedChanged += new System.EventHandler(this._showGridLinesCheckBox_CheckedChanged);
            // 
            // _boxCountLabel
            // 
            this._boxCountLabel.AutoSize = true;
            this._boxCountLabel.Enabled = false;
            this._boxCountLabel.Location = new System.Drawing.Point(4, 96);
            this._boxCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._boxCountLabel.Name = "_boxCountLabel";
            this._boxCountLabel.Size = new System.Drawing.Size(78, 17);
            this._boxCountLabel.TabIndex = 7;
            this._boxCountLabel.Text = "Box count :";
            // 
            // _boxCountNumericUpDown
            // 
            this._boxCountNumericUpDown.Enabled = false;
            this._boxCountNumericUpDown.Location = new System.Drawing.Point(84, 94);
            this._boxCountNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._boxCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._boxCountNumericUpDown.Name = "_boxCountNumericUpDown";
            this._boxCountNumericUpDown.Size = new System.Drawing.Size(123, 22);
            this._boxCountNumericUpDown.TabIndex = 6;
            this._boxCountNumericUpDown.Tag = "";
            this._boxCountNumericUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this._boxCountNumericUpDown.ValueChanged += new System.EventHandler(this._boxCountNumericUpDown_ValueChanged);
            // 
            // _fastLabel
            // 
            this._fastLabel.AutoSize = true;
            this._fastLabel.Enabled = false;
            this._fastLabel.Location = new System.Drawing.Point(880, 47);
            this._fastLabel.Name = "_fastLabel";
            this._fastLabel.Size = new System.Drawing.Size(35, 17);
            this._fastLabel.TabIndex = 5;
            this._fastLabel.Text = "Fast";
            // 
            // _slowLabel
            // 
            this._slowLabel.AutoSize = true;
            this._slowLabel.Enabled = false;
            this._slowLabel.Location = new System.Drawing.Point(451, 47);
            this._slowLabel.Name = "_slowLabel";
            this._slowLabel.Size = new System.Drawing.Size(37, 17);
            this._slowLabel.TabIndex = 4;
            this._slowLabel.Text = "Slow";
            // 
            // _timerTrackBar
            // 
            this._timerTrackBar.Enabled = false;
            this._timerTrackBar.Location = new System.Drawing.Point(496, 38);
            this._timerTrackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this._gameLoopBouton.Location = new System.Drawing.Point(351, 38);
            this._gameLoopBouton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this._createAnimalsBouton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._createAnimalsBouton.Name = "_createAnimalsBouton";
            this._createAnimalsBouton.Size = new System.Drawing.Size(123, 32);
            this._createAnimalsBouton.TabIndex = 1;
            this._createAnimalsBouton.Text = "Create animals";
            this._createAnimalsBouton.UseVisualStyleBackColor = true;
            this._createAnimalsBouton.Click += new System.EventHandler(this._createAnimalsBouton_Click);
            // 
            // _dllBouton
            // 
            this._dllBouton.Location = new System.Drawing.Point(3, 38);
            this._dllBouton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ControlPanel";
            this.Size = new System.Drawing.Size(924, 148);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._boxCountNumericUpDown)).EndInit();
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
        private System.Windows.Forms.Label _boxCountLabel;
        private System.Windows.Forms.NumericUpDown _boxCountNumericUpDown;
        private System.Windows.Forms.CheckBox _showGridLinesCheckBox;
        private System.Windows.Forms.Button _representationButton;
    }
}
