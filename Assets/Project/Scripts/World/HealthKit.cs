using UnityEngine;

public class HealthKit : MonoBehaviour
{
    [SerializeField] private float _health = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health playerHealth))
        {
            playerHealth.TakeHealth(_health);
            Destroy(gameObject);
        }
    }
}
