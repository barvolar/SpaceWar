using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;
    [SerializeField] private Menu _menu;

    private float _currentValue;
    private float _speedChanged=1.2f;

    private void OnEnable()
    {
        _player.HealtChanged += ChangedCurrentValue;
    }

    private void OnDisable()
    {
        _player.HealtChanged -= ChangedCurrentValue;
    }

    private void Update()
    {
        if (_currentValue != _slider.value)
            StartCoroutine(ChangedSliderValue());
        else
            StopCoroutine(ChangedSliderValue());

        if (_currentValue <= 0)
            _menu.gameObject.SetActive(true);
    }

    private void ChangedCurrentValue(float value)
    {
        if (_slider.maxValue != _player.MaxHealth)
            _slider.maxValue = _player.MaxHealth;

        _currentValue = value;
    }

    private IEnumerator ChangedSliderValue()
    {
        while (_currentValue != _slider.value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _currentValue, _speedChanged*Time.deltaTime);

            yield return null;
        }
    }
}
