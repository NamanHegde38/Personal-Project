using Pathfinding;
using Unity.Mathematics;
using UnityEngine;

public class EnemyHandler : MonoBehaviour {

    public int enemyHealth = 100;
    public int damage;
    public Transform pfHealthBar;

    public HealthSystem healthSystem;

    [SerializeField] private float searchDistance;
    private AIPath _ai;

    private void Awake() {
        _ai = GetComponent<AIPath>();
        _ai.canMove = false;
    }

    private void Start() {
        healthSystem = new HealthSystem(enemyHealth);

        var transformVar = transform;
        var healthBarTransform = Instantiate(pfHealthBar, transformVar.position + new Vector3(0, 0.8f), quaternion.identity, transformVar);
        var healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            collision.collider.GetComponent<PlayerHandler>().healthSystem.Damage(damage);
        }
    }

    private void Update() {
        
        if (healthSystem.GetHealth() == 0) {
            Destroy(gameObject);
        }
        
        if (_ai.remainingDistance <= searchDistance) {
            _ai.canMove = true;
        }
    }
    
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, searchDistance);
    }
}
