using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4._1
{
    public enum TypeWork
    {
        None,
        Revert,
        Watch
    }
    class Program
    {
        static int id = 0;
        static void Main(string[] args)
        {
            string path = GetWatchingFolder();
            CreateBackupFolder();
            Watching(path);
            //PrintWorkMenu(SelectTypeOfWork());
            //Console.WriteLine(path);
            //Console.WriteLine(GetDateTime());
            //Watching(path);
        }

        public static List<string> GetAllDirectoryPaths(string pathMainDirectory)
        {
            List<string> directoryPaths = new List<string>();

            DirectoryInfo mainDirectory = new DirectoryInfo(pathMainDirectory);
            DirectoryInfo[] directoryInfos =  mainDirectory.GetDirectories();
            if(directoryInfos.Length != 0)
            {
                foreach (var item in directoryInfos)
                {
                    string internalDirectoryPath = Path.Combine(pathMainDirectory, $@"{item}\");
                    directoryPaths.Add(internalDirectoryPath);
                    foreach(var internalItem in GetAllDirectoryPaths(internalDirectoryPath))
                    {
                        directoryPaths.Add(internalItem);
                    }
                }
            }

            return directoryPaths;
        }

        public static void Watching(string path)
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                Console.WriteLine($"Wathcing: {path}");
                watcher.Path = path;

                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                watcher.Filter = "*.*";

                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                watcher.IncludeSubdirectories = true;

                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
        }

        public static int InsertIntRange(int min, int max)
        {
            int result;
            bool flag = false;
            Console.Write("Your select: ");
            do
            {
                flag = Int32.TryParse(Console.ReadLine(), out result);

                if (!flag || result < min || result > max)
                {
                    Console.WriteLine("Incorrect insert\n");
                    Console.WriteLine("Try one more time");
                    flag = false;
                }

            } while (!flag);
            Console.WriteLine();
            return result;
        }

        public static string GetCorrectPath()
        {
            Console.WriteLine("Insert your path");
            bool flag = false;
            string path;
            do
            {
                path = $@"{Console.ReadLine()}";
                if (Directory.Exists(path))
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Try one more time");
                }
            } while (!flag);
            Console.WriteLine("All correct!");
            Console.WriteLine("Press any key for continue!");
            Console.ReadKey();
            Console.Clear();
            return path;
        }

        public static string GetWatchingFolder()
        {
            Console.WriteLine("Which folder you want to watch?");
            Console.WriteLine("1) Default");
            Console.WriteLine("2) Your folder");
            switch (InsertIntRange(1, 2))
            {
                case 1:
                    string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, @"ExampleFolder\");
                    
                    if (!File.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    return path;
                case 2:
                    return GetCorrectPath();
                default:
                    throw new Exception("Incorrect input");
            }
        }

        public static TypeWork SelectTypeOfWork()
        {
            Console.WriteLine("Which type of work you want to select?");
            Console.WriteLine("1) Revert");
            Console.WriteLine("2) Watch");
            switch (InsertIntRange(1, 2))
            {
                case 1:
                    return TypeWork.Revert;
                case 2:
                    return TypeWork.Watch;
                default:
                    throw new Exception("Incorrect input");
            }
        }

        public static void PrintWorkMenu(TypeWork type)
        {
            Console.Clear();
            if(type == TypeWork.Revert)
            {
                Console.WriteLine("Your select type: Revert");
            }
            else
            {
                Console.WriteLine("Your select type: Watch");
            }
        }

        public static DateTime GetDateTime()
        {
            Console.WriteLine("Now u need to insert datetime for revert");
            bool flag = false;
            DateTime dateTime;
            Console.WriteLine("Insert Datetime for revert:");
            do
            {
                flag = DateTime.TryParse(Console.ReadLine(), out dateTime);
                if (!flag)
                {
                    Console.WriteLine("Try one more time");
                }
            } while (!flag);
            return dateTime;
        }

        public static void CreateBackupFolder()
        {
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, @"BackUpFolder\");
            if (!File.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void CreateBackup(string nameFolder, string mainPath)
        {
            string pathToBackup = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, @"BackUpFolder");
            if (!Directory.Exists(pathToBackup))
            {
                throw new Exception("Backup Folder does not exist");
            }
            else
            {
                string dateTimeNowCorrect = DateTime.Now.ToString("s");
                DirectoryCopy(mainPath, $@"{pathToBackup}\{nameFolder}\{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss.fff")}", true);
            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
            string mainDir = e.FullPath.Substring(0, e.FullPath.Length - e.Name.Length);
            string nameDirForBackup = mainDir.Substring(0, mainDir.Length - 1);
            nameDirForBackup = nameDirForBackup.Substring(nameDirForBackup.LastIndexOf('\\') + 1);
            CreateBackup(nameDirForBackup, mainDir);
            
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
        }
    }
}
