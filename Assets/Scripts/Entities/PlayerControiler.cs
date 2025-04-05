using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControiller : BaseController
{

    bool added = false;


    InputAction MoveAction; 




    Direction direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsPlayerControlled = true;
        MoveAction = InputSystem.actions.FindAction("Move"); 
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
            
        }
    }

    public override void RunTick()
    {
        Move(direction);
    }
}
