using System;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class audioSlider : MonoBehaviour
{
    private enum AudioChannel
    {
        masterVolume,
        musicVolume,
        environmentVolume,
        effectsVolume
    }

    [SerializeField]
    private AudioChannel audioChannel;
    
    [SerializeField]
    private TextMeshProUGUI _sliderText;
    
    [SerializeField]
    private Slider _slider;

    private void OnEnable()
    {
        // This updates the slider values based on what was saved in previous sessions (in playerprefs)
        float volume = VolumeController.Instance.GetVolume(audioChannel.ToString());
        SetSliderValue(volume + 80);
        UpdateText(volume + 80);
    }

    private void SetSliderValue(float value)
    {
        value = Mathf.Clamp(value, 0, 100);
        _slider.SetValueWithoutNotify(value);
    }

    public void UpdateVolume()
    {
        float volume = _slider.value; 
        VolumeController.Instance.SetVolume(volume, audioChannel.ToString());
        UpdateText(volume);
    }

    private void UpdateText(float value) => _sliderText.text = value.ToString();
}
