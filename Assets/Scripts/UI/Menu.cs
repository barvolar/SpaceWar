using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _playButton;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.gameObject.SetActive(false);
        _player.gameObject.SetActive(false);
        _playButton.onClick.AddListener(Restart);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(Restart);
    }

    private void Restart()
    {
        _player.gameObject.SetActive(true);
        _player.Restart();
        _spawner.gameObject.SetActive(true);
        _spawner.ResetPool();
        gameObject.SetActive(false);
    }
}
