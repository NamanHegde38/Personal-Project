using System;
using UnityEngine;

public class PlayerHammer : MonoBehaviour {

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask enemyLayer;

    private Color _hitColour;
    
    public void MeleeAttack() {
        var hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        _hitColour = Color.red;
        foreach (var enemy in hitEnemies) {
            //damage enemies
        }
    }

    private void OnDrawGizmosSelected() {
        if (attackPoint == null) {
            return;
        }

        Gizmos.color = _hitColour;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
