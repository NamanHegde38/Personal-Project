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
