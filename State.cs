namespace State;

class Player //Context
{
    private PlayerState _state; //Refrence
    public Player(PlayerState state)=>SetState(state);
    
    public void SetState(PlayerState state)
    {
        _state = state;
        _state.SetPlayer(this);
    }

    public void ButtonA(){
        _state.Jump();
    }

    public void ButtonB(){
        _state.Attack();
    }
}

abstract class PlayerState //State Interface
{
    protected Player _player;
    public void SetPlayer(Player player)=>_player = player;

    public abstract void Jump();
    public abstract void Attack();
}

class InAir : PlayerState
{

    public override void Attack()
    {
        Console.WriteLine("Player is in Air and now He is Attacking and OnGrounded!");
        base._player.SetState(new OnGround());
    }
    public override void Jump()=>Console.WriteLine("Player in Air Yet!");

}

class OnGround : PlayerState
{

    public override void Attack()=>Console.WriteLine("Player in on the ground and Attacking!");

    public override void Jump()
    {
        Console.WriteLine("Player Jumped and now He is in Air!");
        base._player.SetState(new InAir());
    }

}

class StateRunner
{
    public static void Run(){
        //Client Code
        Player player = new Player(new OnGround());
        player.ButtonA();
        player.ButtonB();
        player.ButtonB();
    }
}

