using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created by COUTURIEUX VICTOR
/// used player sound effect when you click on the button menu to go back to last menu
/// </summary>
/// <remarks>
/// can be optimised with the SFB_AccessSoundFX
/// created in a very short time
/// </remarks>
public class SFB_BackSoundFX : MonoBehaviour {
    /// <value>Audio source reference</value>
    public AudioSource soundFX;

    /// <summary>
    /// play the sound effect relative to go back to last menu
    /// </summary>
    public void PlayBackSoundFX() {
        GameManager.instance.SoundManager.PlaySoundFX(soundFX,
            SFB_SoundManager.SoundFX.UXinteractionBack);
    }
}