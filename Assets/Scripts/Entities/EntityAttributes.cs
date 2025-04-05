using System;
using UnityEngine;


public delegate void OnDeath();


public class EntityAttributes : MonoBehaviour
{
    public string Faction;

    public string Name;

    public int Level = 1; 


    public int Health; 

    public int MaxHealth;


    public int Strength;

    public int Dexterity;

    public int Constitution;

    public int Intelligence;

    public int Wisdom; 




    public int ArmourClass
    {
        get
        {
            return 10; //todo: add in the armour check here. 
        }
    }

    public OnDeath OnDeath;



    public float MovementSpeed
    {
        get
        {
            return 100 / Dexterity; 
        }
    }

    public float VisionDistance
    {
        get {
            return Wisdom; 
        }
    }

    public float AttackSpeed
    {
        get
        {
            return 100 / Dexterity;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MaxHealth = Constitution * Level;

        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health > 0)
        {
            Death();
            return;
        }
    }

    public void Death()
    {
        OnDeath?.Invoke();
    }

    public void DealDamage(string attackType, int damage, EntityAttributes attackerAttributes)
    {
        //insert things like resistances here. 
        GameManager.instance.ShowMessage($"{attackerAttributes.Name} attacks {Name} and deals {damage}.", Color.red);


        Health -= damage;
        if (Health < 0)
        {
            Death();
            GameManager.instance.ShowMessage($"{attackerAttributes.Name} has killed {Name}!", Color.red);
        }
    }

}
