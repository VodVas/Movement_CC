using UnityEngine;

public class GravityApplier
{
    private const float Gravity = -9.81f;
    private float _verticalVelocity;

    public float ApplyGravity(CharacterController characterController)
    {
        if (!characterController.isGrounded)
        {
            _verticalVelocity += Gravity * Time.deltaTime;
        }
        else
        {
            _verticalVelocity = 0;
        }

        return _verticalVelocity;
    }
}