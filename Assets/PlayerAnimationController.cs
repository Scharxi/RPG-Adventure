using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;

    private void OnEnable()
    {
        PlayerInputHandler.OnPlayerMove += OnPlayerMove;
    }

    private void OnDisable()
    {
        PlayerInputHandler.OnPlayerMove -= OnPlayerMove;
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnPlayerMove(Vector2 input)
    {
        var isMoving = input.sqrMagnitude > 0;
        _animator.SetBool("isMoving", isMoving);
    }
}