using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class Weapon : IItem
{
    public string Name { get; set; }

    public string Type { get; set; }
    public string Description { get; set; }

    public Dice DamageDice { get; set; }

    public int DamageModifier { get; set; }

    public string DamageType { get; set; }

    public int AttackSpeed { get; set; }
    public float Weight { get; set; }

    public Weapon Copy()
    {
        return new Weapon()
        {
            Name = Name,
            DamageDice = DamageDice,
            DamageModifier = DamageModifier,
            DamageType = DamageType,
            Description = Description,
            Type = Type, 
            Weight = Weight, 
            AttackSpeed = AttackSpeed
        };
    }
}

