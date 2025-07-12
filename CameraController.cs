using UnityEngine;

public class CameraController
{
    private Transform _cameraTransform;
    private float _sensitivity;
    private float _xRotation;

    public CameraController(Transform cameraTransform, float sensitivity)
    {
        _cameraTransform = cameraTransform;
        _sensitivity = sensitivity;
        _xRotation = 0f;
        LockCursor();
    }

    public void UpdateRotation(float mouseY)
    {
        _xRotation += mouseY * _sensitivity;
        _xRotation = Mathf.Clamp(_xRotation, 0f, 30f);
        _cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }

    private static void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}