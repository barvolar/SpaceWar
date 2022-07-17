using UnityEngine;
using TMPro;
public class ScoreBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Player _player;

    private void Start()
    {
        _score.text = "SCORE .. 0";
    }

    private void OnEnable()
    {
        _player.ScoreChanged += SetScore;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= SetScore;
    }

    private void SetScore(int value)
    {
        _score.text = "SCORE .. " + value.ToString();
    }
}
