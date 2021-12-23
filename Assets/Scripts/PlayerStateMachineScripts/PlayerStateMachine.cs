using Controller;
using Interface;
using UnityEngine;
using UnityEngine.InputSystem;
using ViewModel;

public class PlayerStateMachine : MonoBehaviour, IObserver
{
    private PlayerBaseState _currentState;
    private PlayerInput _playerInput;
    private CharacterController _characterController;
    private Animator _animator;
    private PlayerStateFactory _factory;
    [SerializeField]
    private Transform _cam;

    private PlayerStatsViewModel psvm;

    [SerializeField]
    private GameObject enemy;

    private Vector2 _currentMovementInput;
    private Vector2 _currentRotateInput;
    private Vector3 _currentMovementVector;


    private bool isWalkPressing = false;
    private bool isJumpPress = false;
    private bool isRotating = false;
    private bool ableToRotate = false;
    private bool isAlive = true;
    
    private float _vericalVelocity = 0;
    private float _vericalDeceleration = -50.81f;

    private int _isRunHash;
    private int _isJumpHash;
    private int _isDieHash;

    private void inputControlInit()
    {
        _playerInput.Player.AD.started += OnWalk;
        _playerInput.Player.AD.performed += OnWalk;
        _playerInput.Player.AD.canceled += OnWalk;

        _playerInput.Player.Jump.started += OnJump;
        _playerInput.Player.Jump.performed += OnJump;
        _playerInput.Player.Jump.canceled += OnJump;

        _playerInput.Player.Rotate.started += OnRotate;
        _playerInput.Player.Rotate.performed += OnRotate;
        _playerInput.Player.Rotate.canceled += OnRotate;
        
    }

    private void hashInit()
    {
        _isRunHash = Animator.StringToHash("IsRunning");
        _isJumpHash = Animator.StringToHash("IsJump");
        _isDieHash = Animator.StringToHash("IsDie");
    }

    private void OnWalk(InputAction.CallbackContext context)
    {
        _currentMovementInput = context.ReadValue<Vector2>();
        if (_currentMovementInput.x == 0 && _currentMovementInput.y == 0)
        {
            isWalkPressing = false;
        }
        else
        {
            isWalkPressing = true;
        }
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        isJumpPress = context.ReadValueAsButton();
    }

    private void OnRotate(InputAction.CallbackContext context)
    {
        _currentRotateInput = context.ReadValue<Vector2>();
        if (_currentRotateInput.x == 0 && _currentRotateInput.y == 0)
        {
            isRotating = false;
        }
        else
        {
            isRotating = true;
        }
    }
    
    private void UpdateVerticalVelocity()
    {
        if (_characterController.isGrounded)
        {
            VericalVelocity = 0;
        }
        else
        {
            VericalVelocity += VericalDeceleration * Time.deltaTime;
        }

        Vector3 vector3 = _currentMovementVector;
        vector3.y = _vericalVelocity;
        _currentMovementVector = vector3;//
    }

    public void UpdateData(IObservable observable)
    {
        if (observable is PlayerStatsModel playerStatsModel)
        {
            isAlive = playerStatsModel.IsAlive;
        }
    }

    private void Awake()
    {
        FindObjectOfType<PlayerStatController>().Attach(this);
        psvm = FindObjectOfType<PlayerStatController>().Psvm;
        _playerInput = new PlayerInput();
        _factory = new PlayerStateFactory(this);
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        inputControlInit();
        hashInit();
        _currentState = _factory.Alive();
    }

    void Start()
    {
        _currentState.StartStates();
        Vector3 enemySpwanPoint = transform.position - transform.forward * 20;
        Instantiate(Enemy, enemySpwanPoint , Quaternion.Euler(0,transform.eulerAngles.y,0));
    }

    
    void Update()
    {
        _currentState.UpdateStates();
        UpdateVerticalVelocity();
        _characterController.Move(_currentMovementVector * Time.deltaTime);
        
    }
    
    private void OnEnable()
    {
        _playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Player.Disable();
    }

    public Animator Animator => _animator;

    public CharacterController CharacterController => _characterController;

    public Vector2 CurrentMovementInput => _currentMovementInput;

    public Vector2 CurrentRotateInput => _currentRotateInput;

    public PlayerStatsViewModel Psvm => psvm;

    public bool IsWalkPressing => isWalkPressing;

    public bool IsJumpPress => isJumpPress;

    public bool IsRotating => isRotating;

    public bool IsAlive => isAlive;

    public int IsRunHash => _isRunHash;

    public int IsJumpHash => _isJumpHash;

    public int IsDieHash => _isDieHash;


    public PlayerBaseState CurrentState
    {
        get => _currentState;
        set => _currentState = value;
    }

    public Vector3 CurrentMovementVector
    {
        get => _currentMovementVector;
        set => _currentMovementVector = value;
    }

    public Transform Cam
    {
        get => _cam;
        set => _cam = value;
    }

    public GameObject Enemy
    {
        get => enemy;
        set => enemy = value;
    }

    

    public float VericalVelocity
    {
        get => _vericalVelocity;
        set => _vericalVelocity = value;
    }

    public float VericalDeceleration
    {
        get => _vericalDeceleration;
        set => _vericalDeceleration = value;
    }

    public bool AbleToRotate
    {
        get => ableToRotate;
        set => ableToRotate = value;
    }
    
    
}
