namespace Prototype;

enum Platforms{
    Playstation4,
    XboxOne,
    Switch
}

class IDInfo{
    public int ID;
    public IDInfo(int id)=>this.ID = id;
}

class Game{
    public string title;
    public Platforms platform;
    public IDInfo ID;

    

    public Game ShallowCopy()=>(Game)this.MemberwiseClone();

    public Game DeepCopy(){
        Game game = (Game)this.MemberwiseClone();

        string title = this.title; //make a deep copy of class!
        game.title = title;
        Platforms platform = this.platform;
        game.platform = platform;
        game.ID = new IDInfo(ID.ID); //for change refrence type variable!

        return game;
    }

    public override string ToString()
    {
        return $"Gametitle:{title} _ Platform:{platform.ToString()} _ GameID:{ID.ID}";
    }
}
//-----------------------------------
class PrototypeRunner{
    public static void Run(){
        Console.WriteLine("****** Prototype Design Pattern *****");
        Game game1 = new Game();
        game1.title = "Mario";
        game1.platform = Platforms.Switch;
        game1.ID = new IDInfo(140);

        Console.WriteLine($"OriginalGame: {game1.ToString()}");

        Game game2 = game1.ShallowCopy();
        Console.WriteLine($"ShallowCopy: {game2.ToString()}");

        Game game3 = game1.DeepCopy();
        Console.WriteLine($"DeepCopy: {game3.ToString()}");

        game1.title = "Sonic";
        game1.platform = Platforms.Playstation4;
        game1.ID.ID = 113;

        Console.WriteLine($"\nModifiedGame: {game1.ToString()}");

        Console.WriteLine($"ShallowCopied: {game2.ToString()}");

        Console.WriteLine($"DeepCopied: {game3.ToString()}");
    }
}