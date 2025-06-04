// using Microsoft.AspNetCore.Mvc;
using models;
using FileService;
using FileService.Interfaces;
using models.Interface;
namespace ServiceCL;
public class WorkerService:Iworker
{
    // List<WorkerModels> WorkerList = new List<WorkerModels>(){
    
    //   new WorkerModels("shifi","horovitz",328128269,20),
     
    // };
    private Iworker? _w;
    IFileService<Worker> _file;

    public WorkerService(IFileService<Worker> f)
    {
      _file=f;
    }    
    public string GetById(int id)
    {
        var WorkerList=_file.Read(@"pizza\worker.json");

        foreach (Worker p in WorkerList)
            if (p.Id == id) return "the name of worker is: " + p.Name;
        return null;
    }

    public bool Post(string name,string lastName,int id,int sumHours)
    {
         var WorkerList=_file.Read(@"pizza\worker.json");
        Worker worker=new Worker(name, lastName, id, sumHours);
        WorkerList.Add(worker);
        _file.Write(@"pizza\worker.json",worker);
        if (this.GetById(id) != null)
            return true;
        return false;
    }
       public int SumId(int id,int sumHours){
            var WorkerList=_file.Read(@"pizza\worker.json");
            foreach (var i in WorkerList)
              if (i.Id == id)
                return i.SumHours;

            return -1;
       }
       
}