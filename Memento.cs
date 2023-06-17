namespace Memento;

class Editor //Originatro
{
    private string text;
    private int pos;

    public void SetText(string text,int pos){
        this.pos = pos;
        this.text = text;
        Console.WriteLine(this.ToString());
    }

    public void SetText(string text){
        this.pos = 0;
        this.text = text;
        Console.WriteLine(this.ToString());
    }

    public override string ToString() => $"{pos}:{text}";

    public Snapshot BackUp()=> new Snapshot(this,text,pos);
}

class Snapshot //Memento
{
    private Editor editor;
    private string text;
    private int pos;

    public Snapshot(Editor editor,string text,int pos)
    {
        this.editor = editor;
        this.text = text;
        this.pos = pos;
    }

    public void Restore()=> editor.SetText(text,pos);    
}

class Command //CareTaker
{
    const int memorylimit = 10;
    private List<Snapshot> backUps = new List<Snapshot>();
    private Editor editor;

    public Command(Editor editor)=> this.editor = editor;

    public void BackUp(){
        backUps.Add(editor.BackUp());
        if(backUps.Count > memorylimit) backUps.Remove(backUps.First()); //Memory Handler
    }

    public void Undo(){
        if(backUps.Count == 0) return;

        backUps.Last().Restore();
        backUps.Remove(backUps.Last());
    }
}

class MementoRunner
{
    public static void Run(){
        //Client
        Editor editor = new Editor();
        Command command = new Command(editor);

        editor.SetText("Hi dude");
        command.BackUp();
        editor.SetText("ASL PLZ",5);
        command.BackUp();
        editor.SetText("Gay or Str8",10);
        command.BackUp();
        editor.SetText("Fuck You Bitch!",15);
        command.BackUp();
        
        Console.WriteLine("read 2 Restore:--------------");

        command.Undo();
        Console.WriteLine("Last text:" + editor.ToString());

        command.Undo();
        Console.WriteLine("Last text:" + editor.ToString());
        
    }
}