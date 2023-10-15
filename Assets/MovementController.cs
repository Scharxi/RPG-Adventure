using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(MovementStats))]
public class MovementController : MonoBehaviour
{
    private BoxCollider2D _collider; // Reference to the BoxCollider2D component.
    private MovementStats _movementStats; // Reference to the MovementStats component.
    private Vector3 _moveDelta; // Stores the movement direction.
    private Rigidbody2D _rigidbody; // Reference to the Rigidbody2D component.

    private void OnEnable()
    {
        PlayerInputHandler.OnPlayerMove += MovePlayer;
    }

    private void OnDisable()
    {
        PlayerInputHandler.OnPlayerMove -= MovePlayer;
    }

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>(); // Get the BoxCollider2D component.
        _movementStats = GetComponent<MovementStats>(); // Get the MovementStats component.
        _rigidbody = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component.
    }

    private void MovePlayer(Vector2 input)
    {
        _moveDelta = new Vector3(input.x * _movementStats.XSpeed, input.y * _movementStats.YSpeed);
        _moveDelta.Normalize(); // Normalize the movement direction to ensure consistent speed.

        AdjustSpriteDirection(); // Call the method to adjust the player's sprite direction.

        if (_moveDelta == Vector3.zero)
        {
            if (_rigidbody.velocity != Vector2.zero)
            {
                _rigidbody.velocity = Vector2.zero; // Stop the player's rigidbody movement when not moving.
            }

            return;
        }

        _rigidbody.velocity = _moveDelta; // Apply the movement vector to the player's rigidbody.
    }

    private void AdjustSpriteDirection()
    {
        // Swap sprite direction based on the direction the player is moving.
        if (_moveDelta.x > 0)
        {
            transform.localScale = Vector3.one; // Set the local scale to its default (right-facing).
        }
        else if (_moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Invert the local scale to face left.
        }
    }
}