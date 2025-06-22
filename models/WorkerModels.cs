using models;
using System.ComponentModel.DataAnnotations;

namespace models;

public class Worker
{
    [Required]
    [StringLength(50, ErrorMessage = "שם העובד לא יכול להיות יותר מ-50 תווים")]
    public string? Name { get; set; }  
    
    [Required]
    [StringLength(50, ErrorMessage = "שם משפחה לא יכול להיות יותר מ-50 תווים")]
    public string? LastName { get; set; }
    
    [Range(1, 10000, ErrorMessage = "ID חייב להיות בין 1 ל-10000")]
    public int Id { get; set; }
    
    [Range(0, 200, ErrorMessage = "מספר שעות חייב להיות בין 0 ל-200")]
    public int SumHours { get; set; }
   
   public Worker(string name,string lastName,int id,int sumHours){
         this.Name= name; 
         this.LastName= lastName;
         this.Id=id; 
         this.SumHours=sumHours;
   }
}