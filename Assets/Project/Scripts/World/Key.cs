using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private Finish _collector;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _collector.CollectKey();
        Destroy(gameObject);
    }
}
