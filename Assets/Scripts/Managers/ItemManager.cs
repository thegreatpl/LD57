using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public List<Weapon> Weapons; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Weapon GetWeapon(string name)
    {
        return Weapons.FirstOrDefault(x => x.Name == name)?.Copy();
    }

    public List<Weapon> GetWeaponsOfType(string type)
    {
        var weapons = Weapons.Where(x => x.Type == type).ToList();
        List<Weapon> result = new List<Weapon>();
        foreach (var weapon in weapons)
        {
            result.Add(weapon.Copy());
        }
        return result;
    }
}
