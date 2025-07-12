using UnityEngine;

public class PlayerRotation
{
    private readonly Transform _playerTransform;
    private readonly float _sensitivity;

    public PlayerRotation(Transform playerTransform, float sensitivity)
    {
        _playerTransform = playerTransform;
        _sensitivity = sensitivity;
    }

    public void UpdateRotation(float mouseX)
    {
        float rotation = mouseX * _sensitivity;
        _playerTransform.Rotate(Vector3.up * rotation);
    }
}