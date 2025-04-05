using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;


public static partial class Extensions
{
    public static Vector3Int GetInDirection(this Vector3Int vector, Direction direction)
    {
        switch (direction)
        {
            case Direction.None:
                return vector;
            case Direction.North:
                return vector + Vector3Int.up;
            case Direction.East:
                return vector + Vector3Int.right;
            case Direction.South:
                return vector + Vector3Int.down;
            case Direction.West:
                return vector + Vector3Int.left;
            default:
                return vector;
        }


    }
}