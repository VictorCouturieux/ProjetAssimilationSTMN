using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace {
    public class MainMenuPlayGameButton : MonoBehaviour {
        public InputField InputFieldName;
        public Button GoButton;
        
        public AudioSource soundFX;
        private bool firstStart = true;

        public void OnMainMenu() {
            SceneManager.LoadScene(GameManager.nameSceneMainMenuToLoad);
            PhotonNetwork.Disconnect();
        }

        public void OnButton() {
            SceneManager.LoadScene(GameManager.nameSceneConnectServerToLoad);
        }

        //Awake is always called before any Start functions
        void Awake() {
            SceneManager.sceneLoaded += OnSceneFinishedLoading;
        }

        private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode) {
            if (GameManager.instance.PlayerManager.PseudoPlayerName != "") {
                if (InputFieldName) {
                    InputFieldName.text = GameManager.instance.PlayerManager.PseudoPlayerName;
                }
            }
        }

        private void Start() {
            if (SceneManager.GetActiveScene().name == GameManager.nameSceneMainMenuToLoad) {
                if (firstStart) {
                    firstStart = false;
                }
                else {
                    GameManager.instance.SoundManager.PlaySoundFX(soundFX, SFB_SoundManager.SoundFX.UXinteractionLostServeur); 
                }
            }else if (SceneManager.GetActiveScene().name == GameManager.nameSceneConnectServerToLoad) {
                GameManager.instance.SoundManager.PlaySoundFX(soundFX, SFB_SoundManager.SoundFX.UXinteractionAccess);
            }
        }

        void Update() {
            if (InputFieldName) {
                if (string.IsNullOrEmpty(InputFieldName.text)) {
                    GoButton.interactable = false;
                }
                else {
                    GoButton.interactable = true;
                    GameManager.instance.PlayerManager.PseudoPlayerName = InputFieldName.text;
                }
            }
        }

        public void QuitApp() {
#if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
            #endif
        }
    }
}