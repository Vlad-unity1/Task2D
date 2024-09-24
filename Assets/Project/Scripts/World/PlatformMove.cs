using System.Collections;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private float _speedX = 2f;
    [SerializeField] private float _range = 5f;
    [SerializeField] private float _delay = 2f;
    private Vector2 _platformMoveLeft, _platformMoveRight;

    private void Start()
    {
        _platformMoveLeft = new Vector2(transform.position.x - _range, transform.position.y);
        _platformMoveRight = new Vector2(transform.position.x + _range, transform.position.y);
        StartCoroutine(MovePlatform());
    }

    private IEnumerator MovePlatform()
    {
        while (true)
        {
            yield return MoveToPosition(_platformMoveRight);
            yield return new WaitForSeconds(_delay);
            yield return MoveToPosition(_platformMoveLeft);
            yield return new WaitForSeconds(_delay);
        }
    }

    private IEnumerator MoveToPosition(Vector2 target)
    {
        while ((Vector2)transform.position != target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, _speedX * Time.deltaTime);
            yield return null;
        }
    }
}
