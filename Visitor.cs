namespace Visitor;
//----------------------Elements
interface IOrganization //Element Interface
{
    string GetID();
    void AcceptVisitor(IVisitor visitor);
}

class GameStudio : IOrganization //Concerete Element
{
    string ID;
    public GameStudio(string ID)=>this.ID = ID;
    public string GetID() => ID;
    public void AcceptVisitor(IVisitor visitor)
    {
        Console.WriteLine("Visitor Check gameStudio");
        visitor.CheckGameStudio(this);
    }
}

class Barber : IOrganization
{
    string ID;
    public Barber(string ID)=>this.ID = ID;
    public string GetID() => ID;
    public void AcceptVisitor(IVisitor visitor)
    {
        Console.WriteLine("Visitor Check Barber");
        visitor.CheckBarber(this);
    }
}
//------------------------------Visitors--------
interface IVisitor
{
    void CheckGameStudio(IOrganization organization);
    void CheckBarber(IOrganization organization);
}

class InsuranceVisitor : IVisitor
{
    public void CheckBarber(IOrganization organization)=> Console.WriteLine($"Insurance Checked Barber ID:{organization.GetID()}");

    public void CheckGameStudio(IOrganization organization)=>Console.WriteLine($"Insurance Checked GameStudio ID:{organization.GetID()}");

}

class MayoraltyVisitor : IVisitor
{
    public void CheckBarber(IOrganization organization)=> Console.WriteLine($"Mayoralty Checked Barber ID:{organization.GetID()}");

    public void CheckGameStudio(IOrganization organization)=>Console.WriteLine($"Mayoralty Checked GameStudio ID:{organization.GetID()}");

}

//---Client
class Client
{
    public void VisitAll(List<IOrganization> organizations,IVisitor visitor){
        for(int i=0;i<organizations.Count;i++) organizations[i].AcceptVisitor(visitor);
    }
}

class VisitorRunner
{
    public static void Run(){
        List<IOrganization> organizationsList = new List<IOrganization>()
        {
            new GameStudio("G147"),
            new Barber("B1585")
        };
        Client client = new Client();

        IVisitor Insurance = new InsuranceVisitor();
        client.VisitAll(organizationsList , Insurance);

        Console.WriteLine("");
        
        Insurance = new MayoraltyVisitor();
        client.VisitAll(organizationsList , Insurance);

    }
}
