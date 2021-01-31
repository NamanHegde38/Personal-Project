using Unity.Mathematics;
using UnityEngine;

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
    
}
