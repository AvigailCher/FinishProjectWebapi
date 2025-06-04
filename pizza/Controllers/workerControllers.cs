using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Collections.Generic;
using models;
using models.Interface;
using FileService.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace pizza.Controllers;



public class workerControllers: baseControllers
{
    Iworker _worker;
    public workerControllers(Iworker worker)
    {
        _worker = worker;
    }
    [Route("[action]/{id}")]
    [HttpGet]
    [Authorize(Policy="Admin")]
    public IActionResult GetById(int id)
    {
        var Worker = _worker.GetById(id);
        if (Worker==null){
            return NotFound();
        }
        return Ok();
    }
    [Route("[action]")]
    [HttpPost]
    [Authorize(Policy="Admin")]
    public IActionResult Post(string name,string lastName,int id,int sumHours)
    {
        var add = _worker.Post(name,lastName, id, sumHours); 
        if  (add)
            return Ok();
        return NotFound();
    }




   [Route("[action]/{id}/{sumHours}/")]
   [HttpPost]
   public IActionResult SumId(int id,int sumHours){
             
    var p1 =_worker.SumId(id, sumHours);
     
      if(p1!=0)
         return Ok("update the gluten sacces");

      return NotFound("there not findupdate");
      }
//    public IActionResult AddOrder(int customerId,DateTime date,int idOrder)
//    {
//     _Worker.AddOrder(customerId,date,idOrder);

//     return Ok("new order");
// }
}