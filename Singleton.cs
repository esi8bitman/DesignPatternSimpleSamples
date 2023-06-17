namespace Singleton;

//The Singleton should always be a 'sealed' class to prevent class inheritance through external classes and also through nested classes.
sealed class MyDB{
    private MyDB(){} //constructor
    private static MyDB _mydb;
    private static int num;

    public static MyDB InstantiateDB(){ //access through this
        _mydb = _mydb ?? new MyDB();
        return _mydb;
    }

    public static void SetNum(int Number)=>num = Number;

    public override string ToString()
    {
        return $"Num Data : {num}";
    }
}

class SingletonRunner{

    public static void Run(){
        MyDB myDB1 = MyDB.InstantiateDB(); //new MyDB behet Error mide
        MyDB myDB2 = MyDB.InstantiateDB();

        if(myDB1==myDB2) Console.WriteLine("Databases are equal!!");
        else Console.WriteLine("Databases are NOT equal!!");

        //myDB1.SetNum(4) is not work!!
        MyDB.SetNum(4);
        Console.WriteLine(myDB1.ToString());//4
        Console.WriteLine(myDB2.ToString());//4
    }
}