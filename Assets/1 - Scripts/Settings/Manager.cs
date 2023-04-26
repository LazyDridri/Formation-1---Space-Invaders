using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Settings
{
  public class Manager : MonoBehaviour
  {
    #region Inspector
    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField] private Slider generalVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider gameplayVolumeSlider;
    #endregion

    #region Monobehaviour Methods
    private void Start()
    {
      // Load settings for sliders
      LoadSettings(Statics.generalVolumeSliderSettings, generalVolumeSlider, 5.0f);
      LoadSettings(Statics.musicVolumeSliderSettings, musicVolumeSlider, 5.0f);
      LoadSettings(Statics.gameplayVolumeSliderSettings, gameplayVolumeSlider, 5.0f);
    }
    #endregion

    #region Public Methods
    public void ValueChangedGeneralSlider()
    {
      ApplySettings(Statics.generalVolumeSliderSettings, generalVolumeSlider, Statics.generalAudioMixerParameters);
    }

    public void ValueChangedMusicSlider()
    {
      ApplySettings(Statics.musicVolumeSliderSettings, musicVolumeSlider, Statics.musicAudioMixerParameters);
    }

    public void ValueChangedGameplaySlider()
    {
      ApplySettings(Statics.gameplayVolumeSliderSettings, gameplayVolumeSlider, Statics.gameplayAudioMixerParameters);
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Load values for sound sliders
    /// </summary>
    /// <param name="settingsName">Name of the setting for PlayerPrefs</param>
    /// <param name="slider">Slider to set</param>
    /// <param name="defaultValue">Default value for the slider</param>
    private void LoadSettings(string settingsName, Slider slider, float defaultValue)
    {
      // Check if the setting already exists and set default value if not
      if (!PlayerPrefs.HasKey(settingsName))
        PlayerPrefs.SetFloat(settingsName, defaultValue);

      // Get saved value for the slider
      float sliderValue = PlayerPrefs.GetFloat(settingsName);

      // Apply value to the slider
      slider.value = sliderValue;
    }
    #endregion

    /// <summary>
    /// Apply settings for sound slider
    /// </summary>
    /// <param name="settingsName"></param>
    /// <param name="slider"></param>
    /// <param name="audioSettingsName"></param>
    private void ApplySettings(string settingsName, Slider slider, string audioSettingsName)
    {
      // Apply settings to audio mixer
      audioMixer.SetFloat(audioSettingsName, Mathf.Log10(slider.value) * 20.0f);

      // Save settings in PlayerPrefs
      PlayerPrefs.SetFloat(settingsName, slider.value);
    }

  }
}

