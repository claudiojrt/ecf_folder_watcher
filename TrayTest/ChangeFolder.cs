using System;
using System.Windows.Forms;

namespace FolderWatcher
{
    public partial class FolderWatcherForm : Form
    {
        public string folder;

        public FolderWatcherForm(string folder)
        {
            InitializeComponent();
            this.folder = folder;
            caminho.Text = folder;
        }

        private void Confirmar_Click(object sender, EventArgs e)
        {
            folder = caminho.Text;
            ActiveForm.Close();
        }
    }
}
