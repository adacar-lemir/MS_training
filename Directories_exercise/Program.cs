﻿using System.IO;
using System.Collections.Generic;

//var salesFiles = FindFiles($"mslearn-dotnet-files{Path.DirectorySeparatorChar}stores");
var salesFiles = FindFiles(Path.Combine("mslearn-dotnet-files","stores"));

foreach (var file in salesFiles)
{
    Console.WriteLine(file);
}

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        // The file name will contain the full path, so onlycheck theend of it
        if (file.EndsWith("sales.json"))
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}
