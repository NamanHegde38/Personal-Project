using System;
using Unity.Mathematics;
using UnityEngine;

public class EnemyHandler : MonoBehaviour {

    public int enemyHealth = 100;
    public int damage;
    public Transform pfHealthBar;

    public HealthSystem healthSystem;

    private void Start() {
        healthSystem = new HealthSystem(enemyHealth);

        var healthBarTransform = Instantiate(pfHealthBar, new Vector3(3.01f, 1.91f), quaternion.identity, transform);
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
    }
}
