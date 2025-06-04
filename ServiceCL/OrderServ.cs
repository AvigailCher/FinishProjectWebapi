// using Microsoft.AspNetCore.Mvc;
// using pizza;
using models;
using FileService;
using models.Interface;
namespace ServiceCL;
public class OrderServ : OrderInter
{
    // private readonly IFileService<string> _file;
    // public OrderModel(IFileService<string> file)
    // {
    //     _file=file;
    // }
    // CreditCard cc=new CreditCard("1234 4567 7854 9654",new DateTime(2024, 2, 10),123);

    List<OrderModel> orderList = new List<OrderModel>
    {
        new OrderModel(0547,DateTime.Now,123456,
        new CreditCard("1234 4567 7854 9654",new DateTime(2024, 2, 10),123)),
        new OrderModel(548,DateTime.Now,32872782,new CreditCard("1234 4567 7854 9654",new DateTime(2024, 2, 10),123)),
        new OrderModel(854,DateTime.Now,5522852,new CreditCard("1234 4567 7123 9654",new DateTime(2024, 2, 10),123)),
        new OrderModel(7522,DateTime.Now,788,new CreditCard("1234 4712 7854 9654",new DateTime(2024, 2, 10),123)),
        new OrderModel(7225,DateTime.Now,28727832,new CreditCard("1234 4567 5421 9654",new DateTime(2024, 2, 10),123))
    };

    public bool AddOrder(int customerId, DateTime date, int idOrder, CreditCard creditCard)
    {
        orderList.Add(new OrderModel(customerId, date, idOrder, creditCard));
        return true;
    }

    public async Task<bool> Pay(CreditCard creditCard)
    {

        Console.WriteLine("check the details");
        await Task.Delay(5000);
        if (creditCard.threeNum < 100)
            return false;
        return true;

    }
    public async Task CreatePizza()
    {
        Console.WriteLine("התחלנו להכין את הבצק");
        await Task.Delay(4000);
        Console.WriteLine("הבצק מוכן");
        await Task.Delay(4000);
        Console.WriteLine("הפיצה בשלבי סיום");
        await Task.Delay(4000);
        Console.WriteLine(" הפיצה בתנור");
        await Task.Delay(4000);
        Console.WriteLine("הפיצה מוכנה!!!!!");

        
    }

    public void TxtMail(PizzaTata p, CreditCard creditCard)
    {
        string invoiceDetails=GenerateOrderContent(p,creditCard);
        string path=@"pizza\mail\invoice.txt";
        File.WriteAllText(path,invoiceDetails);
    }

    private string GenerateOrderContent(PizzaTata pizza, CreditCard creditCard)
    {
        return $@"
            Order Details:
            Pizza: {pizza.Name}
            Gluten: {pizza.IsGlutan}
            Id: {pizza.Id}

            Payment Details:
            Card Number: **** **** **** {creditCard.cardNum[^4..]}  // רק 4 ספרות אחרונות
            Date: {creditCard.date}


            Date: {DateTime.Now}
            Thank you for your order!
";
    }
}

