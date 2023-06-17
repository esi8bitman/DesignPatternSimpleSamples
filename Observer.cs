namespace Observer;

interface IRSS{  //Publisher
    void Subscribe(ISubscriber subscriber);
    void UnSubscribe(ISubscriber subscriber);
    void Notify();
}

interface ISubscriber{
    void Update(IRSS rss);
}

class RSS : IRSS
{
    public string NewsFeed ="";
    List<ISubscriber> subscribers = new List<ISubscriber>();

    public void Subscribe(ISubscriber subscriber)=>subscribers.Add(subscriber);

    public void UnSubscribe(ISubscriber subscriber)=>subscribers.Remove(subscriber);

    public void Notify()
    {
        foreach(ISubscriber sub in subscribers)
            sub.Update(this);
    }
}

class Subscriber : ISubscriber
{
    string LastNews="";
    int ID;
    public Subscriber(int id)=>this.ID = id;
    public void Update(IRSS rss)
    {
        LastNews = (rss as RSS ).NewsFeed;
        Console.WriteLine($"{ID}:{LastNews}");
    }
}

class ObserverRunner //clinet
{
    public static void Run(){
        RSS rss = new RSS();
        Subscriber subscriber1 = new Subscriber(1);
        Subscriber subscriber2 = new Subscriber(2);

        rss.Subscribe(subscriber1);
        rss.Subscribe(subscriber2);

        rss.NewsFeed = "Fist news!!";
        rss.Notify();

        rss.UnSubscribe(subscriber1);
        rss.NewsFeed = "second news!!";
        rss.Notify();
    }
}