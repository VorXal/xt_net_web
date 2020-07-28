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
        static void Main(string[] args)
        {
            Start();
        }

        public static void Start()
        {
            Console.Clear();
            CreateBackupFolder();
            TypeWork type = SelectTypeOfWork();
            string path = GetFolder(type);
            if(type == TypeWork.Watch)
            {
                Watching(path);
            }
            else
            {
                Revert(path);
            }

        }


        private static void Watching(string path)
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

                Console.WriteLine("Press 'q' to quit and go to main menu");
                while (Console.ReadLine() != "q") ;
                Start();
            }
            
        }

        private static void Revert(string path)
        {
            string nameDir = path.Substring(0, path.Length);
            nameDir = nameDir.Substring(nameDir.LastIndexOf('\\') + 1);
            string pathBackupFolder = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, @"BackUpFolder\");
            foreach(var item in Directory.GetDirectories(pathBackupFolder))
            {
                if(item.Substring(item.LastIndexOf('\\') + 1) == nameDir)
                {
                    string dateTimeOfRevert = SelectRevert(Path.Combine(pathBackupFolder, $@"{nameDir}\"));
                    string pathToRevert = Path.Combine(Path.Combine(pathBackupFolder, $@"{nameDir}\"), dateTimeOfRevert);
                    DirectoryInfo dir = new DirectoryInfo(path);
                    dir.Delete(true);
                    DirectoryCopy(pathToRevert, path, true);
                    Console.WriteLine("Done!");
                }
            }
            Console.WriteLine("Press any key for go to main menu");
            Console.ReadLine();
            Start();
        }
        
        private static string SelectRevert(string path)
        {
            int id = 0;
            Console.WriteLine("Input id of DateTime to revert for this DateTime");
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach(var item in Directory.GetDirectories(path))
            {

                dict.Add(id, item.Substring(item.LastIndexOf('\\') + 1));
                Console.WriteLine($"ID: {id}, DateTime: {item.Substring(item.LastIndexOf('\\') + 1)}");
                id++;
            }
            int select = InsertIntRange(0, dict.Keys.Count - 1);
            return dict[select];
        }

        private static int InsertIntRange(int min, int max)
        {
            int result;
            bool flag = false;
            Console.Write("Your select: ");
            do
            {
                flag = int.TryParse(Console.ReadLine(), out result);

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

        private static string GetCorrectPath()
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

        private static string GetFolder(TypeWork type)
        {
            Console.WriteLine($"Which folder you want to {type.ToString().ToLower()}?");
            Console.WriteLine("1) Default (ExampleFolder in project)");
            Console.WriteLine("2) Your folder");
            switch (InsertIntRange(1, 2))
            {
                case 1:
                    string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, @"ExampleFolder");
                    
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

        private static TypeWork SelectTypeOfWork()
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


        private static void CreateBackupFolder()
        {
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, @"BackUpFolder\");
            if (!File.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private static void CreateBackup(string nameFolder, string mainPath)
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
