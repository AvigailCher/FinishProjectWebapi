 namespace FileService.Interfaces;
  public interface IFileService<T>
  {
    List<T> Read(string path);
    void Write(string path, T obj);
  }

