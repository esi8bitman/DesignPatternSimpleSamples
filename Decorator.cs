namespace Decorator;

abstract class BaseModule{ //base Component interface common oprations between modules
    public abstract string Fire();
    public abstract string Shield();
}

class RobotModule : BaseModule
{
    public override string Fire()=>"Module Fire to Aim";

    public override string Shield()=>"Module Shielded now";

    public string Heal()=>"Main Module Healed all of parts and modules++";
}

abstract class ModuleSetter : BaseModule
{
    protected BaseModule _baseModule;

    public ModuleSetter(BaseModule baseModule)=>_baseModule = baseModule;
    public void SetModule(BaseModule baseModule)=>_baseModule = baseModule;

    //delegates all works to the wrapped component.
    public override string Fire()=> _baseModule==null?"Module Not Found":_baseModule.Fire();

    public override string Shield()=>_baseModule==null?"Module Not Found":_baseModule.Shield();
}

class ModuleA : ModuleSetter
{
    public ModuleA(BaseModule baseModule):base(baseModule){}

    public override string Fire()=>$"Module A : {base.Fire()}";

    public override string Shield()=>$"Module A : {base.Shield()}";
}

class ModuleB : ModuleSetter
{
    public ModuleB(BaseModule baseModule):base(baseModule){}

    public override string Fire()=>$"Module B : {base.Fire()}";

    public override string Shield()=>$"Module B : {base.Shield()}";
}

class RobotOprator{ //client
    public void FireOprate(BaseModule module)=>Console.WriteLine($"Oprate:{module.Fire()}");
    public void SheildOprate(BaseModule module)=>Console.WriteLine($"Oprate:{module.Shield()}");
    public void HealOprate(RobotModule robotModule)=>Console.WriteLine($"Oprate:{robotModule.Heal()}");
}

class DecoratorRunner{
    public static void Run(){
        RobotOprator robotOprator = new RobotOprator();

        RobotModule MyMainModule = new RobotModule();
        robotOprator.FireOprate(MyMainModule);
        robotOprator.SheildOprate(MyMainModule);
        robotOprator.HealOprate(MyMainModule);

        ModuleA moduleA = new ModuleA(MyMainModule);
        ModuleB moduleB = new ModuleB(moduleA);

        Console.WriteLine("New Module Added to Main Robot Module");
        robotOprator.FireOprate(moduleA);
        robotOprator.SheildOprate(moduleB);
    }
}