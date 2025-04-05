using UnityEngine;

[RequireComponent(typeof(EntityAttributes))]
public class BaseController : MonoBehaviour, ITickable
{
    public int Cooldown { get { return coolDown; } }


    public int coolDown;

    public bool WaitingForPlayerInput { get { return waitingForPlayerinput; } }

    public bool waitingForPlayerinput = false;


    public bool IsPlayerControlled = false;



    public EntityAttributes EntityAttributes; 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EntityAttributes = GetComponent<EntityAttributes>();
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

        coolDown = (int)EntityAttributes.MovementSpeed;
    }

    public virtual void Attack(Direction direction)
    {
        Attack(GameManager.instance.mapManager.GetTileFromWorld(transform.position).GetInDirection(direction)); 
    }

    public virtual void Attack(Vector3Int location)
    {
        var realLoc = GameManager.instance.mapManager.GetWorldFromTile(location);
        var hits = Physics2D.OverlapPointAll(realLoc); 
        foreach ( var hit in hits )
        {
            var attribute = hit.attachedRigidbody?.gameObject?.GetComponent<EntityAttributes>();
            if ( attribute != null && attribute.Faction != EntityAttributes.Faction)
            {
                var attackroll = DiceRoller.RollDice(Dice.d20);
                if (attackroll == 1)
                    continue; //crit fail. 

                if (attackroll >= attribute.ArmourClass)

                attribute.DealDamage("", EntityAttributes.Strength,EntityAttributes); 
            }
        }

    }
}
