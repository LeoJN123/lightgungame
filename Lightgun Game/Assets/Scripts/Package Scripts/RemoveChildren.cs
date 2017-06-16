using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveChildren : MonoBehaviour
{
    public void Remove()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
