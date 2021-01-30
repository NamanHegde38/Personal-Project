using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public static PlayerInput Instance;
    
    private InputMaster _controls;
    
    private Vector2 _direction;
    private PlayerMovement _movement;
    private PlayerHammer _hammer;
    private Animator _anim;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Speed = Animator.StringToHash("Speed");
    
    public enum State {
        Normal,
        Attacking,
    }
    
    public State _state;

    private void SetComponents() {
        Instance = this;
        _controls = new InputMaster();
        _movement = GetComponent<PlayerMovement>();
        _hammer = GetComponent<PlayerHammer>();
        _anim = GetComponent<Animator>();
    }
    
    #region Setup

    
    private void Awake() {
        SetComponents();
        _controls.Player.MeleeAttack.performed += ctx => {
            _hammer.GetMeleeInput();
            _state = State.Attacking;
        }; 
    }
    
    private void OnEnable() {
        _controls.Player.Enable();
    }

    private void OnDisable() {
        _controls.Player.Disable();
    }
    #endregion
    
    #region Behaviour
    private void Update() {
        switch (_state) {
            case State.Normal:
                GetDirectionalInput(); 
                break;
            case State.Attacking:
                _direction = Vector2.zero;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    private void FixedUpdate() {
        SetDirectionalInput();
    }
    
    private void GetDirectionalInput() {
        _direction = _controls.Player.Movement.ReadValue<Vector2>();
        _direction.Normalize();

        if (_direction != Vector2.zero) {
            _anim.SetFloat(Horizontal, _direction.x);
            _anim.SetFloat(Vertical, _direction.y);
        }
        
        _anim.SetFloat(Speed, _direction.sqrMagnitude);
    }
    
    private void SetDirectionalInput() {
        _movement.MovePlayer(_direction);
    }
    #endregion

}
