namespace Proxy;

interface IPayment //Service Interface
{
   public void Pay();
}

class PayCash : IPayment //Service
{
    private int amount;
    public PayCash(int amount)=>this.amount = amount;
    public void Pay()
    {
        Console.WriteLine($"{amount} has payed from the card");
    }
}

class CreditCard : IPayment //Proxy
{
    private PayCash payCash;
    public CreditCard(PayCash payCash)=> this.payCash = payCash;

    public bool CheckAccess(){
        Console.WriteLine("Access Allowed");
        return true; //Masalan :D
    }
    public void Pay()
    {
        if(CheckAccess()) payCash.Pay();
    }
}

class UI //Client
{
    public void Btn_Oprate(IPayment payment)=> payment.Pay();
}

class ProxyRunner{
    public static void Run(){
        PayCash cash = new PayCash(1450);
        CreditCard creditCard = new CreditCard(cash);

        UI user = new UI();
        //client.Oprate(cash); //direct access is not Good!!
        user.Btn_Oprate(creditCard);
    }
}