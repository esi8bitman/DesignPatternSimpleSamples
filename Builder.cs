namespace Builder;

enum BodyModels{
    model1,
    model2,
    model3
}
interface IBuilder{ //Builder interface
    IBuilder SetWindows(int number);
    IBuilder SetWheels(int number);
    IBuilder SetSeats(int number);
    IBuilder SetBody(BodyModels body);
}

class Car{ //Product
    public string Name { get; set; }
    public BodyModels body { get; set; }
    public int windowNumber{ get; set; }
    public int wheelsNumber{ get; set; }
    public int seatsNumber { get; set; }
}

class CarBuilder : IBuilder //Product Builder
{
    private Car car;

    public CarBuilder(string name){
        this.Reset(name);
    }

    public IBuilder Reset(string name){
        car = new Car();
        car.Name = name;
        return this;

    }

    public IBuilder SetBody(BodyModels body)
    {
        car.body = body;
        return this;
        
    }

    public IBuilder SetSeats(int number)
    {
        car.seatsNumber = number;
        return this;
        
    }

    public IBuilder SetWheels(int number)
    {
        car.wheelsNumber = number;
        return this;
        
    }

    public IBuilder SetWindows(int number)
    {
        car.windowNumber = number;
        return this;
        
    }

    public Car Build() => car;

}

class Director{
    // IBuilder _builder;

    // public Director(IBuilder builder){
    //     this._builder = builder;
    // }

    private CarBuilder carBuilder;

    public Car BuildSimpleCar(CarBuilder carBuilder){
        this.carBuilder = carBuilder;
        carBuilder.SetBody(BodyModels.model1).SetSeats(4).SetWindows(6).SetWheels(4);
        return carBuilder.Build();
    }

}

static class BuilderRunner{

    public static void Run(){
        Console.WriteLine("****** Builder  Design Pattern *****");
        CarBuilder carBuilder = new CarBuilder("Simple");

        Console.Write("by Director:");
        Director director = new Director();
        Car car = director.BuildSimpleCar(carBuilder);
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize<Car>(car));

        Console.Write("by Custom:");
        carBuilder.Reset("ESI-Car_13");
        carBuilder.SetBody(BodyModels.model2).SetSeats(2).SetWheels(6).SetWindows(2);
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize<Car>(carBuilder.Build()));
    }
}