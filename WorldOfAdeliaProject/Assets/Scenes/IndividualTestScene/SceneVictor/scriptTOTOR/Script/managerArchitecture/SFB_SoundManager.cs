using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

/// <summary>
/// Created by COUTURIEUX VICTOR
/// The main class SoundManager
/// instantiate once and automatically in the GameManager 
/// </summary>
/// <remarks>
/// can get all instant of all specific manager
/// and can be call in all unity scene because GameManager is a singleton instance
/// </remarks>
/// <remarks>
/// contain once AudioSource to play music
/// to player different sound effect, drag her AudioSource reference in 'PlaySoundFX' function
/// </remarks>
/// <remarks>
/// all sound is play in local scene of the game not in network
/// </remarks>
public class SFB_SoundManager : MonoBehaviour {
    /// <value>
    /// Audio Source Music player
    /// once music played in all scene
    /// Drag a reference to the audio source which will play the music.
    /// </value>
    public AudioSource musicSource; //Drag a reference to the audio source which will play the music.

    /// <value>
    /// music library
    /// </value>
    public AudioClip MainMenuTheme;

    public AudioClip LobbySong;
    public AudioClip[] StartLevelMusic;
    public AudioClip[] LevelsMusic;

    /// <value>
    /// sound effect library
    /// </value>
    public AudioClip[] ChangeColor;

    public AudioClip[] Dash;
    public AudioClip[] DestroyBullet;
    public AudioClip[] DestroyEnemyAbiss;
    public AudioClip[] DestroyEnemyRedFish;
    public AudioClip[] LostHearthShip;
    public AudioClip[] ShootingCannon;
    public AudioClip[] UXinteraction;
    public AudioClip Win;
    public AudioClip GameOver;

    /// <value>
    /// Sound Effect enumeration can be call in 'PlaySoundFX' function to play related sound effect
    /// </value>
    public enum SoundFX {
        ChangeColor,
        Dash,
        DestroyBullet,
        DestroyEnemyAbiss,
        DestroyEnemyRedFish,
        LostHearthShip,
        ShootingCannon,
        UXinteractionAccess,
        UXinteractionBack,
        UXinteractionLostServeur,
        Win,
        GameOver
    }


    ///<summary>
    /// Awake is always called before any Start functions
    /// </summary>
    void Awake() {
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    /// <summary>
    /// this is to call when the GameManager changes Unity scene.
    /// </summary>
    /// <param name="scene">scene to load</param>
    /// <param name="mode">load Scene mode (not used)</param>
    /// <remarks>Have specify instruction in all different scene</remarks>
    /// <remarks>
    /// duplicate code but it is explicit if we must make a particular change in a particular scene
    /// </remarks>
    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode) {
//        Debug.Log("Log Sound Manager");

        //by default the Music is playing in loop
        musicSource.loop = true;
        if (scene.name == GameManager.nameSceneMainMenuToLoad) {
            if (musicSource.clip != MainMenuTheme) {
                musicSource.clip = MainMenuTheme;
                musicSource.Play();
            }
        }
        else if (scene.name == GameManager.nameSceneConnectServerToLoad) {
            if (musicSource.clip != MainMenuTheme) {
                musicSource.clip = MainMenuTheme;
                musicSource.Play();
            }
        }
        else if (scene.name == GameManager.nameSceneLobbyShipToLoad) {
            if (musicSource.clip != LobbySong) {
                musicSource.clip = LobbySong;
                musicSource.Play();
            }
        }
        else if (scene.name == GameManager.nameSceneChoiceLevelToLoad) {
            if (musicSource.clip != MainMenuTheme) {
                musicSource.clip = MainMenuTheme;
                musicSource.Play();
            }
        }
        else if (scene.name == GameManager.nameScenelevel0ToLoad) {
            if (musicSource.clip != StartLevelMusic[0]) {
                musicSource.clip = StartLevelMusic[0];

                //the start music foreach level is playing once
                musicSource.loop = false;
                musicSource.Play();
            }
        }
        else if (scene.name == GameManager.nameScenelevel1ToLoad) {
            if (musicSource.clip != StartLevelMusic[1]) {
                musicSource.clip = StartLevelMusic[1];
                //the start music foreach level is playing once
                musicSource.loop = false;
                musicSource.Play();
            }
        }
        else if (scene.name == GameManager.nameScenelevel2ToLoad) {
            if (musicSource.clip != StartLevelMusic[2]) {
                musicSource.clip = StartLevelMusic[2];
                //the start music foreach level is playing once
                musicSource.loop = false;
                musicSource.Play();
            }
        }
    }

