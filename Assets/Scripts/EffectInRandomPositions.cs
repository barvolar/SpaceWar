using UnityEngine;

public class EffectInRandomPositions : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _effects;

    private void OnEnable()
    {
        _effects[Random.Range(0, _effects.Length)].Play();
    }

    private void OnDisable()
    {
        foreach (var effect in _effects)
        {
            if (effect.isPlaying)
                effect.Stop();
        }
    }
}
