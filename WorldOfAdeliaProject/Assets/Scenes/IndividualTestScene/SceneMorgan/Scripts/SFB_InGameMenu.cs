using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class InGameMenu : MonoBehaviour
    {
        public GameObject pausePanel;

        public LoadLevelScript loadLevelScript;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pausePanel.activeSelf == false)
                {
                    Debug.Log("Game Paused");
                    pausePanel.SetActive(true);
                }
                else
                {
                    Debug.Log("Game Paused closed");
                    pausePanel.SetActive(false);
                }
            }
        }

        public void CloseMenu()
        {
            pausePanel.SetActive(false);
        }
        
        public void QuitLobby()
        {
            pausePanel.SetActive(false);
            
            SceneManager.LoadScene(GameManager.nameSceneMainMenuToLoad);
            PhotonNetwork.Disconnect();
        }
    }
}