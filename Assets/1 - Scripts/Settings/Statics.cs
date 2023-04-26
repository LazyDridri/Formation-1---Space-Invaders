using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
  public class Statics : MonoBehaviour
  {
    // Audio Mixer parameters
    static public string generalAudioMixerParameters = "generalVolume";
    static public string musicAudioMixerParameters = "musicVolume";
    static public string gameplayAudioMixerParameters = "gameplayVolume";

    // Player Prefs settings name
    static public string generalVolumeSliderSettings = "generalVolumeSlider";
    static public string musicVolumeSliderSettings = "musicVolumeSlider";
    static public string gameplayVolumeSliderSettings = "gameplayVolumeSlider";
  }
}

