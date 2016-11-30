namespace ZooRunner.GUI
{
    partial class CreateAnimals
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.animalsComboBox = new System.Windows.Forms.ComboBox();
            this.animalsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.animalsLabel = new System.Windows.Forms.Label();
            this.numberLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.animalsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(107, 97);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(201, 97);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 26);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(305, 51);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 20);
            this.button3.TabIndex = 6;
            this.button3.Text = "Add";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // animalsComboBox
            // 
            this.animalsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.animalsComboBox.FormattingEnabled = true;
            this.animalsComboBox.Location = new System.Drawing.Point(61, 51);
            this.animalsComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.animalsComboBox.Name = "animalsComboBox";
            this.animalsComboBox.Size = new System.Drawing.Size(92, 21);
            this.animalsComboBox.TabIndex = 7;
            // 
            // animalsNumericUpDown
            // 
            this.animalsNumericUpDown.Location = new System.Drawing.Point(211, 51);
            this.animalsNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.animalsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.animalsNumericUpDown.Name = "animalsNumericUpDown";
            this.animalsNumericUpDown.Size = new System.Drawing.Size(90, 20);
            this.animalsNumericUpDown.TabIndex = 8;
            this.animalsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // animalsLabel
            // 
            this.animalsLabel.AutoSize = true;
            this.animalsLabel.Location = new System.Drawing.Point(11, 54);
            this.animalsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.animalsLabel.Name = "animalsLabel";
            this.animalsLabel.Size = new System.Drawing.Size(49, 13);
            this.animalsLabel.TabIndex = 9;
            this.animalsLabel.Text = "Animals :";
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(157, 54);
            this.numberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(50, 13);
            this.numberLabel.TabIndex = 10;
            this.numberLabel.Text = "Number :";
            // 
            // CreateAnimals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 134);
            this.Controls.Add(this.animalsLabel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.numberLabel);
            this.Controls.Add(this.animalsComboBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.animalsNumericUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreateAnimals";
            this.Text = "Create Animals";
            this.Load += new System.EventHandler(this.CreateAnimals_Load);
            ((System.ComponentModel.ISupportInitialize)(this.animalsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox animalsComboBox;
        private System.Windows.Forms.NumericUpDown animalsNumericUpDown;
        private System.Windows.Forms.Label animalsLabel;
        private System.Windows.Forms.Label numberLabel;
    }
}