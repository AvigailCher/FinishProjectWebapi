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
        var text = File.ReadAllText(_path);
        if (!string.IsNullOrEmpty(text))
        {
            list = JsonConvert.DeserializeObject<List<T>>(text);
        }
        return list;
    }
    public void Write(string path, T obj)
    {
        var list = Read(path);
        list.Add(obj);
        File.WriteAllText(_path, JsonConvert.SerializeObject(list));
    }
    
}

