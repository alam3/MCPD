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
            WorkingWithDirectories();
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

        // Using Directory, Path, and Environment static classes
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
    }
}
