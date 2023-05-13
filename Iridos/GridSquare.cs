using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquare : MonoBehaviour
{
    public bool isSafe = true; // whether the grid square is safe to step on or not

    private void OnCollisionEnter(Collision other)
    {
        if (!isSafe && other.gameObject.tag == "Player")
        {
            Debug.LogError("PlayerHasDied");
            other.transform.position = Vector3.zero;
        }
    }
}