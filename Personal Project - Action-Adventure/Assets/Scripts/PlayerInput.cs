using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private InputMaster _controls;
    
    private Vector2 _direction;
    private PlayerMovement _movement;
    private PlayerHammer _hammer;
    
    private void Awake() {
        SetComponents();
        _controls.Player.MeleeAttack.performed += ctx => _hammer.MeleeAttack();
    }

    #region Setup
    private void SetComponents() {
        _controls = new InputMaster();
        _movement = GetComponent<PlayerMovement>();
        _hammer = GetComponent<PlayerHammer>();
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
        GetDirectionalInput();
    }
    
    private void FixedUpdate() {
        SetDirectionalInput();
    }
    
    private void GetDirectionalInput() {
        _direction = _controls.Player.Movement.ReadValue<Vector2>();
        _direction.Normalize();
    }
    
    private void SetDirectionalInput() {
        _movement.MovePlayer(_direction);
    }
    #endregion

}
