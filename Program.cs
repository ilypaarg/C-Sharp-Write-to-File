using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.IO.FileSystem.AccessControl;

namespace FileWriting
{
    public class FileWriting
    {

        public static void Main(String[] args)
        {
            fileMaker();
            creation();
        }

        public static void fileMaker() // Creating a file with security.
        {
            try
            {
                string newFile = @"C:\Desktop\Creation.txt";
                FileSecurity fSecurity = new FileSecurity();
                fSecurity.AddAccessRule(new FileSystemAccessRule(@"add a domain name\add account name", FileSystemRights.ReadData, AccessControlType.Allow));

                using (FileStream fs = File.CreateText(newFile, 1024, FileOptions.WriteThrough, fSecurity))
                {
                    byte[] title = new UTF8Encoding(true).GetBytes("New Text File");
                    fs.Write(title, 0, title.Length);
                    byte[] creator = new UTF8Encoding(true).GetBytes("Your Name");
                    fs.Write(creator, 0, creator.Length);
                }

                Console.WriteLine("control for " + newFile + " added.");
                Console.WriteLine("Completed.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static async Task creation()
        {
            string write = "write anything into this file. this will be saved because it is the file we just created above.";

            await File.WriteAllLinesAsync("Creation.txt", write);
        }
    }
}
