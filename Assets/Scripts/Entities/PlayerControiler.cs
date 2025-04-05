using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControiller : BaseController
{

    bool added = false;


    InputAction MoveAction;

    InputAction AttackMode;

    InputAction MovementMode; 


    Direction direction;

    string mode; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EntityAttributes = GetComponent<EntityAttributes>();
        IsPlayerControlled = true;
        MoveAction = InputSystem.actions.FindAction("Move");
        MovementMode = InputSystem.actions.FindAction("MovementMode");
        AttackMode = InputSystem.actions.FindAction("AttackMode");

        mode = "movement"; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!added)
        {
            GameManager.instance.timeManager.TimeObjects.Add(this);
            added = true;
        }
        if (waitingForPlayerinput)
        {
            var value = MoveAction.ReadValue<Vector2>();
            if (value.x > 0)
            {
                direction = Direction.East;
                waitingForPlayerinput = false;
            }
            else if (value.x < 0)
            {
                direction = Direction.West;
                waitingForPlayerinput = false;
            }
            else if (value.y > 0)
            {
                direction = Direction.North;
                waitingForPlayerinput = false;
            }
            else if (value.y < 0)
            {
                direction= Direction.South;
                waitingForPlayerinput = false;
            }
            else
            {
                direction = Direction.None;
            }

            if (MovementMode.IsPressed())
                mode = "movement";
            else if (AttackMode.IsPressed())
                mode = "attack"; 
            
        }
    }

    public override void RunTick()
    {
        if (mode == "movement")
        {      
            Move(direction);
        }
        if (mode == "attack")
        {
            Attack(direction);
        }
    }
}
