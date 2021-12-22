using System;
using Controller;
using Interface;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace EnemyStateMachineScripts
{
    public class EnemyStateMachine: MonoBehaviour
    {
        private EnemyBaseState _currentState;
        private EnemyStateFactory _factory;
        private CharacterController _CharacterController;
        private Animator _Animator;

        private Vector3 _currentMovementVector;
        
        
        private bool isTouch = false;
        private bool isRotating = false;
        private bool canRotate = false;

        private int isRunHash = 0;
        private int isKillHash = 0;
        
        private void HashInit()
        {
            isRunHash = Animator.StringToHash("IsRun");
            isKillHash = Animator.StringToHash("IsKill");
        }

        private void Awake()
        {
            _factory = new EnemyStateFactory(this);
            _Animator = GetComponent<Animator>();
            _currentState = _factory.Run();
            _CharacterController = GetComponent<CharacterController>();
            HashInit();
        }

        private void Start()
        {
            _currentState.StartStates();
        }

        private void Update()
        {
            _currentState.UpdateStates();
            _CharacterController.Move(_currentMovementVector * Time.deltaTime);
        }

        public int IsRunHash => isRunHash;

        public int IsKillHash => isKillHash;

        public bool IsTouch => isTouch;

        public bool IsRotating
        {
            get => isRotating;
            set => isRotating = value;
        }

        public bool CanRotate
        {
            get => canRotate;
            set => canRotate = value;
        }


        public EnemyBaseState CurrentState
        {
            get => _currentState;
            set => _currentState = value;
        }

        public Animator Animator
        {
            get => _Animator;
            set => _Animator = value;
        }

        public Vector3 CurrentMovementVector
        {
            get => _currentMovementVector;
            set => _currentMovementVector = value;
        }
        

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<PlayerStatController>().Psvm.ChangeAliveBool(false);
                isTouch = true;
            }
            
            if (other.gameObject.CompareTag("RotateEnabler"))
            {
                canRotate = true;
            }
        }
    }
}