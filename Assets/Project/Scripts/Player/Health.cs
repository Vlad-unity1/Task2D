using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health = 100f;

    public float CurrentHealth => _health;

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0f)
        {
            _health = 0f; 
            GameManager.Instance.OnPlayerDeath();
        }
    }

    public void TakeHealth(float health)
    {
        if (!Mathf.Approximately(_health, 100f))
        {
            _health += health;
            _health = Mathf.Min(_health, 100f);
        }
    }
}
