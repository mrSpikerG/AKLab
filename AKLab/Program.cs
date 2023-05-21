
using AKLab;
using System.Diagnostics;
using System.IO;

var myArgs = Environment.GetCommandLineArgs();

Arguments arguments = new Arguments();


foreach (var item in myArgs) {
    if (item.Equals("-help")) {
        Console.WriteLine("\n==================================================================================================");
        Console.WriteLine("Parametrs \t\t\t Example \t\t\t\t description");
        Console.WriteLine("==================================================================================================");
        Console.WriteLine("-help  \t\t<AKLab.exe -help> \t\t\t\t(show this message)");
        Console.WriteLine("-pathFrom \t<AKLab.exe -pathFrom='C:\\Windows\\System32'> \t(first path to sync)");
        Console.WriteLine("-pathTo \t<AKLab.exe -pathTo='C:\\Windows\\System32'> \t(second path to sync)");
        Console.WriteLine("-type \t\t<AKLab.exe -type='exe'> \t\t\t(sync only one type of files)");

        return 0;
    }

    if (item.StartsWith("-pathFrom=")) {
        arguments.PathFrom = item.Substring(10, item.Length - 10);
    }

    if (item.StartsWith("-pathTo=")) {
        arguments.PathTo = item.Substring(8, item.Length - 8);
    }

    if (item.StartsWith("-type=")) {
        arguments.Type = item.Substring(6, item.Length - 6);
    }

    

}

Console.WriteLine($"{arguments.PathTo}\n{arguments.PathFrom}\n{arguments.Type}");

if (FolderController.SynchronizeFolders(arguments) == -1) {
    return -1;
}


return 0;

