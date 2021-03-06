﻿namespace FolderWatcher
{
    partial class FolderWatcherForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderWatcherForm));
            this.label1 = new System.Windows.Forms.Label();
            this.Caminho = new System.Windows.Forms.TextBox();
            this.Confirmar = new System.Windows.Forms.Button();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Caminho";
            // 
            // Caminho
            // 
            this.Caminho.Location = new System.Drawing.Point(64, 10);
            this.Caminho.MaxLength = 500;
            this.Caminho.Name = "Caminho";
            this.Caminho.Size = new System.Drawing.Size(410, 20);
            this.Caminho.TabIndex = 1;
            this.Caminho.Tag = "Caminho";
            this.Caminho.Leave += new System.EventHandler(this.Caminho_Leave);
            // 
            // Confirmar
            // 
            this.Confirmar.Location = new System.Drawing.Point(368, 39);
            this.Confirmar.Name = "Confirmar";
            this.Confirmar.Size = new System.Drawing.Size(106, 23);
            this.Confirmar.TabIndex = 2;
            this.Confirmar.Text = "Confirmar";
            this.Confirmar.UseVisualStyleBackColor = true;
            this.Confirmar.Click += new System.EventHandler(this.Confirmar_Click);
            // 
            // folderDialog
            // 
            this.folderDialog.Description = "Selecione o caminho";
            this.folderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderDialog.ShowNewFolderButton = false;
            // 
            // FolderWatcherForm
            // 
            this.AcceptButton = this.Confirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 71);
            this.Controls.Add(this.Confirmar);
            this.Controls.Add(this.Caminho);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FolderWatcherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".ecf Folder Watcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Caminho;
        private System.Windows.Forms.Button Confirmar;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
    }
}

