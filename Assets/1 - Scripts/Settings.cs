using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
  public AudioMixer audioMixer;

  public Slider generalVolumeSlider;
  public Slider musicVolumeSlider;
  public Slider gameplayVolumeSlider;

  private void Start()
  {
    if (!PlayerPrefs.HasKey("generalVolumeSlider"))
      PlayerPrefs.SetFloat("generalVolumeSlider", 5.0f);
    float generalVolumeSliderValue = PlayerPrefs.GetFloat("generalVolumeSlider");
    generalVolumeSlider.value = generalVolumeSliderValue;

    if (!PlayerPrefs.HasKey("musicVolumeSlider"))
      PlayerPrefs.SetFloat("musicVolumeSlider", 5.0f);
    float musicVolumeSliderValue = PlayerPrefs.GetFloat("musicVolumeSlider");
    musicVolumeSlider.value = musicVolumeSliderValue;

    if (!PlayerPrefs.HasKey("gameplayVolumeSlider"))
      PlayerPrefs.SetFloat("gameplayVolumeSlider", 5.0f);
    float gameplayVolumeSliderValue = PlayerPrefs.GetFloat("gameplayVolumeSlider");
    gameplayVolumeSlider.value = gameplayVolumeSliderValue;
  }

  public void ValueChangedGeneralSlider()
  {
    audioMixer.SetFloat("generalVolume", Mathf.Log10(generalVolumeSlider.value) * 20.0f);
    PlayerPrefs.SetFloat("generalVolumeSlider", generalVolumeSlider.value);
  }

  public void ValueChangedMusicSlider()
  {
    audioMixer.SetFloat("musicVolume", Mathf.Log10(musicVolumeSlider.value) * 20.0f);
    PlayerPrefs.SetFloat("musicVolumeSlider", musicVolumeSlider.value);
  }

  public void ValueChangedGameplaySlider()
  {
    audioMixer.SetFloat("gameplayVolume", Mathf.Log10(gameplayVolumeSlider.value) * 20.0f);
    PlayerPrefs.SetFloat("gameplayVolumeSlider", gameplayVolumeSlider.value);
  }
}
