namespace Mediator;

interface IDialogBox{ //IMediator
    void Notify(object sender,string message);
}

class DialogBox : IDialogBox //Mediator
{
    BaseButton smallButton,bigButton;

    public void SetComponents(SmallButton smallButton,BigButton bigButton){
        this.smallButton = smallButton;
        this.bigButton = bigButton;
    }
    public void Notify(object sender,string message){
        switch (message)
        {
            case "BigClick":
                TextShower.Show("Big Button Clicked!");
                break;
            case "SmallClick":
                TextShower.Show("Small Button Clicked!");
                break;
            case "BaseClick":
                TextShower.Show("Base Button Clicked! Please Implement a new button");
                break;
        }
    }
}

class BaseButton //Base Component
{
    protected IDialogBox dialogBox;

    public BaseButton(IDialogBox dialogBox)=> this.dialogBox = dialogBox;

    public void SetDialogBox(IDialogBox dialogBox)=> this.dialogBox = dialogBox;

    public virtual void Click()
    {
        dialogBox.Notify(this,"BaseClick");
    }
}

class BigButton : BaseButton
{
    public BigButton(IDialogBox dialogBox) : base(dialogBox)
    {
    }

    public override void Click()
    {
        dialogBox.Notify(this,"BigClick");
    }
}

class SmallButton : BaseButton
{
    public SmallButton(IDialogBox dialogBox) : base(dialogBox)
    {
    }

    public override void Click()
    {
        dialogBox.Notify(this,"SmallClick");
    }
}

class TextShower
{
    public static void Show(string text)=>Console.WriteLine(text);
}

class MediatorRunner
{
    public static void Run(){

        DialogBox dialogBox = new DialogBox();

        SmallButton button1 = new SmallButton(dialogBox);
        BigButton button2 = new BigButton(dialogBox);

        dialogBox.SetComponents(button1,button2);

        button1.Click();
        button2.Click();
    }
}