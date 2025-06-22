using models;
using FileService;
using models.Interface;
namespace ServiceCL;

public class PizzaSrevice : Ipizza
{
  string path = @"C:\Users\user\Documents\לימודים-אביגיל\webapi\webapi-lesson6\webapi6\JsonConvert.json";

  List<PizzaTata> PizzaList = new List<PizzaTata>(){
     new PizzaTata("Abayt",true,6),
     new PizzaTata("mutzarela",false,8),
     new PizzaTata("ziva",true,9),
     new PizzaTata("Etalkit",false,10),
    };

  public PizzaTata getById(int id)
  {
    foreach (var i in PizzaList)
    {
      if (i.Id == id)
        return i;
    }
    return null;
  }


  public bool AddPizza(string name, bool isGluten, int id)
  {
    // יצירת פיצה חדשה
    var newPizza = new PizzaTata(name, isGluten, id);

    // הוספת הפיצה לרשימה
    PizzaList.Add(newPizza);

    // בדיקה אם הפיצה נוספה בהצלחה לרשימה
    if (PizzaList.Contains(newPizza))
    {
      return true;  // הפיצה נוספה בהצלחה
    }
    else
    {
      return false; // משהו השתבש, הפיצה לא נוספה
    }
  }

  public PizzaTata deletpizza(int id)
  {
    for (int i = 0; i < PizzaList.Count; i++)
    {
      if (id == PizzaList[i].Id)
      {
        var pizza = PizzaList[i];
        PizzaList.RemoveAt(i);
        return pizza;
      }
    }
    return null;
  }

  public PizzaTata updateGlutan(bool isGluten, int id)
  {
    foreach (var i in PizzaList)
    {
      if (id == i.Id)
      {
        i.IsGlutan = isGluten;
        return i;
      }
    }
    return null;
  }
}
