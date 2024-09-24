using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private int _totalKeys = 5;
    private int _collectedKeys = 0;
    [SerializeField] private TextMeshProUGUI _keyIndicator;

    private void Start()
    {
        UpdateKeyIndicator();
    }

    public void CollectKey()
    {
        _collectedKeys++;
        UpdateKeyIndicator();
    }

    private void UpdateKeyIndicator()
    {
        _keyIndicator.text = $"Keys {_collectedKeys} / {_totalKeys}";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_collectedKeys >= _totalKeys)
        {
            RestartScene();
        }
    }

    private void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
