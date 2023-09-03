using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public static Action<Vector2> OnPlayerMove = null;

    private Vector2 _input;

    [Header("Reference")] [SerializeField] public InputActionReference movement;

    private void FixedUpdate()
    {
        _input = movement.action.ReadValue<Vector2>();
        OnPlayerMove?.Invoke(_input);
    }
}