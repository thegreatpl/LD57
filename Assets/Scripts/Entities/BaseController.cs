using UnityEngine;

public class BaseController : MonoBehaviour, ITickable
{
    public int Cooldown { get { return coolDown; } }


    public int coolDown;

    public bool WaitingForPlayerInput { get { return waitingForPlayerinput; } }

    public bool waitingForPlayerinput = false;


    public bool IsPlayerControlled = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void EndTick()
    {
        if (coolDown > 0) 
            coolDown--;

        if (IsPlayerControlled )
            waitingForPlayerinput = true;
    }

    public virtual void RunTick()
    {
        
    }


    public virtual void Move(Direction direction)
    {
        var map = GameManager.instance.mapManager;

        var current = map.GetTileFromWorld(transform.position);
        var tileToMoveTo = current.GetInDirection(direction);

        if (!map.IsPassable(tileToMoveTo))
            return; 

        transform.position = map.GetWorldFromTile(tileToMoveTo);

        coolDown = 10; //todo, fix this. 


    }
}
