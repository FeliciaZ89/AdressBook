using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook.Services;


public class FileService : IFileService
{
    private readonly string _filePath;

    public FileService()
    {
    }

    public FileService(string filePath)
    {
        _filePath = filePath;
    }

    public bool SaveContentToFile(string filePath, string content1)
    {
        try
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(content1);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    public string GetContentFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }
}

