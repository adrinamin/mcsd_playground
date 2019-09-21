using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace PerformIoOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            GetDriveInfo();
            GetDirectoryInfo();
            MovingDirectories();
            UsingLists();
            WritingIntoFile();
        }

        // A DriveInfo object doesn’t have any specific
        // methods for dealing with drives (for example, there is not an eject method for a CD player).
        // It does have several properties to access information such as the name of the drive, size, and
        // available free space.
        private static void GetDriveInfo()
        {
            DriveInfo[] drivesInfo = DriveInfo.GetDrives();
            foreach (var driveInfo in drivesInfo)
            {
                Console.WriteLine("Drive {0}", driveInfo.Name);
                Console.WriteLine("File type: {0}", driveInfo.DriveType);
            }
        }

        // You can use both classes, Directory (static) and DirecotryInfo to create a new folder. When you create a new folder, you automatically
        // have both read and write rights to the folder.
        // When creating folder in areas where you have no permission,
        // you get UnauthorizedAccessException.
        // You can also remove a folder, but trying to remove a folder that doesn’t exist throws
        // DirectoryNotFoundException. You can use the Exists method on the static Directory class or
        // the Exists property on the DirectoryInfo object to determine whether a folder exists
        private static void GetDirectoryInfo()
        {
            // Create directory
            var directory = Directory.CreateDirectory(@"\ProgrammingInCSharp\Directory");
            var directoryInfo = new DirectoryInfo(@"\ProgrammingInCSharp\DirectoryInfo");
            directoryInfo.Create();

            // Delete directory
            if (Directory.Exists(@"\ProgrammingInCSharp\Directory"))
            {
                Debug.WriteLine("\n " + DateTime.Now + ", Deleting directory", "Info");
                Directory.Delete(@"\ProgrammingInCSharp\Directory");
            }

            if (directoryInfo.Exists)
            {
                Debug.WriteLine("\n " + DateTime.Now + ", Deleting directory " + directory.Name, "Info");
                directoryInfo.Delete();
            }
        }

        // Another method that can come in handy is the method MoveTo on DirectoryInfo or Move
        // on Directory classes when you want to move an existing directory to a new location.
        private static void MovingDirectories()
        {
            var stringBuilder = new StringBuilder();
            // Moving a directory
            if (Directory.Exists(@"\source"))
            {
                Debug.WriteLine("Move directory to another location", "Info");
                Directory.Move(@"\source", @"\destination");
            }
            else
            {
                Debug.WriteLine(stringBuilder.Append(DateTime.Now + ", Could not move directory"), "Warning");
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(@"\Source");
            if (directoryInfo.Exists)
            {
                Debug.WriteLine("Move directory to another location", "Info");
                directoryInfo.MoveTo(@"c:\destination");
            }
            else
            {
                Debug.WriteLine(stringBuilder.Append(DateTime.Now + ", Could not move direcory " + directoryInfo), "Warning");
            }
        }

        private static void WritingIntoFile()
        {
            var stringBuilder = new StringBuilder();
            const string path = @"\programming\data";
            const string fileName = "storage.txt";
            var directory = new DirectoryInfo(path);
            directory.Create();
            Debug.WriteLine(stringBuilder.Append(DateTime.Now + ": Creating directoy " + directory + "\n "), "Info");
            string fullPath = Path.Combine(path, fileName);
            var fileInfo = new FileInfo(fullPath);
            if (!fileInfo.Exists)
            {
                using (var streamWriter = File.CreateText(fullPath))
                {
                    const string value = "Hello my name is....";
                    Debug.WriteLine(stringBuilder.Append(DateTime.Now + ": Writing stream " + value + " into file " + fileName + "\n "), "Info");
                    streamWriter.WriteLine(value);
                    Debug.WriteLine(stringBuilder.Append(DateTime.Now + ": Close the current StreamWriter object" + "\n "), "Info");
                    streamWriter.Close();
                }
            }
            else
            {
                Debug.WriteLine(stringBuilder.Append(DateTime.Now + ": File already exists." + "\n "), "Info");
            }

            ReadingFromFile(fullPath);
        }

        private static void ReadingFromFile(string path)
        {
            var stringBuilder = new StringBuilder();
            using (StreamReader streamReader = new StreamReader(path))
            {
                string data = string.Empty;
                while ((data = streamReader.ReadLine()) != null)
                {
                    Debug.WriteLine(stringBuilder.Append(DateTime.Now + ": StreamReader output: " + "\n "), "Info");
                    Debug.WriteLine(stringBuilder.Append(DateTime.Now + ": " + data + "\n "), "Info");
                }
                streamReader.Close();
            }
        }

        private static void UsingLists()
        {
            var stringBuilder = new StringBuilder();
            List<int> list = new List<int>{
              30,
              40,
              30,
              20,
              80,
              70,
              70,
              60,
              50
            };

            var result = from i in list where i > 60 select i;

            Debug.WriteLine(stringBuilder.Append(" " + DateTime.Now + " These are the elements that match the condition:"), "Info");
            foreach (var item in result)
            {
                Debug.WriteLine(stringBuilder.Append("\n " + DateTime.Now + ", Number: " + item.ToString()), "Info");
            }
        }
    }
}
