using models;
namespace models;

public class Worker
{

    public string? Name { get; set; }  
    public string? LastName { get; set; }
    public int Id { get; set; }
   public int SumHours { get; set; }
   
   public Worker(string name,string lastName,int id,int sumHours){
         this.Name= name; 
         this.LastName= lastName;
         this.Id=id; 
         this.SumHours=sumHours;
   }
}