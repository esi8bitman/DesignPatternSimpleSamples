namespace Strategy;

class Calculator //Context
{
    IProcess _process;
    public Calculator(IProcess process)=> SetProcess(process);

    public void SetProcess(IProcess process)=> _process = process;

    public void Calculate(int numA,int numB)=> Console.WriteLine(_process.Calculate(numA,numB).ToString());
}

interface IProcess //Strategy interface
{
    int Calculate(int numA,int numB);
}

class Adder : IProcess //Concrete Strategy
{
    public int Calculate(int numA,int numB)=> numA + numB;
}
 
class Multiplier : IProcess //Concrete Strategy
{
    public int Calculate(int numA,int numB)=> numA * numB;
}

class Subtractor : IProcess //Concrete Strategy
{
    public int Calculate(int numA,int numB)=> numA - numB;
}

class StrategyRunner
{
    public static void Run()
    {
        Adder adder = new Adder();
        Subtractor subtractor = new Subtractor();
        Multiplier multiplier = new Multiplier();

        Calculator calc = new Calculator(adder);
        calc.Calculate(10,15);
        calc.SetProcess(subtractor);
        calc.Calculate(20,15);
        calc.SetProcess(multiplier);
        calc.Calculate(20,15);
    }
}