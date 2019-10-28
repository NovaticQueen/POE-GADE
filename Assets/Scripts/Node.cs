using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    int x, z;
    bool isPlaceable = true;
    Vector3 pos;
    public Node(int x, int z)
    {
        this.x = x;
        this.z = z;
        pos = new Vector3(x, 1, z);
    }

    public bool IsPlaceable
    {
        get { return isPlaceable; }
        set { isPlaceable = value; }
    }

    public Vector3 Pos
    {
        get { return pos; }
    }
}
