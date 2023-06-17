namespace Facade
{
    class PizzaMaker //SubSystem 1
    {
    	private string pizzaName;
    	
    	public PizzaMaker(string pizzaName)=> this.pizzaName = pizzaName;
    	
    	public void PreparePizza(){
    		Console.WriteLine($"Prepared Pizza {this.pizzaName}");
    	}
    	
    	public void BakePizza(){
    		Console.WriteLine($"Baked Pizza {this.pizzaName}");
    	}
        
    }
    
    class PizzaCashier //SubSystem 2
    {
    	public void Order(string pizzaName){
    		Console.WriteLine($"User odered {pizzaName}");
    	}
    }
    
    class UI //Facade
    { 
    	protected PizzaMaker _pizzaMaker;
    	protected PizzaCashier _pizzaCashier;
    	
    	public UI(PizzaMaker pizzaMaker, PizzaCashier pizzaCashier){
    		_pizzaMaker = pizzaMaker;
    		_pizzaCashier = pizzaCashier;
    	}
    	public void Btn_Order(){
    		_pizzaCashier.Order("PepeRoni");
    		_pizzaMaker.PreparePizza();
    		_pizzaMaker.BakePizza();
    	}
    }
    
    class Client{
    	
    	public void myCode(UI ui){
    		Console.WriteLine("Client Code:");
    		ui.Btn_Order();
    	}
    }
    
    class FacadeRunner
    {
    	public static void Run(){
    		PizzaMaker maker = new PizzaMaker("Margarita");
    		PizzaCashier cashier = new PizzaCashier();
    		UI ui = new UI(maker,cashier);
    		Client client = new Client();
    		
    		client.myCode(ui);
    	}
    }
    
}