namespace ClipboardManager
{
    partial class KeybindsPage
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel keybindsPanel;

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
            this.keybindsPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // keybindsPanel
            // 
            this.keybindsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keybindsPanel.AutoScroll = true;
            this.keybindsPanel.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.keybindsPanel.Name = "keybindsPanel";
            this.keybindsPanel.Size = new System.Drawing.Size(464, 360);
            // 
            // KeybindsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.keybindsPanel.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Controls.Add(this.keybindsPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "KeybindsPage";
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Size = new System.Drawing.Size(900, 600);
            this.ResumeLayout(false);
        }
    }
} 