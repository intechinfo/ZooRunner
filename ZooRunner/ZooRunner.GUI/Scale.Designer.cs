namespace ZooRunner.GUI
{
    partial class Scale
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
            this.SuspendLayout();
            // 
            // Scale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Enabled = false;
            this.Name = "Scale";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(1208, 100);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.scale_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
