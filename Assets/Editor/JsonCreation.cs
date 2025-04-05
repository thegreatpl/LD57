using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class JsonCreation : MonoBehaviour
{
    [MenuItem("Json/CreateWeapons")]
    static void CreateWeaponJson()
    {
        var Weapons = new List<Weapon>
        {
            new Weapon()
            {
                Name = "Longsword",
                Type = "Londsword",
                DamageDice = Dice.d6,
                AttackSpeed = 10,
                DamageModifier = 0,
                DamageType = "slashing",
                Weight = 1
            },
            new Weapon()
            {
                Name = "Dagger",
                Type = "Dagger",
                DamageDice = Dice.d4,
                AttackSpeed = 10,
                DamageModifier = 0,
                DamageType = "slashing",
                Weight = 0.5f
            },
            new Weapon()
            {
                Name = "Fists",
                Type = "Fists",
                DamageDice = Dice.d2,
                AttackSpeed = 10,
                DamageModifier = 0,
                DamageType = "bludgeoning",
                Weight = 0.0f
            }
        };


        var json = EditorJsonUtility.ToJson(new WeaponCollection() { Weapons = Weapons}, true);

        File.WriteAllText($"Assets/Resources/Items/weapons.json", json);
    }
}

[Serializable]
public class Testing
{
    public string Name; 
}
