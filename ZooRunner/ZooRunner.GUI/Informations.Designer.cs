namespace ZooRunner.GUI
{
    partial class Informations
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
            this._informationsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _informationsTextBox
            // 
            this._informationsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._informationsTextBox.Location = new System.Drawing.Point(0, 0);
            this._informationsTextBox.Multiline = true;
            this._informationsTextBox.Name = "_informationsTextBox";
            this._informationsTextBox.ReadOnly = true;
            this._informationsTextBox.Size = new System.Drawing.Size(150, 150);
            this._informationsTextBox.TabIndex = 0;
            // 
            // Informations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._informationsTextBox);
            this.Name = "Informations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _informationsTextBox;
    }
}
