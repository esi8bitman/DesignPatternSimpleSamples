namespace Composite;

abstract class MyObject{
    
    public virtual void Add(MyObject obj){}
    public virtual void Remove(MyObject obj){}

    public abstract bool IsBox();//Asbtract Ejbaraye
    public abstract string WhatAmI();
}

class Product : MyObject
{
    private string name;
    public Product(string productName) => name = productName;

    public override bool IsBox()=>false;

    public override string WhatAmI()=> name;
}

class Box : MyObject
{
    private List<MyObject> _objectList = new List<MyObject>();
    public override void Add(MyObject obj)=>_objectList.Add(obj);

    public override bool IsBox()=>true;

    public override void Remove(MyObject obj)=>_objectList.Remove(obj);

    public override string WhatAmI()
    { 
        string str = "box contain a ";
        for(int i=0;i<_objectList.Count;i++)
            str += _objectList[i].WhatAmI() +  ((i==(_objectList.Count-1))?"":" and a ");
        return str;
    }
}

class Client{
    public void Opration1(MyObject myObject)=> Console.WriteLine("My object is a " + myObject.WhatAmI());

    public void Opration2(MyObject box,MyObject myObject){
        if(box.IsBox()) box.Add(myObject);
        Console.WriteLine("My object is a " + box.WhatAmI());
    }
}

class CompositeRunner{
    public static void Run(){
        Client client = new Client();

        Product NES = new Product("NES");
        Box gameboyBox = new Box();
        gameboyBox.Add(new Product("Game Boy"));
        gameboyBox.Add(new Product("Mario Cartrige"));
        Box box = new Box();

        box.Add(NES);
        client.Opration2(box,gameboyBox);
        
    }
}