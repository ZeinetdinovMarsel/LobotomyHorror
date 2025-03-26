using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Volume volume;
    [SerializeField] private ChromaticAberration _chromaticAberration;
    [SerializeField] private Vignette _vignette;
    [SerializeField][Range(0.0f, 1.0f)] private float _healthValue;

    [SerializeField] private float _maxEffectValue;

    private void OnValidate()
    {
        if (volume.profile.TryGet<ChromaticAberration>(out _chromaticAberration))
        {
            _chromaticAberration.intensity.value = _healthValue;
        }
        else
        {
            _chromaticAberration = volume.profile.Add<ChromaticAberration>(true);
            _chromaticAberration.intensity.value = _healthValue;
        }

        if (volume.profile.TryGet<Vignette>(out _vignette))
        {
            _vignette.intensity.value = _healthValue;
        }
        else
        {
            _vignette = volume.profile.Add<Vignette>(true);
            _vignette.intensity.value = _healthValue;
        }

        SetEffectValue(_healthValue);
    }

    private void SetEffectValue(float value)
    {
        _chromaticAberration.intensity.value = Mathf.Clamp(value, 0, _maxEffectValue);
        _vignette.intensity.value = Mathf.Clamp(value, 0, _maxEffectValue);
    }
}
