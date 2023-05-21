using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKLab {
    internal class FolderController {
        public static int SynchronizeFolders(Arguments args) {
            if (!Directory.Exists(args.PathFrom) || !Directory.Exists(args.PathTo)) {
                Console.WriteLine("Source folder or destination folder does not exist.");
                return -1;
            }
            DirectoryInfo sourceDirectory = new DirectoryInfo(args.PathFrom);
            DirectoryInfo destinationDirectory = new DirectoryInfo(args.PathTo);

            CopyTo(sourceDirectory, destinationDirectory,args.Type);
            CopyTo(destinationDirectory, sourceDirectory, args.Type);
            return 0;
        }

        private static void CopyTo(DirectoryInfo sourceDirectory, DirectoryInfo destinationDirectory,string type) {
            string filter = type.Equals("not set") ? "*" : $"*.{type}";
            foreach (FileInfo sourceFile in sourceDirectory.GetFiles(filter)) {
                string destinationFilePath = Path.Combine(destinationDirectory.FullName, sourceFile.Name);
                
                
                if (File.Exists(destinationFilePath)) {
                    
                    FileInfo destinationFile = new FileInfo(destinationFilePath);
                    

                    if (sourceFile.LastWriteTime > destinationFile.LastWriteTime) {
                        Console.WriteLine($"Copying updated file: {sourceFile.FullName}");
                        sourceFile.CopyTo(destinationFilePath, true);
                    }
                } else {
                    Console.WriteLine($"Copying new file: {sourceFile.FullName}");
                    sourceFile.CopyTo(destinationFilePath);
                }
            }

        }


    }
}
