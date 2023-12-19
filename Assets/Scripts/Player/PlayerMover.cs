using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _lowerLinePositionY;
    private float _stepSize = 1f;
    private int _linesCount = 6;
    private float _topLinePositionY;
    private Vector3 _targetPosition;

    private void Awake()
    {
        _targetPosition = transform.position;
        _lowerLinePositionY = transform.position.y;
        _topLinePositionY = _lowerLinePositionY + _stepSize * (_linesCount - 1);
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    public void TryMoveUp()
    {
        if (_targetPosition.y < _topLinePositionY)
            SetNextPosition(_stepSize);
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y > _lowerLinePositionY)
            SetNextPosition(-_stepSize);
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y + stepSize, _targetPosition.z);
    }
}
