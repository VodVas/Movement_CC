using UnityEngine;

public class InputHandler
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";
    private const string Jump = "Jump";
    private const string Sprint = "Sprint";

    public Vector3 GetInputVector(Transform playerTransform)
    {
        float verticalInput = Input.GetAxisRaw(Vertical);
        float horizontalInput = Input.GetAxisRaw(Horizontal);

        Vector3 forwardMovement = playerTransform.forward * verticalInput;
        Vector3 rightMovement = playerTransform.right * horizontalInput;

        return (forwardMovement + rightMovement).normalized;
    }

    public float GetMouseX() => Input.GetAxis(MouseX);
    public float GetMouseY() => Input.GetAxis(MouseY);
    public bool IsJumpPressed() => Input.GetButtonDown(Jump);
    public bool IsSprinting() => Input.GetButton(Sprint);
}