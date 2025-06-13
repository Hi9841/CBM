using System;
using System.Windows.Forms;

namespace ClipboardManager
{
    public partial class SettingsForm : Form
    {
        public Keys SelectedKey { get; private set; } = Keys.Control | Keys.P;
        public SettingsForm()
        {
            InitializeComponent();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void txtHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            SelectedKey = e.KeyData;
            txtHotkey.Text = e.KeyData.ToString();
            e.SuppressKeyPress = true;
        }
    }
} 