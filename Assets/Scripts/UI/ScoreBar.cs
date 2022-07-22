using UnityEngine;
using TMPro;
public class ScoreBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Score _score;

    private void Start()
    {
        _text.text = "SCORE .. 0";
    }

    private void OnEnable()
    {
        _score.ValueChanged += SetScore;
    }

    private void OnDisable()
    {
        _score.ValueChanged -= SetScore;
    }

    private void SetScore(int value)
    {
        _text.text = "SCORE .. " + value.ToString();
    }
}
