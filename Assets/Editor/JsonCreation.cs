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
        var Weapons = new List<Weapon>();
       

        Weapons.Add(new Weapon()
        {
            Name = "Longsword",
            Type = "Londsword",
            DamageDice = Dice.d6,
            AttackSpeed = 10,
            DamageModifier = 0,
            DamageType = "slashing", 
            Weight = 1
        });
        Weapons.Add(new Weapon()
        {
            Name = "Dagger",
            Type = "Dagger",
            DamageDice = Dice.d4,
            AttackSpeed = 10,
            DamageModifier = 0,
            DamageType = "slashing",
            Weight = 0.5f
        });



        var temptest = new Testing()
            {
            Name = "testing"
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
