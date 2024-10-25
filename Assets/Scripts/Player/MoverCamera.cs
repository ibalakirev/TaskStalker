using UnityEngine;

[RequireComponent(typeof(InputReader))]

public class MoverCamera : Mover
{
    [SerializeField] private PlayerCamera _camera;
    [SerializeField] private float _sensitivity = 2f;
    [SerializeField] private float _maxYAngle = 80f;
    [SerializeField] private float _minYAngle = -80f;

    private float _rotationX = 0f;
    private float _rotationY = 0f;

    private InputReader _inputReader;

    private void Start()
    {
        _inputReader = GetComponent<InputReader>();
    }

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        MoveXAxis();
        MoveYAxis();
    }

    private void MoveXAxis()
    {
        _rotationY = GetDirectionRotation(_inputReader.HorizontalMouseAxis);

        _camera.transform.parent.Rotate(Vector3.up * _rotationY);
    }

    private void MoveYAxis()
    {
        _rotationX -= GetDirectionRotation(_inputReader.VerticalMouseAxis);

        _rotationX = Mathf.Clamp(_rotationX, _minYAngle, _maxYAngle);

        _camera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
    }

    private float GetDirectionRotation(float direction)
    {
        return direction * _sensitivity;
    }
}
