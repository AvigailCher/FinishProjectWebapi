// using pizza;

namespace models.Interface;
public interface Ipizza{
public PizzaTata  getById(int id);
public Boolean AddPizza(string name,bool isGluten, int id);
public PizzaTata deletpizza(int id);
public PizzaTata updateGlutan(bool isGluten, int id);
}
 
 