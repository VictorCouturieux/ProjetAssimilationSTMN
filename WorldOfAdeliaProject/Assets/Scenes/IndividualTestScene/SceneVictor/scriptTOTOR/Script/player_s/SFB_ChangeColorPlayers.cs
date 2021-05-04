using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created by COUTURIEUX VICTOR 
/// used in specific ship button to change the color of the player prefab instance
/// </summary>
/// <remarks>
/// can be optimized
/// </remarks>
public class SFB_ChangeColorPlayers : MonoBehaviour {
    // Start is called before the first frame update (not used)
    void Start() {
    }

    /// <summary>
    /// used if the player prefab instance go on the specific ship button to change him color
    /// </summary>
    /// <param name="other">player prefab collider instance</param>
    private void OnTriggerEnter(Collider other) {
        GameManager.instance.SoundManager.PlaySoundFX(GetComponent<AudioSource>(),
            SFB_SoundManager.SoundFX.ChangeColor);
        if (other.Equals(GameManager.instance.PlayerManager.MyPlayerInstance.GetComponent<Collider>())) {
            GameManager.instance.PlayerManager.Numbercolor++;
            if (GameManager.instance.PlayerManager.Numbercolor > 9) {
                GameManager.instance.PlayerManager.Numbercolor = 0;
            }
        }
//        Debug.Log("Change Color : " + GameManager.instance.PlayerManager.Numbercolor);
    }

    // Update is called once per frame (not used)
    void Update() {
    }
}