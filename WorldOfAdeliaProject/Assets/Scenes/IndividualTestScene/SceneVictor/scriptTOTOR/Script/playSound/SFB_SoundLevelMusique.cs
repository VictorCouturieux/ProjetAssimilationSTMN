using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Created by COUTURIEUX VICTOR
/// used to manage the current music volume on mute
/// </summary>
/// <remarks>
/// instantiate on the music menu manager in main menu ang break menu in game
/// </remarks>
public class SFB_SoundLevelMusique : MonoBehaviour {
    // Start is called before the first frame update (not used)
    void Start() {
    }

    /// <summary>
    /// set new value to the music volume
    /// </summary>
    /// <param name="slider"> update value of the music volume </param>
    public void setLevelSound(Slider slider) {
        GameManager.instance.SoundManager.musicSource.volume = slider.value;
    }

    /// <summary>
    /// mute music method
    /// </summary>
    /// <param name="toggle"> updated boolean in a toggle to mute music </param>
    public void setMuteSound(Toggle toggle) {
        GameManager.instance.SoundManager.musicSource.mute = !toggle.isOn;
    }

    // Update is called once per frame (not used)
    void Update() {
    }
}