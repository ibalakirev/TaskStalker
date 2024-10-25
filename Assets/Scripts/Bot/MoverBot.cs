using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class MoverBot : Mover
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed = 20;
    [SerializeField] private float _maxDistanceToTarget = 5;

    private Rigidbody _rigidbody;
    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private Vector3 _directionMovement;
    private float _distanceToTarget;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        SetLookTargetPosition(_player);

        SetDistanceToTarget(_startPosition, _targetPosition);

        SetDirectionMovement(_targetPosition, _startPosition);

        if (_distanceToTarget > _maxDistanceToTarget)
        {
            Move();
        }
    }

    protected override void Move()
    {
        _rigidbody.MovePosition(transform.position + (_directionMovement * _speed * Time.deltaTime));
    }

    private void SetLookTargetPosition(Player player)
    {
        Vector3 lookTargetPosition = player.transform.position;

        lookTargetPosition.y = transform.position.y;

        transform.LookAt(lookTargetPosition);
    }

    private void SetDirectionMovement(Vector3 targetPosition, Vector3 startPosition)
    {
        _directionMovement = targetPosition - startPosition;

        _directionMovement.Normalize();
    }

    private void SetDistanceToTarget(Vector3 startPosition, Vector3 targetPosition)
    {
        _startPosition = GetStartPosition();
        _targetPosition = GetTargetPosition();

        _distanceToTarget = Vector3.Distance(startPosition, targetPosition);
    }

    private Vector3 GetStartPosition()
    {
        return new Vector3(transform.position.x, 0, transform.position.z);
    }

    private Vector3 GetTargetPosition()
    {
        return new Vector3(_player.transform.position.x, 0, _player.transform.position.z);
    }
}
