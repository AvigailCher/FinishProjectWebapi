using models;
using System.ComponentModel.DataAnnotations;

namespace models;

public class PizzaTata
{
    [Required]
    [StringLength(50, ErrorMessage = "שם הפיצה לא יכול להיות יותר מ-50 תווים")]
    public string Name { get; set; }  
    
    public bool IsGlutan { get; set; }
    
    [Range(1, 1000, ErrorMessage = "ID חייב להיות בין 1 ל-1000")]
    public int Id { get; set; }
   
   public PizzaTata(string name,bool isGlutan,int id){
         this.Name= name; 
         this.IsGlutan=isGlutan ;
         this.Id=id; 
   


   }
}