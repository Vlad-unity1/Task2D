using UnityEngine;

public class TrapSpikes : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health playerHealth))
        {
            playerHealth.TakeDamage(_damage);
        }
    }
}