    // Start is called before the first frame  (not used)
    void Start() {
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    /// <remarks>Have specify instruction in all different scene</remarks>
    /// <remarks>
    /// duplicate code but it is explicit if we must make a particular change in a particular scene
    /// </remarks>
    void Update() {
        if (SceneManager.GetActiveScene().name == GameManager.nameSceneMainMenuToLoad) {
        }
        else if (SceneManager.GetActiveScene().name == GameManager.nameSceneConnectServerToLoad) {
        }
        else if (SceneManager.GetActiveScene().name == GameManager.nameSceneLobbyShipToLoad) {
        }
        else if (SceneManager.GetActiveScene().name == GameManager.nameSceneChoiceLevelToLoad) {
        }
        else if (SceneManager.GetActiveScene().name == GameManager.nameScenelevel0ToLoad) {
            if (musicSource.clip == StartLevelMusic[0]) {
                if (!musicSource.isPlaying) {
                    musicSource.clip = LevelsMusic[0];
                    //the loop music foreach level is playing in loop
                    musicSource.loop = true;
                    musicSource.Play();
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == GameManager.nameScenelevel1ToLoad) {
            if (musicSource.clip == StartLevelMusic[1]) {
                if (!musicSource.isPlaying) {
                    musicSource.clip = LevelsMusic[1];
                    //the loop music foreach level is playing in loop
                    musicSource.loop = true;
                    musicSource.Play();
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == GameManager.nameScenelevel2ToLoad) {
            if (musicSource.clip == StartLevelMusic[2]) {
                if (!musicSource.isPlaying) {
                    musicSource.clip = LevelsMusic[2];
                    //the loop music foreach level is playing in loop
                    musicSource.loop = true;
                    musicSource.Play();
                }
            }
        }
    }

    /// <summary>
    /// can be call in all unity scene to play specific sound effect
    /// </summary>
    /// <param name="efxSource">specific AudioSource reference</param>
    /// <param name="soundF">specific sound effect reference play on this first param AudioSource reference</param>
    public void PlaySoundFX(AudioSource efxSource, SoundFX soundF) {
        // select specific sound effect according to sound effect reference
        AudioClip[] clips = null;
        switch (soundF) {
            case SoundFX.ChangeColor:
                clips = ChangeColor;
                break;
            case SoundFX.Dash:
                clips = Dash;
                break;
            case SoundFX.DestroyBullet:
                clips = DestroyBullet;
                break;
            case SoundFX.DestroyEnemyAbiss:
                clips = DestroyEnemyAbiss;
                break;
            case SoundFX.DestroyEnemyRedFish:
                clips = DestroyEnemyRedFish;
                break;
            case SoundFX.LostHearthShip:
                clips = LostHearthShip;
                break;
            case SoundFX.ShootingCannon:
                clips = ShootingCannon;
                break;
            case SoundFX.UXinteractionAccess:
//                Debug.Log("UXinteraction Access");
                clips = new[] {UXinteraction[0]};
                break;
            case SoundFX.UXinteractionBack:
//                Debug.Log("UXinteraction Back");
                clips = new[] {UXinteraction[1]};
                break;
            case SoundFX.UXinteractionLostServeur:
//                Debug.Log("UXinteraction Lost Serveur");
                clips = new[] {UXinteraction[2]};
                break;
            case SoundFX.Win:
                clips = new[] {Win};
                break;
            case SoundFX.GameOver:
                clips = new[] {GameOver};
                break;
            default:
                Console.WriteLine("NO SOUND EFFECT FOR THIS");
                break;
        }

        if (clips != null) {
            //player random sound effect in library of the sound effect reference
            int randomIndex = Random.Range(0, clips.Length);
            efxSource.clip = clips[randomIndex];
            efxSource.loop = false;
            efxSource.Play();
        }
    }
}