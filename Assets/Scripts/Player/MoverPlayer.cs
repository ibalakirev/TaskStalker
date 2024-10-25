using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(InputReader))]

public class MoverPlayer : Mover
{
    [SerializeField] private float _heightJump = 10f;
    [SerializeField] private float _speed = 50f;
    [SerializeField] private float _gravity = 30f;

    private CharacterController _characterController;
    private InputReader _inputReader;
    private Vector3 _inputDirection;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _inputReader = GetComponent<InputReader>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (_characterController.isGrounded)
        {
            SetMovementDirection(_inputReader.HorizontalAxis, _inputReader.VerticalAxis);
            TryJump();
        }

        ApplyGravity();

        Move();
    }

    protected override void Move()
    {
        _characterController.Move(_inputDirection * _speed * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        _inputDirection.y -= _gravity * Time.deltaTime;
    }

    private void SetMovementDirection(float horizontalAxis, float verticalAxis)
    {
        _inputDirection = new Vector3(horizontalAxis, 0f, verticalAxis);

        _inputDirection = transform.TransformDirection(_inputDirection);
    }

    private void TryJump()
    {
        if (_inputReader.GetInputJump())
        {
            Jump();
        }
    }

    private void Jump()
    {
        _inputDirection.y = _heightJump;
    }
}
