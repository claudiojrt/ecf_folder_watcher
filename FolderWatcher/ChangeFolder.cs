using System;
using System.ComponentModel;
using System.IO;
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
            Caminho.Text = folder;
        }

        private void Confirmar_Click(object sender, EventArgs e)
        {
            folder = Caminho.Text;
            ActiveForm.Close();
        }

        private void Caminho_Leave(object sender, EventArgs e)
        {
            if (!Directory.Exists(Caminho.Text))
            {
                Caminho.Select(0, Caminho.Text.Length);
                Caminho.Focus();

                MessageBox.Show("Caminho inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bHandled = false;

            switch (keyData)
            {
                case Keys.F5:

                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        folder = folderDialog.SelectedPath;
                        Caminho.Text = folder;
                    }

                    bHandled = true;

                    break;
            }
            return bHandled;
        }
    }
}
