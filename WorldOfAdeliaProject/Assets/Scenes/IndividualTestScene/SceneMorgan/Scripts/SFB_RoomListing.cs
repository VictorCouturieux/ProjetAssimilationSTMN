using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
    /**
     * Getters et Setters pour les différents éléments de la liste des serveurs
     */
    [SerializeField]
    private Button _button;
    private Button Button
    {
        get { return _button; }
    }
    
    
    [SerializeField]
    private Text _roomNameText;
    private Text RoomNameText
    {
        get { return _roomNameText; }
    }
    
    [SerializeField]
    private Text _NBPlayerText;
    public Text NBPlayerText
    {
        get { return _NBPlayerText; }
    }

    public string RoomName { get; private set; }
    public bool Updated { get; set; }

    // Start is called before the first frame update
    private void Start()
    {
        //Instanciation de la liste de serveurs
//        Debug.Log("RoomListing Start");
//        GameObject lobbyCanvasObj = MainCanvasManager.Instance.LobbyCanvas.gameObject;
//        if (lobbyCanvasObj == null)
//            return;
////
//        LobbyCanvas lobbyCanvas = lobbyCanvasObj.GetComponent<LobbyCanvas>();

        //Ajout de bouttons pour chaque serveur
//        Button.onClick.AddListener(() => lobbyCanvas.OnClickJoinRoom(RoomNameText.text));
    }

    /**
     * Methode de suppression de tous les boutons
     */
    private void OnDestroy()
    {
//        Button button = GetComponent<Button>();
//        button.onClick.RemoveAllListeners();
    }

    /**
     * Remplissage de la zone de texte des boutons
     */
    public void SetRoomNameText (string text)
    {
        RoomName = text;
        RoomNameText.text = RoomName;
    }

    public void JoinServeur() {
        Debug.Log("RoomListing Start : " + RoomNameText.text);
        PhotonNetwork.JoinRoom(RoomNameText.text);
    }
    
}
