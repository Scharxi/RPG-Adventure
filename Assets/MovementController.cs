using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(MovementStats))]
public class MovementController : MonoBehaviour
{
    private Collider2D _collider;
    private MovementStats _movementStats;
    private Vector3 _moveDelta; 
    
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider2D>(); 
        _movementStats = GetComponent<MovementStats>(); 
    }

    
    
}
