using UnityEngine;

public class JumpHandler
{
    private readonly CharacterController _characterController;
    private readonly float _jumpHeight;
    private readonly float _gravity;
    private float _verticalVelocity;

    public JumpHandler(CharacterController characterController, float jumpHeight, float gravity = -9.81f)
    {
        _characterController = characterController;
        _jumpHeight = jumpHeight;
        _gravity = gravity;
        _verticalVelocity = 0f;
    }

    public void ApplyJump(bool jumpInput)
    {
        if (jumpInput && _characterController.isGrounded)
        {
            _verticalVelocity = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }

        _verticalVelocity += _gravity * Time.deltaTime;
    }

    public float GetVerticalVelocity() => _verticalVelocity;
}