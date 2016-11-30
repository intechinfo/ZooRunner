namespace ZooRunner.GUI
{
    partial class ViewPortDemoControl
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
            this._displayInfo = new System.Windows.Forms.TextBox();
            this._zoomer = new System.Windows.Forms.TrackBar();
            this._viewPortLeft = new System.Windows.Forms.NumericUpDown();
            this._viewPortTop = new System.Windows.Forms.NumericUpDown();
            this._viewControl = new ZooRunner.ViewPortControl();
            ((System.ComponentModel.ISupportInitialize)(this._zoomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._viewPortLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._viewPortTop)).BeginInit();
            this.SuspendLayout();
            // 
            // _displayInfo
            // 
            this._displayInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._displayInfo.Location = new System.Drawing.Point(5, 487);
            this._displayInfo.Margin = new System.Windows.Forms.Padding(4);
            this._displayInfo.Multiline = true;
            this._displayInfo.Name = "_displayInfo";
            this._displayInfo.ReadOnly = true;
            this._displayInfo.Size = new System.Drawing.Size(790, 109);
            this._displayInfo.TabIndex = 1;
            // 
            // _zoomer
            // 
            this._zoomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._zoomer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._zoomer.LargeChange = 100;
            this._zoomer.Location = new System.Drawing.Point(31, 68);
            this._zoomer.Margin = new System.Windows.Forms.Padding(4);
            this._zoomer.Maximum = 1000;
            this._zoomer.Name = "_zoomer";
            this._zoomer.Orientation = System.Windows.Forms.Orientation.Vertical;
            this._zoomer.Size = new System.Drawing.Size(56, 412);
            this._zoomer.TabIndex = 0;
            this._zoomer.TickFrequency = 100;
            this._zoomer.Value = 1000;
            this._zoomer.Scroll += new System.EventHandler(this._zoomer_Scroll);
            // 
            // _viewPortLeft
            // 
            this._viewPortLeft.Location = new System.Drawing.Point(5, 4);
            this._viewPortLeft.Margin = new System.Windows.Forms.Padding(4);
            this._viewPortLeft.Name = "_viewPortLeft";
            this._viewPortLeft.Size = new System.Drawing.Size(87, 22);
            this._viewPortLeft.TabIndex = 2;
            this._viewPortLeft.ValueChanged += new System.EventHandler(this._viewPortLeft_ValueChanged);
            // 
            // _viewPortTop
            // 
            this._viewPortTop.Location = new System.Drawing.Point(4, 36);
            this._viewPortTop.Margin = new System.Windows.Forms.Padding(4);
            this._viewPortTop.Name = "_viewPortTop";
            this._viewPortTop.Size = new System.Drawing.Size(87, 22);
            this._viewPortTop.TabIndex = 2;
            this._viewPortTop.ValueChanged += new System.EventHandler(this._viewPortTop_ValueChanged);
            // 
            // _viewControl
            // 
            this._viewControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._viewControl.Location = new System.Drawing.Point(100, 18);
            this._viewControl.Margin = new System.Windows.Forms.Padding(4);
            this._viewControl.Name = "_viewControl";
            this._viewControl.Size = new System.Drawing.Size(683, 462);
            this._viewControl.TabIndex = 0;
            this._viewControl.Text = "_viewControl";
            // 
            // ViewPortDemoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this._viewPortTop);
            this.Controls.Add(this._viewPortLeft);
            this.Controls.Add(this._zoomer);
            this.Controls.Add(this._displayInfo);
            this.Controls.Add(this._viewControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ViewPortDemoControl";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this._zoomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._viewPortLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._viewPortTop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ViewPortControl _viewControl;
        private System.Windows.Forms.TextBox _displayInfo;
        private System.Windows.Forms.TrackBar _zoomer;
        private System.Windows.Forms.NumericUpDown _viewPortLeft;
        private System.Windows.Forms.NumericUpDown _viewPortTop;
    }
}

