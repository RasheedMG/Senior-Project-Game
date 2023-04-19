using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class CustomAudioSlider : MonoBehaviour
{
    [Serializable]
    public class SliderValueChangedEvent : UnityEvent<float, string> { }

    [SerializeField]
    private VolumeChannel _volumeChannel;

    public SliderValueChangedEvent OnCustomValueChanged;

    private Slider slider;

    private enum VolumeChannel
    {
        masterVolume,
        musicVolume,
        environmentVolume,
        effectsVolume
    }

    private void OnEnable()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float volume)
    {
        if (OnCustomValueChanged != null)
        {
            OnCustomValueChanged.Invoke(volume, _volumeChannel.ToString());
        }
    }

    private void OnDisable()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }
}