using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] GameObject targetToDestroy=null;

    public void DestroyTarget()
    {
        Destroy(targetToDestroy);
    }
}
