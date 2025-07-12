using UnityEngine;

public class SprintHandler
{
    private float _defaultSpeed;
    private float _sprintSpeed;
    private float _acceleration;
    private float _currentSpeed;

    public SprintHandler(float defaultSpeed, float sprintSpeed, float acceleration = 5f)
    {
        _defaultSpeed = defaultSpeed;
        _sprintSpeed = sprintSpeed;
        _acceleration = acceleration;
        _currentSpeed = defaultSpeed;
    }

    public float GetCurrentSpeed(bool isSprinting, float deltaTime)
    {
        float targetSpeed = isSprinting ? _sprintSpeed : _defaultSpeed;
        _currentSpeed = Mathf.Lerp(_currentSpeed, targetSpeed, _acceleration * deltaTime);

        return _currentSpeed;
    }
}