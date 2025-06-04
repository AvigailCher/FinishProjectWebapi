using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using models;
using models.Interface;
using FileService.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace pizza.Controllers;


public class PizzaControllers : baseControllers
{

   Ipizza _Pizza;
  private readonly IFileService<PizzaTata> _fileService;
   public PizzaControllers(Ipizza Pizza, IFileService<PizzaTata> fs)
   {
      _Pizza = Pizza;
      _fileService = fs;
   }
   // [Route("[action]")]
   // [HttpGet]
   // public List<PizzaTata> GetPizzaList()
   // {
   //    return _fileService.Read();
   // }
    [Route("[action]")]
    [HttpPost]
    [Authorize(Policy ="superworker")]

    public void PostPizza( [FromBody] PizzaTata p)
    {

          Console.WriteLine ("Received pizza: " + JsonConvert.SerializeObject(p));
          _fileService.Write(@"webapi6\JsonConvert.json",p);
    }
    [Route("[action]/{id}")]
    [HttpGet]
    public IActionResult getById(int id)
    {

      PizzaTata p1 = _Pizza.getById(id);
      if (p1 != null)
         return Ok(p1);
      return NotFound("pizza list not found!!!!");

   }


   [Route("[action]/{name}/{isGluten}/{id}/")]
   [HttpPost]
   public void AddPizza(string name, bool isGluten, int id)
   {
      
      PizzaTata p1 = new PizzaTata(name,isGluten,id);
      Console.WriteLine ("Received pizza: " + JsonConvert.SerializeObject(p1));
      _fileService.Write(@"webapi6\JsonConvert.json",p1);

      // if (p1 == true)
      //    return Ok("newPizzaObject" + id);
      // return NotFound("don't add!!!");
   }

   [Route("[action]/{id}")]
   [HttpGet]
   [Authorize(Policy ="superworker")]

   public IActionResult deletpizza([Range(1,1000)]int id)
   {
      

      PizzaTata p1 = _Pizza.deletpizza(id);
      if (p1 != null)
         return Ok("the remove sacces" + id);
      return NotFound("don't delete!!!!");

   }

   [Route("[action]/{id}")]
   [HttpPut]
   [Authorize(Policy ="superworker")]

   public IActionResult updateGlutan(bool isGluten, int id)
   {
      PizzaTata p1 = _Pizza.updateGlutan(isGluten, id);

      if (p1 != null)
         return Ok("update the glutan sacces");

      return NotFound("there not findupdate");

   }
}