using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjects : MonoBehaviour
{
    public int rotateSpeed;

    public void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
