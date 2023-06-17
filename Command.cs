namespace Command;

interface ISaveCommand
{
    void Savefile();
}

class QuickSave : ISaveCommand //Simple Command
{
    private string text;

    public QuickSave(string text){
        this.text = text;
    }

    public void Savefile()=>Console.WriteLine($"Saved Quickly:\n{this.text}\nDone");
}

class SaveAs : ISaveCommand //Complex Command
{
    private TextProcessor processor;
    private string text;

    public SaveAs(string text,TextProcessor processor)
    {
        this.text = text;
        this.processor = processor;
    }
    public void Savefile()
    {
        processor.Process(this.text);
        Console.WriteLine($"Saved the Text:\n{this.text}\nDone");

    }
}

class TextProcessor //Reciever
{
    public void Process(string text)=>Console.WriteLine($"Process On:{text}");
}

class BackEnd //Invoker
{
    private ISaveCommand saveButton;
    private ISaveCommand shortcut;

    public void SetButton(ISaveCommand saveCommand)=>saveButton = saveCommand;
    public void SetShortcut(ISaveCommand saveCommand)=>shortcut = saveCommand;

    public void ButtonPress()=>saveButton.Savefile();
    public void KeyPress()=>shortcut.Savefile();
}

class UI//Client
{
    BackEnd backEnd = new BackEnd();
    TextProcessor Processor = new TextProcessor();
    public void ButtonPress(string text){
        backEnd.SetButton(new SaveAs(text,Processor));
        backEnd.ButtonPress();
    }
    
    public void KeyPress(string text){
        backEnd.SetShortcut(new QuickSave(text));
        backEnd.KeyPress();
    }
}

class CommandRunner
{
    public static void Run()
    {
        UI ui = new UI();
        ui.ButtonPress("This is my Text");
        ui.KeyPress("This is my Quick text");
    }
}