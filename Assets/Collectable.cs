using System;
using UnityEngine;


public class Collectable : MonoBehaviour
{
    protected bool Collected;

    protected virtual void OnCollect(Collider2D col)
    {
        Collected = !Collected;
    }
}