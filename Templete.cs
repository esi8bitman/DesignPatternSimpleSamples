namespace Templete;

abstract class TempleteCharacter //Abstract Template Class!
{
    protected void GoForward()=>Console.WriteLine("Run Forward"); //implemenet and should not modify
    protected abstract void Attack(); //Should implemenet
    protected virtual void Jump()=>Console.WriteLine("Jump"); //can modify

    public void Algorithm(){ //Templete Method!!
        this.GoForward();
        this.Attack();
        this.Jump();
    }
}

class Boy : TempleteCharacter
{
    protected override void Attack()=>Console.WriteLine("Fast Attack!");
}

class Man : TempleteCharacter
{
    protected override void Attack()=>Console.WriteLine("Strong Attack!");
    protected override void Jump()=>Console.WriteLine("Long Jump!");
}

class CharacterTest //Client Class ☺
{
    public void Test(TempleteCharacter character)=> character.Algorithm();
}

class TemplateRunner{
    public static void Run(){
        TempleteCharacter myChar = new Boy();
        
        CharacterTest charTester = new CharacterTest();
        Console.WriteLine("Boy Test:");
        myChar.Algorithm();

        Console.WriteLine("\n Man Test:");
        myChar = new Man();
        myChar.Algorithm();

    }
}