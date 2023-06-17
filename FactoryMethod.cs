namespace FactoryMethod;

interface IFood //Product Interface
{
    string Cooked();
}

class Burger:IFood //Poduct A
{
    public string Cooked() => "Burger cooked..! Yummy!";
}

class Sandwich:IFood //Product B
{
    public string Cooked() => "Sandwich cooked..! hmmm!!!";
}

abstract class Baker //Creator
{
    public abstract IFood FactoryMethod();

    public string Bake(){
        IFood food = FactoryMethod();
        return "I Bake a food ..." + food.Cooked();
    }
}

class BurgerBaker : Baker //Product A Creator
{
    public override IFood FactoryMethod()
    {
        return new Burger();
    }
}

class SandwichBaker : Baker //Product B Creator
{
    public override IFood FactoryMethod()
    {
        return new Sandwich();
    }
}

class FactoryMethodRunner
{
    public static void Run()
    {
        Console.WriteLine("****** Builder  Design Pattern *****");
        Console.WriteLine("Burger:");

        Client(new BurgerBaker());

        // Baker baker = new BurgerBaker();
        // Console.WriteLine(baker.Bake());
    }

    static void Client(Baker baker){
        Console.WriteLine($"Client order:{ baker.Bake() }");
    }
}