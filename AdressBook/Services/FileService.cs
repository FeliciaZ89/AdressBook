using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook.Services;

public interface IFileService
{
    bool SaveContentToFile(string content, string json);
    string GetContentFromFile(string _filePath);
}

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

    public string GetContentFromFile(string _filePath)
    {
        try
        {
            if (File.Exists(_filePath))
            {
                return File.ReadAllText(_filePath);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

    public bool SaveContentToFile(string filePath, string content)
    {
        try
        {
            File.WriteAllText(_filePath, content);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }
}