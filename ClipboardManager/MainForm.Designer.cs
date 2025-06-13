namespace ClipboardManager
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnKeybinds;
        private System.Windows.Forms.Panel bottomNavPanel;

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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnKeybinds = new System.Windows.Forms.Button();
            this.bottomNavPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            
            // 
            // contentPanel
            // 
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.TabIndex = 0;
            
            // 
            // bottomNavPanel
            // 
            this.bottomNavPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomNavPanel.Height = 48;
            this.bottomNavPanel.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            this.bottomNavPanel.Name = "bottomNavPanel";
            this.bottomNavPanel.TabIndex = 1;
            this.bottomNavPanel.Controls.Add(this.btnKeybinds);
            this.bottomNavPanel.Controls.Add(this.btnHistory);
            
            // 
            // btnHistory
            // 
            this.btnHistory.Text = "History";
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHistory.Width = 100;
            this.btnHistory.TabIndex = 2;
            this.btnHistory.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            this.btnHistory.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            
            // 
            // btnKeybinds
            // 
            this.btnKeybinds.Text = "Keybinds";
            this.btnKeybinds.Name = "btnKeybinds";
            this.btnKeybinds.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnKeybinds.Width = 100;
            this.btnKeybinds.TabIndex = 3;
            this.btnKeybinds.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            this.btnKeybinds.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnKeybinds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeybinds.Font = new System.Drawing.Font("Segoe UI", 10F);
            
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.bottomNavPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clipboard Manager";
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.ResumeLayout(false);
        }
    }
} 