using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(MovementStats))]
public class MovementController : MonoBehaviour
{
    private BoxCollider2D _collider;
    private MovementStats _movementStats;
    private Vector3 _moveDelta;
    private Rigidbody2D _rigidbody;

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
        _collider = GetComponent<BoxCollider2D>();
        _movementStats = GetComponent<MovementStats>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void MovePlayer(Vector2 input)
    {
        _moveDelta = new Vector3(input.x * _movementStats.XSpeed, input.y * _movementStats.YSpeed);
        _moveDelta.Normalize();

        AdjustSpriteDirection();

        if (_moveDelta == Vector3.zero)
        {
            if (_rigidbody.velocity != Vector2.zero)
            {
                _rigidbody.velocity = Vector2.zero;
            }

            return;
        }

        _rigidbody.velocity = _moveDelta;
    }

    private void AdjustSpriteDirection()
    {
        // Swap sprite direction based on the direction the player is moving 
        if (_moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (_moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}