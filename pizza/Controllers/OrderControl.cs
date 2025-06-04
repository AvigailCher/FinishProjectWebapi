using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using models;
using models.Interface;
using System.ComponentModel.DataAnnotations;
namespace pizza.Controllers;

public class OrderControl : baseControllers
{
    OrderInter _Order;
    public OrderControl(OrderInter Order)
    {
        _Order = Order;
    }

    [Route("[action]/{customerId}/{date}/{idOrder}")]
    [HttpPost]
    public IActionResult AddOrder(int customerId, DateTime date, int idOrder,CreditCard creditCard)
    {
        _Order.AddOrder(customerId, date, idOrder, creditCard);
        return Ok("new order");
    }
    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> CreatePizza()
    {
    //    var create = await _Order.CreatePizza();
    //    if(create)
    //         return Ok();
    //    return NotFound();     

     await _Order.CreatePizza();
     return Ok();
       
    }

    
        
}

