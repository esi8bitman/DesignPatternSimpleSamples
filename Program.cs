namespace Practice;
using Visitor; //just use each pattern here

class Program
{

    static void Main(string[] args)
    {
        //each pattern has a static Runner ... just call it.. no need to instance
        VisitorRunner.Run();
    }
}
