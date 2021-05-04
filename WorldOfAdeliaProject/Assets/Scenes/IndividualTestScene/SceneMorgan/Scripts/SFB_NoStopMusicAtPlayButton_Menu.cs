using UnityEngine;

public class NoStopMusicAtPlayButton_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
}
