namespace ChainOfResposibility;

interface IChecker //Handler Interface
{
    IChecker NextCheck(IChecker checker);
    string Check();
}

abstract class Checker : IChecker //Base Handler......asbstract section s Optional!!
{
    private IChecker _nextChecker;

    public IChecker NextCheck(IChecker checker) //mitune mamooli set beshe ... bedune return
    {
        _nextChecker = checker;
        return checker;
    }

    public virtual string Check() => _nextChecker == null ? null : _nextChecker.Check();

}
//-----------------Concrete Handlers :

class UserChecker : Checker
{
    public override string Check()
    {
        Console.WriteLine("Input Username:");
        string request = Console.ReadLine();
        return request == "esisonic" ? base.Check() : "Access Denied : Wrong UserName";
    }
}

class PasswordChecker : Checker
{
    public override string Check()
    {
        Console.WriteLine("Input password:");
        string request = Console.ReadLine();
        return request == "1389" ? base.Check() : "Access Denied : Wrong Password";
    }
}

class CaptchaChecker : Checker
{
    public override string Check()
    {
        Console.WriteLine("Input A1B2C3:");
        string request = Console.ReadLine();
        return request == "A1B2C3" ? base.Check() : "Access Denied : Wrong CaptCha";
    }
}

class UI //client
{
    public void Btn_Process(Checker checker)
    {
        string res;
        for (; ; )
        {
            res = checker.Check();
            Console.WriteLine(res);
            if(res == null){ //yani zanijire tamoom shod
            Console.WriteLine("Welcome ESI Gamer");
            break;
            }
        }
    }
}

class CORRunner
{
    public static void Run()
    {
        UserChecker userChecker = new UserChecker();
        PasswordChecker passwordChecker = new PasswordChecker();
        CaptchaChecker captchaChecker = new CaptchaChecker();

        //MyChain is:
        userChecker.NextCheck(passwordChecker).NextCheck(captchaChecker);

        UI ui = new UI();
        ui.Btn_Process(userChecker);

    }
}