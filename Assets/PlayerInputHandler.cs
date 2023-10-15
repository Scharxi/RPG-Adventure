using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public static Action<Vector2> OnPlayerMove = null; // Event for player movement input.
    public static Action<Collider2D> OnPlayerInteract = null; // Event for player interaction.

    private Vector2 _input; // Stores the player's input for movement.

    [Header("Reference")]
    [SerializeField] public InputActionReference movement; // Reference to the movement input action.
    [SerializeField] public InputActionReference interact; // Reference to the interact input action.

    private void FixedUpdate()
    {
        _input = movement.action.ReadValue<Vector2>(); // Read the movement input.
        OnPlayerMove?.Invoke(_input); // Invoke the player movement event with the input data.
    }
}