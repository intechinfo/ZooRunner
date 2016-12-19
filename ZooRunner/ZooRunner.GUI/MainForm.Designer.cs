using System.Collections.Generic;

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
            this._informations = new ZooRunner.GUI.Informations();
            this._zooViewPortControl = new ZooRunner.ZooViewPortControl();
            this._controlPanel = new ZooRunner.GUI.ControlPanel();
            this.SuspendLayout();
            // 
            // _informations
            // 
            this._informations.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._informations.Location = new System.Drawing.Point(935, 505);
            this._informations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._informations.Name = "_informations";
            this._informations.Size = new System.Drawing.Size(284, 127);
            this._informations.TabIndex = 6;
            // 
            // _zooViewPortControl
            // 
            this._zooViewPortControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._zooViewPortControl.AnimalsRepresentation = null;
            this._zooViewPortControl.BackColor = System.Drawing.SystemColors.Control;
            this._zooViewPortControl.BoxCount = 20;
            this._zooViewPortControl.Enabled = false;
            this._zooViewPortControl.Location = new System.Drawing.Point(11, 10);
            this._zooViewPortControl.Name = "_zooViewPortControl";
            this._zooViewPortControl.ShowGridLines = false;
            this._zooViewPortControl.Size = new System.Drawing.Size(1208, 492);
            this._zooViewPortControl.TabIndex = 5;
            this._zooViewPortControl.Text = "zooViewPortControl";
            this._zooViewPortControl.MouseLeaveControl += new System.EventHandler(this.OnMouseLeaveControl);
            this._zooViewPortControl.AreaChanged += new System.EventHandler<string>(this.OnAreaChanged);
            // 
            // _controlPanel
            // 
            this._controlPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._controlPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this._controlPanel.Location = new System.Drawing.Point(11, 507);
            this._controlPanel.Margin = new System.Windows.Forms.Padding(2);
            this._controlPanel.Name = "_controlPanel";
            this._controlPanel.Size = new System.Drawing.Size(918, 127);
            this._controlPanel.TabIndex = 4;
            this._controlPanel.UserGivesDll += new System.EventHandler<ZooRunner.ZooAdapter>(this.OnUserGivesDll);
            this._controlPanel.TimerTick += new System.EventHandler<System.Collections.Generic.List<ZooRunner.AnimalAdapter>>(this.OnTimerTick);
            this._controlPanel.BoxCountChange += new System.EventHandler<int>(this.OnBoxCountChange);
            this._controlPanel.ShowGridLines += new System.EventHandler<bool>(this.OnShowGridLines);
            this._controlPanel.AnimalsRederingChange += new System.EventHandler<ZooRunner.GUI.AnimalsRedering>(this.OnAnimalsRederingChange);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1232, 645);
            this.Controls.Add(this._informations);
            this.Controls.Add(this._zooViewPortControl);
            this.Controls.Add(this._controlPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1250, 692);
            this.Name = "MainForm";
            this.Text = "ZooRunner";
            this.ResumeLayout(false);

        }

        #endregion
        private ControlPanel _controlPanel;
        private ZooViewPortControl _zooViewPortControl;
        private Informations _informations;
    }
}

