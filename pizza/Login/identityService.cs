
using FileService;
using FileService.Interfaces;
using models;
namespace Login.identity;
public class identityService
{

    IFileService<Worker> _file;
    public identityService(IFileService<Worker> f){
        _file=f;
    }
    public identityService(){
        
    }
    
    public bool isExist(string name,int id)
    {   
        var WorkerList=_file.Read(@"pizza\worker.json");
        foreach(var w in WorkerList)
        {
            if(w.Name==name)
                if(w.Id==id)
                    return true;
                else
                    return false;
        }
        return false;
    }
}