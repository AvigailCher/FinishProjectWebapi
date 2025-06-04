using models;
namespace models;

public class CreditCard 
{
    
    public string cardNum { get; set; }
    public DateTime date { get; set; }
    public int threeNum { get; set; }
        

   
   public CreditCard(string cardNum,DateTime date,int threeNum)
   {
        this.cardNum=cardNum;
        this.date=date;
        this.threeNum=threeNum;


   }
}