namespace Bridge;

interface IGameConsole{
    void TurnOn();
    void TurnOff();
    bool IsOn();
    int GetGameIndex();
    void SetGameIndex(int ind);
}

class HomeConsole : IGameConsole //Implimentation 1
{
    int gameIndex;
    bool power;
    string name;
    public HomeConsole(string name)=>this.name = name;

    public int GetGameIndex()=> gameIndex;

    public bool IsOn()=>power;

    public void TurnOn()=> power = true;
    public void TurnOff()=> power = false;

    public void SetGameIndex(int ind)=> gameIndex = ind;

    public override string ToString()=> $"This is {name} on the game index {gameIndex} and power is {power}";
}

class HandHeldConsole : IGameConsole //Implimentation 2
{
    int gameIndex;
    bool power;
    string name;
    public HandHeldConsole(string name)=>this.name = name;

    public int GetGameIndex()=> gameIndex;

    public bool IsOn()=>power;

    public void TurnOn()=> power = true;
    public void TurnOff()=> power = false;

    public void SetGameIndex(int ind)=> gameIndex = ind;

    public override string ToString()=> $"This is {name} on the game index {gameIndex} and power is {power}";
}

class Gamepad{ //Abstraction
    protected IGameConsole _igameconsole;

    public Gamepad(IGameConsole gameConsole)=> this._igameconsole = gameConsole;

    public void TogglePower(){
        if(_igameconsole.IsOn())
        _igameconsole.TurnOff();
        else
        _igameconsole.TurnOn();
    }

    public void NextGame()=> _igameconsole.SetGameIndex(_igameconsole.GetGameIndex()+1);
    public void PreviousGame()=> _igameconsole.SetGameIndex(_igameconsole.GetGameIndex()-1);

    public virtual string GetStatus()=> _igameconsole.ToString();
}

class HiddenGamepad : Gamepad //Extended Abstraction
{
    public HiddenGamepad(IGameConsole gameConsole) : base(gameConsole)
    {
    }

    public override string GetStatus()=>$"The Status is: {base._igameconsole.ToString()}";
}
//---
class Player{ //client
    public void TakeGamepad(Gamepad gamepad){
        if(gamepad != null){
            gamepad.TogglePower();
            gamepad.NextGame();
            gamepad.NextGame();
            Console.WriteLine(gamepad.GetStatus());
        }
    }
}
//----------------------
class BridgeRunner{
    public static void Run(){
        Player player = new Player();
        Gamepad gamepad = new Gamepad(new HomeConsole("NES"));
        player.TakeGamepad(gamepad);

        Console.WriteLine();

        gamepad = new HiddenGamepad(new HandHeldConsole("GameBoy"));
        player.TakeGamepad(gamepad);
    }
}