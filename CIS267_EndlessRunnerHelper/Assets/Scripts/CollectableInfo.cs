using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableInfo : MonoBehaviour
{
    //How much is the collectable worth when the player runs into it
    public int value;
    
    public int getCollectableValue()
    {
        return value;
    }

    public void setCollectableValue(int v)
    {
        value = v;
    }
}
