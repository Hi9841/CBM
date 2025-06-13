using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClipboardManager
{
    partial class KeybindCaptureDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblInstruction = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblInstruction.Location = new System.Drawing.Point(20, 20);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(200, 21);
            this.lblInstruction.TabIndex = 0;
            this.lblInstruction.Text = "Press any key combination...";
            this.lblInstruction.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.lblInstruction.ForeColor = System.Drawing.Color.Gainsboro;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Location = new System.Drawing.Point(85, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            this.btnCancel.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            // 
            // KeybindCaptureDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 110);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblInstruction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeybindCaptureDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Keybind";
            this.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
} 