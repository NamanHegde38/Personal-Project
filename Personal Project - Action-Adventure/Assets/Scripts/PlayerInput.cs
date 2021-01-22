using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private InputMaster _controls = null;
    
    private Vector2 _direction;
    private PlayerMovement _playerMovement;

    private void Awake() {
        SetComponents();
    }

    private void SetComponents() {
        _controls = new InputMaster();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable() {
        _controls.Player.Enable();
    }

    private void OnDisable() {
        _controls.Player.Disable();
    }

    private void Update() {
        _direction = _controls.Player.Movement.ReadValue<Vector2>();
        _direction.Normalize();
    }

    private void FixedUpdate() {
        _playerMovement.MovePlayer(_direction);
    }
}
