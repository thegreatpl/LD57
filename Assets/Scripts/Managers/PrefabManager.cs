using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{

    public List<PrefabDefinition> Prefabs;



    public GameObject GetPrefab(string prefabName)
    {
        return Prefabs.FirstOrDefault(x => x.Name == prefabName).Prefab;
    }
}
