using System;
using static System.Console;
using System.IO;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace WorkingWithFileSystems {
    class Program {
        static void Main(string[] args) {
            // OutputFileSystemInfo();
            // WorkingWithDrives();
            // WorkingWithDirectories();
            WorkingWithFiles();
        }

        // Look at how paths are different depending on the Operating System
        static void OutputFileSystemInfo() {
            WriteLine("{0,-33} {1}", "Path.PathSeparator", PathSeparator);
            WriteLine("{0,-33} {1}", "Path.DirectorySeparatorChar", DirectorySeparatorChar);
            WriteLine("{0,-33} {1}", "Directory.GetCurrentDirectory()", GetCurrentDirectory());
            WriteLine("{0,-33} {1}", "Environment.SystemDirectory", SystemDirectory);
            WriteLine("{0,-33} {1}", "Path.GetTempPath()", GetTempPath());
            WriteLine("GetFolderPath(SpecialFolder");
            WriteLine("{0,-33} {1}", ".System)", GetFolderPath(SpecialFolder.System));
            WriteLine("{0,-33} {1}", ".ApplicationData)", GetFolderPath(SpecialFolder.ApplicationData));
            WriteLine("{0,-33} {1}", ".MyDocuments)", GetFolderPath(SpecialFolder.MyDocuments));
            WriteLine("{0,-33} {1}", ".Personal)", GetFolderPath(SpecialFolder.Personal));
        }

        // Look at how you can work with different drives
        static void WorkingWithDrives() {
            WriteLine("{0,-30} | {1, -10} | {2,-7} | {3,18} | {4, 8}",
                      "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");
            foreach (DriveInfo drive in DriveInfo.GetDrives()) {
                if (drive.IsReady) {
                    WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}",
                              drive.Name, drive.DriveType, drive.DriveFormat,
                              drive.TotalSize, drive.AvailableFreeSpace);
                } else {
                    WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
                }
            }
        }

        // Using Directory, Path, and Environment static classes - Directories
        static void WorkingWithDirectories() {
            // Directory path for a new folder, starting from the user's folder
            var newFolder = Combine(GetFolderPath(SpecialFolder.Personal), "CS_Projects", "MCPD",
                                    "Chapter09","NewFolder");
            WriteLine($"Working with: {newFolder}");
            // check if it exists
            WriteLine($"Does it exist? {Exists(newFolder)}");
            // create directory
            if (!Exists(newFolder)) {
                WriteLine("Creating it...");
                CreateDirectory(newFolder);
                WriteLine($"Does it exist? {Exists(newFolder)}");
            }
            Write("Confirm the directory exists, and then press ENTER: ");
            ReadLine();
            // delete directory
            WriteLine("Deleting it...");
            Delete(newFolder, recursive: true);
            WriteLine($"Does it exist? {Exists(newFolder)}");
        }

        // Files
        // Not statically importing 'Files' as some methods will conflict with System.IO.Directory
        static void WorkingWithFiles() {
            // define a directory path to ouput files, starting from the user's folder
            var dir = Combine(GetFolderPath(SpecialFolder.Personal), "CS_Projects", "MCPD", "Chapter09", "OutputFiles");
            CreateDirectory(dir);
            // define file paths
            string textFile = Combine(dir, "Dummy.txt");
            string backupFile = Combine(dir, "Dummy.bak");
            WriteLine($"Working with: {textFile}");
            WriteLine($"Does it exist? {File.Exists(textFile)}");
            // create a new text file and write a line to it
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello, C#!");
            textWriter.Close();
            WriteLine($"Does it exist? {File.Exists(textFile)}");
            // copy the file, and overwrite if it already exists
            File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);
            WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");
            Write("Confirm the files exist, and then press ENTER: ");
            ReadLine();
            // delete original text file (Dummy.txt)
            File.Delete(textFile);
            WriteLine($"Does it exist? {File.Exists(textFile)}");
            // read from the text file backup
            WriteLine($"Reading contents of {backupFile}");
            StreamReader textReader = File.OpenText(backupFile);
            WriteLine(textReader.ReadToEnd());
            textReader.Close();

            // Managing paths when working with files - methods that extract info from a filepath
            WriteLine($"Folder Name: {GetDirectoryName(textFile)}");
            WriteLine($"File Name: {GetFileName(textFile)}");
            WriteLine($"File Name without Extension: {GetFileNameWithoutExtension(textFile)}");
            WriteLine($"File Extension: {GetExtension(textFile)}");
            WriteLine($"Random File Name: {GetRandomFileName()}");
            WriteLine($"Temporary File Name: {GetTempFileName()}");

            // Getting info from files using FileInfo
            var info = new FileInfo(backupFile);
            WriteLine($"{backupFile}");
            WriteLine($"Contains {info.Length} bytes");
            WriteLine($"Last accessed {info.LastAccessTime}");
            WriteLine($"Has readonly set to {info.IsReadOnly}");
        }
    }
}
