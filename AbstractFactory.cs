namespace AbstractFactory;

///------------------ Declare Products
interface IPizza{
    string Consume();
}

interface ISandwich{
    string Consume();
    string ConsumeWithPizza(IPizza pizza);
}
///----------------- Declare Asbtract Factory
interface IBaker{
    IPizza BakePizza();
    ISandwich BakeSandwich();
}

//-------------Implement a set of concrete factory classes, one for each product variant.
class Peperoni : IPizza
{
    public string Consume()=>"eated Pizza Peperoni!";
}

class Kasif : IPizza
{
    public string Consume()=>"eated Pizza Kasif!";
}

class Chicken : ISandwich
{
    public string Consume()=>"eated Sandwich Bandari!";

    public string ConsumeWithPizza(IPizza pizza) => $"{ Consume()} and { pizza.Consume() }";//collabrate with pizza
}

class Felafel : ISandwich
{
    public string Consume()=>"eated Sandwich Felafel!";

    public string ConsumeWithPizza(IPizza pizza) => $"{ Consume()} and { pizza.Consume() }";
}

//-----------------------------
class ExpensiveBaker:IBaker
{
    public IPizza BakePizza()=>new Peperoni();
    public ISandwich BakeSandwich() => new Chicken();
}

class CheapBaker:IBaker
{
    public IPizza BakePizza()=>new Kasif();
    public ISandwich BakeSandwich() => new Felafel();
}

//---------------------
class AbstractFactoryRunner
{
    public static void Run(){
        Console.WriteLine("****** Builder  Design Pattern *****");
        Console.WriteLine("Cheap restaurant:");
        Client(new CheapBaker());

    }

    static void Client(IBaker baker)
    {
        IPizza pizza = baker.BakePizza();
        ISandwich sandwich = baker.BakeSandwich();
        //Console.WriteLine(pizza.Consume());
        Console.WriteLine(sandwich.ConsumeWithPizza(pizza));
    }
}