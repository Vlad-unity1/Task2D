using System.Collections;
using UnityEngine;

public class TrapSaw : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _speedY = 2f, _range = 5f, _delay = 2f;

    private Vector2 _sawMoveUp;
    private Vector2 _sawMoveDown;

    private void Start()
    {
        _sawMoveUp = new Vector2(transform.position.x, transform.position.y + _range);
        _sawMoveDown = new Vector2(transform.position.x, transform.position.y);
        StartCoroutine(MoveSaw());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health playerHealth))
        {
            playerHealth.TakeDamage(_damage);
        }
    }

    private IEnumerator MoveSaw()
    {
        while (true)
        {
            yield return MoveToPosition(_sawMoveUp);
            yield return new WaitForSeconds(_delay);
            yield return MoveToPosition(_sawMoveDown);
            yield return new WaitForSeconds(_delay);
        }
    }

    private IEnumerator MoveToPosition(Vector2 target)
    {
        while ((Vector2)transform.position != target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, _speedY * Time.deltaTime);
            yield return null;
        }
    }
}

