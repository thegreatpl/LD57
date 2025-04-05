using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class PrefabDefinition
{
    public string Name { get; set; }

    public GameObject Prefab { get; set; }
}

