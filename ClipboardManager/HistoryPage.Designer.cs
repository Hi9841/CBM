namespace ClipboardManager
{
    partial class HistoryPage
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListView lvHistory;
        private System.Windows.Forms.ColumnHeader colImage;
        private System.Windows.Forms.ColumnHeader colSnippet;
        private System.Windows.Forms.ColumnHeader colTimestamp;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnCopy;

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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.colImage = new System.Windows.Forms.ColumnHeader();
            this.colSnippet = new System.Windows.Forms.ColumnHeader();
            this.colTimestamp = new System.Windows.Forms.ColumnHeader();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.Location = new System.Drawing.Point(16, 16);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(568, 27);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.PlaceholderText = "Search history...";
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            this.txtSearch.ForeColor = System.Drawing.Color.Gainsboro;
            // 
            // lvHistory
            // 
            this.lvHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvHistory.Columns.Clear();
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colImage,
                this.colSnippet,
                this.colTimestamp});
            this.lvHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lvHistory.FullRowSelect = true;
            this.lvHistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvHistory.HideSelection = false;
            this.lvHistory.BackColor = System.Drawing.Color.Black;
            this.lvHistory.ForeColor = System.Drawing.Color.Gainsboro;
            this.lvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvHistory.Columns[0].Width = 120;
            this.lvHistory.Location = new System.Drawing.Point(16, 56);
            this.lvHistory.Margin = new System.Windows.Forms.Padding(4);
            this.lvHistory.MultiSelect = false;
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.OwnerDraw = true;
            this.lvHistory.Size = new System.Drawing.Size(568, 280);
            this.lvHistory.TabIndex = 1;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            this.lvHistory.Scrollable = true;
            this.lvHistory.MinimumSize = new System.Drawing.Size(0, 120);
            // 
            // colImage
            // 
            this.colImage.Text = "";
            // 
            // colSnippet
            // 
            this.colSnippet.Text = "Snippet";
            // 
            // colTimestamp
            // 
            this.colTimestamp.Text = "Date/Time";
            // 
            // btnClearAll
            // 
            this.btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearAll.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClearAll.Location = new System.Drawing.Point(16, 360);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(120, 32);
            this.btnClearAll.TabIndex = 2;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            this.btnClearAll.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSelected.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDeleteSelected.Location = new System.Drawing.Point(464, 360);
            this.btnDeleteSelected.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(120, 32);
            this.btnDeleteSelected.TabIndex = 3;
            this.btnDeleteSelected.Text = "Delete Selected";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            this.btnDeleteSelected.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDeleteSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCopy.Location = new System.Drawing.Point(152, 360);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(120, 32);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            this.btnCopy.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            // 
            // HistoryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.lvHistory);
            this.Controls.Add(this.txtSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "HistoryPage";
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Size = new System.Drawing.Size(600, 400);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
} 