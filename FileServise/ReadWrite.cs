using System.Net;
using System.Security.AccessControl;
using System.IO;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using FileService.Interfaces;

namespace FileService;


public class ReadWrite<T> : IFileService<T>
{
    private readonly string _path;
    public ReadWrite(string path)
    {
         _path = path;
    }
    public List<T> Read(string path)
    {
        var list = new List<T>();
        try
        {
            if (File.Exists(_path))
            {
                var text = File.ReadAllText(_path);
                if (!string.IsNullOrEmpty(text))
                {
                    list = JsonConvert.DeserializeObject<List<T>>(text) ?? new List<T>();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
            // Return empty list instead of crashing
        }
        return list;
    }
    public void Write(string path, T obj)
    {
        try
        {
            var list = Read(path);
            list.Add(obj);
            File.WriteAllText(_path, JsonConvert.SerializeObject(list));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing file: {ex.Message}");
            // Don't crash, just log the error
        }
    }
    
}

