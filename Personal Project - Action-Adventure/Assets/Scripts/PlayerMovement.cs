using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
     
     [SerializeField] private float moveSpeed = 5f;
     [SerializeField] private InputMaster controls;
     
     private Vector2 _movement;
     private Rigidbody2D _rb;

     private void Awake() {
          SetComponents();
     }

     private void SetComponents() {
          _rb = GetComponent<Rigidbody2D>();
     }

     private void Update() {
          _movement.x = Input.GetAxisRaw("Horizontal");
          _movement.y = Input.GetAxisRaw("Vertical");
     }

     private void FixedUpdate() {
          _rb.MovePosition(_rb.position + _movement * (moveSpeed * Time.fixedDeltaTime));
     }
}
