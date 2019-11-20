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
        NotifyIcon  trayIcon;
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
            Run(folder);
        }

        private void OnChangeFolder(object sender, EventArgs e)
        {
            watcher.EnableRaisingEvents = false;

            FolderWatcherForm form = new FolderWatcherForm(folder);
            form.ShowDialog();

            folder = form.folder;
            
            Run(form.folder);
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
        private void Run(object data)
        {
            if (Directory.Exists(data.ToString()))
            {
                watcher.Path = data.ToString();
            }
            else
            {
                folder = @"P:\Cigam11\Projects\Compras\Cab";
                watcher.Path = folder;
            }

            watcher.NotifyFilter = NotifyFilters.Size | NotifyFilters.FileName;

            watcher.Filter = "*.ecf";

            watcher.IncludeSubdirectories = true;

            watcher.Changed += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnChanged;

            watcher.EnableRaisingEvents = true;
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