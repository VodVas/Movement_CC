using UnityEngine;

public class Mover
{
    private float _moveSpeed;

    public Mover(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }

    public void Move(CharacterController characterController, Vector3 moveDirection)
    {
        Vector3 movement = moveDirection * _moveSpeed * Time.deltaTime;
        characterController.Move(movement);
    }

    public void SetSpeed(float newSpeed) => _moveSpeed = newSpeed;
}