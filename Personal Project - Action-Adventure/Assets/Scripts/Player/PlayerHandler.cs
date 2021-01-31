using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHandler : MonoBehaviour {

    public int playerHealth = 100;
    public Transform pfHealthBar;
    
    public HealthSystem healthSystem;

    private void Start() {
        healthSystem = new HealthSystem(playerHealth);

        var healthBarTransform = Instantiate(pfHealthBar, new Vector3(0, 0.8f), quaternion.identity, transform);
        var healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);
    }
    
    private void Update() {
        if (healthSystem.GetHealth() == 0) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Win")) {
            SceneManager.LoadScene(1);
        }
    }
}
