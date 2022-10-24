using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mill : MonoBehaviour
{
    public Cell[] cells;


    public Status isComplete()
    {
        return Status.EMPTY;
    }
}
