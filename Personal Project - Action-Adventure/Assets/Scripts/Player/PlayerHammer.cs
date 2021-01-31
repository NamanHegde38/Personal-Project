using UnityEngine;

public class PlayerHammer : MonoBehaviour {

    public static PlayerHammer Instance;
    
    public Color hitColour = Color.white;

    public bool canReceiveInput;
    public bool inputReceived;
    
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask enemyLayer;

    private void Awake() {
        Instance = this;
    }

    public void GetMeleeInput() {
        if (!canReceiveInput) return;
        inputReceived = true;
        canReceiveInput = false;

        var hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (var enemy in hitEnemies) {
            enemy.GetComponent<EnemyHandler>().healthSystem.Damage(35);
            Debug.Log(enemy.GetComponent<EnemyHandler>().healthSystem.GetHealth());
        }
    }

    public void MeleeInputManager() {
        canReceiveInput = !canReceiveInput;
    }
    
    
    private void OnDrawGizmosSelected() {
        if (attackPoint == null) {
            return;
        }

        Gizmos.color = hitColour;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
