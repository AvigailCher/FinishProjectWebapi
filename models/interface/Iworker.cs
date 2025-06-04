namespace models.Interface;
public interface Iworker{
   public string GetById(int id);
   public bool Post(string name,string lastName,int id,int sumHours);
   public int SumId(int id,int sumHours);
}