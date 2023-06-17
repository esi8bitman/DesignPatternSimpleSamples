namespace Adapter;

public interface ITarget{
    string foo();
}

class MyApp{
   public string DoSomething()=>"I do Something!!";
}

class Adapter : ITarget //this make MyApp captabile with ITarget
{
    private readonly MyApp _myApp;

    public Adapter(MyApp myApp)=>this._myApp = myApp;

    public string foo()=> $"MyApp result with Adpter:{_myApp.DoSomething()}";
}

class AdapterRunner{
    public static void Run(){
        MyApp myApp1 = new MyApp();
        ITarget target = new Adapter(myApp1);

        Console.WriteLine(target.foo());//MyApp work with ITarget!!
    }
}
