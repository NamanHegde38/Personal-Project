using System;

public class HealthSystem {

    private int _health;
    private int _healthMax;

    public event EventHandler OnHealthChanged;
    public HealthSystem(int healthMax) {
        _healthMax = healthMax;
        _health = healthMax;
    }

    public float GetHealthPercent() {
        return (float)_health / _healthMax;
    }
    
    public int GetHealth() {
        return _health;
    }

    public void Damage(int damageAmount) {
        _health -= damageAmount;
        if (_health < 0) _health = 0;
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }
}
