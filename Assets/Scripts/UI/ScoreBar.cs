using UnityEngine;
using TMPro;
public class ScoreBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Score _score;

    private void OnEnable()
    {
        _score.ValueChanged += OnValueChanged;
    }

    private void Start()
    {
        _text.text = "SCORE .. 0";
    }

    private void OnDisable()
    {
        _score.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _text.text = "SCORE .. " + value.ToString();
    }
}
