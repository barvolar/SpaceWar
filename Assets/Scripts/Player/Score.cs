using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    private int _value;

    public int Value => _value;
    public event UnityAction<int> ValueChanged;

    public void Add()
    {
        _value++;
        ValueChanged?.Invoke(_value);
    }

    public void Restart()
    {
        _value = 0;
        ValueChanged?.Invoke(_value);
    }
}
