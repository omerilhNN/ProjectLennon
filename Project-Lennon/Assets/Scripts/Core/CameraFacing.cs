using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacing : MonoBehaviour
{
     void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward; //UI face with Camera.
    }
}
