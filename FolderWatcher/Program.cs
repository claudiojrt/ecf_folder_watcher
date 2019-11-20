using System;
using System.IO;
using System.Security.Permissions;
using System.Windows.Forms;

public class FolderWatcher
{
    public static void Main()
    {
        Run();
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public static void Run()
    {
        using (FileSystemWatcher watcher = new FileSystemWatcher())
        {
            Console.WriteLine("Path: ");
            watcher.Path = Console.ReadLine();

            // Filtra apenas alterações de escrita e nome de arquivo
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;

            watcher.Filter = "*.txt";

            watcher.IncludeSubdirectories = true;

            // Add event handlers.
            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnChanged;

            // Begin watching.
            watcher.EnableRaisingEvents = true;

            while (Console.ReadLine().ToLower() != "q") ;
        }
    }

    private static void OnChanged(object source, FileSystemEventArgs e) =>
        MessageBox.Show($"File: {e.FullPath} {e.ChangeType}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

}