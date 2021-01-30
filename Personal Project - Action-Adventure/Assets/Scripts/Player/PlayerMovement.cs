using UnityEngine;

public class PlayerMovement : MonoBehaviour {
     
     [SerializeField] private float moveSpeed = 5f;
     
     private Rigidbody2D _rb;

     private void Awake() {
          SetComponents();
     }

     private void SetComponents() {
          _rb = GetComponent<Rigidbody2D>();
     }

     public void MovePlayer(Vector2 direction) {
          _rb.MovePosition(_rb.position + direction * (moveSpeed * Time.fixedDeltaTime));
     }
}
