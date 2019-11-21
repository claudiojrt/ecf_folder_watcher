using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Security.Permissions;

namespace FolderWatcher
{
    public class SysTrayApp : Form
    {
        FileSystemWatcher watcher;
        NotifyIcon trayIcon;
        ContextMenu trayMenu;

        string folder;

        [STAThread]
        public static void Main()
        {
            Application.Run(new SysTrayApp());
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
 
            base.OnLoad(e);
        }

        private SysTrayApp()
        {
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Change Folder", OnChangeFolder);
            trayMenu.MenuItems.Add("Exit", OnExit);

            trayIcon = new NotifyIcon
            {
                Text = ".ecf Folder Watcher",
                Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location),
                ContextMenu = trayMenu,
                Visible = true
            };

            watcher = new FileSystemWatcher();

            folder = Preferences.GetPreference("Folder").ToString();

            if (string.IsNullOrEmpty(folder))
            {
                ChangeFolder();

                //Se na inicialização não informar pasta, não faz nada
                if (string.IsNullOrEmpty(folder))
                {
                    return;
                }
            }

            Run();
        }

        private void OnChangeFolder(object sender, EventArgs e)
        {
            watcher.EnableRaisingEvents = false;

            ChangeFolder();
            
            Run();
        }

        private void ChangeFolder()
        {
            FolderWatcherForm form = new FolderWatcherForm(folder);
            form.ShowDialog();

            if (Directory.Exists(form.folder))
            {
                folder = form.folder;
                Preferences.SetPreference("Folder", folder);
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }
 
        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                watcher.Dispose();
                trayIcon.Dispose();
                trayMenu.Dispose();
            }
 
            base.Dispose(isDisposing);
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private void Run()
        {
            if (!string.IsNullOrEmpty(folder))
            {
                watcher.Path = folder;

                watcher.NotifyFilter = NotifyFilters.Size | NotifyFilters.FileName;

                watcher.Filter = "*.ecf";

                watcher.IncludeSubdirectories = true;

                watcher.Changed += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnChanged;

                watcher.EnableRaisingEvents = true;
            }
        }

       private void OnChanged(object source, FileSystemEventArgs e)
        {
            try
            {
                watcher.EnableRaisingEvents = false;
                MessageBox.Show($"File: {e.FullPath} {e.ChangeType}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            finally
            {
                watcher.EnableRaisingEvents = true;
            }
        }
    }
}