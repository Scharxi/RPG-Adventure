using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator; // Reference to the Animator component.

    private void OnEnable()
    {
        PlayerInputHandler.OnPlayerMove += OnPlayerMove; // Subscribe to the player movement event when the component is enabled.
    }

    private void OnDisable()
    {
        PlayerInputHandler.OnPlayerMove -= OnPlayerMove; // Unsubscribe from the player movement event when the component is disabled.
    }

    void Start()
    {
        _animator = GetComponent<Animator>(); // Get the Animator component from the same GameObject.
    }

    private void OnPlayerMove(Vector2 input)
    {
        var isMoving = input.sqrMagnitude > 0; // Determine if the player is moving based on input magnitude.
        _animator.SetBool("isMoving", isMoving); // Update the "isMoving" parameter in the Animator.
    }
}