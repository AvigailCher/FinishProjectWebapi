using models;
namespace models;

public class PizzaTata
{

    public string Name { get; set; }  
    public bool IsGlutan { get; set; }
    public int Id { get; set; }
   
   public PizzaTata(string name,bool isGlutan,int id){
         this.Name= name; 
         this.IsGlutan=isGlutan ;
         this.Id=id; 
   


   }
}