using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(MapManager))]
public class MapGenerator : MonoBehaviour
{
    public MapManager Map;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Map = GetComponent<MapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GenetateFloor()
    {
        yield return null;
        yield return StartCoroutine(GenerateWalls());
    }



    public IEnumerator GenerateWalls()
    {
        Map.Walls.ClearAllTiles();
        yield return null;

        Dictionary<Vector3Int, string> wallTilestypes = new Dictionary<Vector3Int, string>();
        int counter = 0;
        int maxcheck = 30;

        for (int xdx = Map.Ground.cellBounds.xMin; xdx < Map.Ground.cellBounds.xMax; xdx++)
        {
            for (int ydx = Map.Ground.cellBounds.yMin; ydx < Map.Ground.cellBounds.yMax; ydx++)
            {
                var current = new Vector3Int(xdx, ydx);
                if (Map.Ground.HasTile(current))
                {
                    var wallTiles = new List<Vector3Int>();
                    if (!Map.Ground.HasTile(current + Vector3Int.up))
                        wallTiles.Add(current + Vector3Int.up);
                    if (!Map.Ground.HasTile(current + Vector3Int.right))
                        wallTiles.Add(current + Vector3Int.right);
                    if (!Map.Ground.HasTile(current + Vector3Int.down))
                        wallTiles.Add(current + Vector3Int.down);
                    if (!Map.Ground.HasTile(current + Vector3Int.left))
                        wallTiles.Add(current + Vector3Int.left);

                    if (!Map.Ground.HasTile(current + new Vector3Int( 1, 1)))
                        wallTiles.Add(current + new Vector3Int( 1,  1));
                    if (!Map.Ground.HasTile(current + new Vector3Int( 1, - 1)))
                        wallTiles.Add(current + new Vector3Int( 1,  - 1));
                    if (!Map.Ground.HasTile(current + new Vector3Int( - 1,   1)))
                        wallTiles.Add(current + new Vector3Int( - 1,  1));
                    if (!Map.Ground.HasTile(current + new Vector3Int( - 1,  - 1)))
                        wallTiles.Add(current + new Vector3Int( - 1,  - 1));

                    var tileName = Map.Ground.GetTile(current).name;
                    foreach (var tile in wallTiles)
                    {
                        if (!wallTilestypes.ContainsKey(tile))
                            wallTilestypes.Add(tile, tileName);
                    }


                    counter++;

                    if (counter > maxcheck)
                    {
                        yield return null;
                        counter = 0;
                    }
                }
            }
        }
        yield return null;

        var TileManager = GameManager.instance.tileManager;

        foreach (var wall in wallTilestypes)
        {
            var walldef = TileManager.GetWalls(wall.Value);
            

            string wallType  = "";
            if (wallTilestypes.ContainsKey(wall.Key + Vector3Int.up))
                wallType += "N";
            if (wallTilestypes.ContainsKey(wall.Key + Vector3Int.right))
                wallType += "E";
            if (wallTilestypes.ContainsKey(wall.Key + Vector3Int.down))
                wallType += "S";
            if (wallTilestypes.ContainsKey(wall.Key + Vector3Int.left))
                wallType += "W";

            Map.Walls.SetTile(wall.Key, walldef.GetTile(wallType));

            counter++;
            if (counter > maxcheck)
            {
                yield return null;
                counter = 0;
            }
        }


    }
}
