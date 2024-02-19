using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftSide = -1.25f;
    public static float rightSide = 1.25f;
    public float internalRight;
    public float internalLeft;

    private void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
    }
}
