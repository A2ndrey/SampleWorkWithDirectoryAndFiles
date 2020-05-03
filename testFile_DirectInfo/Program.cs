using System;
using System.Collections.Generic;
using System.IO;

namespace testFile_DirectInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\AnDreW\source\repos\testFile_DirectInfo\testFile_DirectInfo\bin\Debug\netcoreapp2.1\test_directory";

            var fileList = new List<FileInfo>
            {
                new FileInfo(path + "\\directory1\\test1.txt"),
                new FileInfo(path + "\\directory2\\test2.mp3"),
                new FileInfo(path + "\\directory3\\test3.wav"),
                new FileInfo(path + "\\directory4\\test4.mp3"),
                new FileInfo(path + "\\directory4\\test41.mp3"),
                new FileInfo(path + "\\directory5\\test5.png")
            };

            var listDir = GetAlbums(fileList);

            foreach (DirectoryInfo currDir in listDir)
                Console.WriteLine(currDir.Name);

            //Console.WriteLine("Hello World!");
        }
        public static List<DirectoryInfo> GetAlbums(List<FileInfo> files)
        {
            var dir = new List<DirectoryInfo> { };
            //"test1.txt"  -> directory1
            //"test2.mp3"  -> directory2
            //"test3.wav"  -> directory3
            //"test4.mp3"  -> directory4
            //"test41.mp3" -> directory4
            //"test5.png"  -> directory5
            //
            // directory2, directory3, directory4

            foreach (FileInfo currFile in files)
                if (((currFile.Extension == ".mp3") || (currFile.Extension == ".wav"))
                              && (dir.Find(x => x.FullName == currFile.Directory.FullName) == null))
                    dir.Add(currFile.Directory);

            return dir;

        }
    }
}
