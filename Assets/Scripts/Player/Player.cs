using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _effectMidleHealth;
    [SerializeField] private GameObject _effectLowHealth;

    private float _health;
    private float _maxHealth = 3;
    private int _score;

    public float MaxHealth => _maxHealth;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction<float> HealtChanged;

    private void Awake()
    {
        Restart();
    }

    public void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        HealtChanged?.Invoke(_health);

        if (_health <= GetTwoThirdsValue(_maxHealth))                   
           _effectMidleHealth.SetActive(true);


        if (_health <= GetHalfValue(_maxHealth))
            _effectLowHealth.SetActive(true);
    }

    public void Restart()
    {
        _health = _maxHealth;
        HealtChanged?.Invoke(_health);
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _effectLowHealth.SetActive(false);
        _effectMidleHealth.SetActive(false);
    }

    private float GetTwoThirdsValue(float value)
    {
        float result = (value / 3f) * 2f;
        return result;
    } 

    private float GetHalfValue(float value) 
    {
        float result = value / 2f;
        return result;
    }
}
