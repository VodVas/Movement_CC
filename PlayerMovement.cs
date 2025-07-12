using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _sprintSpeed = 8f;
    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private float _jumpHeight = 2f;
    [SerializeField] private Transform _cameraTransform;

    private Vector3 _moveDirection;
    private CharacterController _characterController;
    private InputHandler _inputHandler;
    private GravityApplier _gravityApplier;
    private Mover _mover;
    private CameraController _cameraController;
    private PlayerRotation _playerRotation;
    private JumpHandler _jumpHandler;
    private SprintHandler _sprintHandler;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _inputHandler = new InputHandler();
        _gravityApplier = new GravityApplier();
        _mover = new Mover(_moveSpeed);
        _cameraController = new CameraController(_cameraTransform, _mouseSensitivity * Time.deltaTime);
        _playerRotation = new PlayerRotation(transform, _mouseSensitivity * Time.deltaTime);
        _jumpHandler = new JumpHandler(_characterController, _jumpHeight);
        _sprintHandler = new SprintHandler(_moveSpeed, _sprintSpeed);
    }

    private void Update()
    {
        ProcessInput();
        ApplyGravity();
        ApplyJump();
        ApplySprint();
        Move();
        Rotate();
    }

    private void LateUpdate()
    {
        UpdateCamera();
    }

    private void OnValidate()
    {
        if (_moveSpeed < 0) _moveSpeed = 0;
        if (_sprintSpeed < 0) _sprintSpeed = 0;
        if (_mouseSensitivity < 0) _mouseSensitivity = 0;
        if (_jumpHeight < 0) _jumpHeight = 0;
    }

    private void ProcessInput()
    {
        Vector3 inputDirection = _inputHandler.GetInputVector(transform);
        SetMoveDirection(inputDirection);
    }

    private void SetMoveDirection(Vector3 direction)
    {
        _moveDirection.x = direction.x;
        _moveDirection.z = direction.z;
    }

    private void ApplyGravity()
    {
        float verticalVelocity = _gravityApplier.ApplyGravity(_characterController);
        _moveDirection.y = verticalVelocity;
    }

    private void ApplyJump()
    {
        bool jumpInput = _inputHandler.IsJumpPressed();
        _jumpHandler.ApplyJump(jumpInput);
        _moveDirection.y = _jumpHandler.GetVerticalVelocity();
    }

    private void ApplySprint()
    {
        bool isSprinting = _inputHandler.IsSprinting();
        float currentSpeed = _sprintHandler.GetCurrentSpeed(isSprinting, Time.deltaTime);
        _mover.SetSpeed(currentSpeed);
    }

    private void Move()
    {
        _mover.Move(_characterController, _moveDirection);
    }

    private void Rotate()
    {
        float mouseX = _inputHandler.GetMouseX();
        _playerRotation.UpdateRotation(mouseX);
    }

    private void UpdateCamera()
    {
        float mouseY = _inputHandler.GetMouseY();
        _cameraController.UpdateRotation(mouseY);
    }
}



//public class GroundDetector : MonoBehaviour
//{
//    [SerializeField] private float _checkDistance = 0.2f;
//    [SerializeField] private LayerMask _groundLayer = ~0; // Все слои по умолчанию

//    // Основной метод проверки
//    public bool CheckGrounded()
//    {
//        return Physics.Raycast(
//            transform.position,
//            Vector3.down,
//            _checkDistance,
//            _groundLayer
//        );
//    }

//    // Вариант с временной визуализацией луча (для отладки)
//    public bool CheckGroundedWithDebug()
//    {
//        bool isGrounded = Physics.Raycast(
//            transform.position,
//            Vector3.down,
//            _checkDistance,
//            _groundLayer
//        );

//        Debug.DrawRay(
//            transform.position,
//            Vector3.down * _checkDistance,
//            isGrounded ? Color.green : Color.red,
//            0.1f
//        );

//        return isGrounded;
//    }
//}