// using pizza;

namespace models.Interface;
public interface OrderInter{
   public bool AddOrder(int customerId,DateTime date,int idOrder,CreditCard creditCard);
    Task CreatePizza();
}