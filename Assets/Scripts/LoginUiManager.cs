using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginUiManager : MonoBehaviourPunCallbacks
{
    /// <summary>Giriş ekranında oluşacak durumları son kullanıcıya göstermek için kullanılır.</summary>
    public Text txtCaption;
    public Text txtAlert;

    public GameObject pnlMain;
    public GameObject pnlConnect;
    public GameObject pnlCreateOrJoinRoom;
    public InputField inpPlayerName;
    public InputField inpRoomId;

    private void Start()
    {
        SetUI(UITypes.Main);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void EnterClassroom_OnClick()
    {
        SetUI(UITypes.Connect);    
    }

    public void EnterLab_OnClick()
    {
        SetUI(UITypes.Joining);
        SceneManager.LoadScene("LabScene");
    }
    
    public void Connect_OnClick()
    {
        if (string.IsNullOrWhiteSpace(inpPlayerName.text))
        {
            ShowAlert("Kullanıcı Adı Girilmedi!");
            return;
        }
        PhotonNetwork.NickName = inpPlayerName.text;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void ConnectBack_OnClick()
    {
        SetUI(UITypes.Main);
    }

    public void CreateOrJoinRoom_OnClick()
    {
        if (string.IsNullOrWhiteSpace(inpRoomId.text))
        {
            ShowAlert("Oda ID girilmedi!");
            return;
        }
        JoinRoom(inpRoomId.text);
    }

    #region PUN Callbacks

    public override void OnConnected()
    {
        Debug.Log("OnConnected çağrıldı. Sunucu erişilebilir durumda.");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log($"Ana sunucuya bağlantı kuruldu. Oyuncu adı: {PhotonNetwork.NickName}");
        SetUI(UITypes.Room);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"OnJoinRoomFailed, returnCode: {returnCode}, message: {message}");
        CreateRoom(inpRoomId.text);
        JoinRoom(inpRoomId.text);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log($"Oda oluşturuldu, oda adı: {PhotonNetwork.CurrentRoom.Name}");
    }

    public override void OnJoinedRoom()
    {
        SetUI(UITypes.Joining);
        Debug.Log(
            $"Yerel oyuncu {PhotonNetwork.NickName}, {PhotonNetwork.CurrentRoom.Name} odasına katıldı. Oyuncu sayısı: {PhotonNetwork.CurrentRoom.PlayerCount}");
        PhotonNetwork.LoadLevel("ClassroomScene");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log($"{newPlayer.NickName} isimli oyuncu {PhotonNetwork.CurrentRoom.Name} odaya katıldı.");
        Debug.Log($"Toplam oyuncu sayısı: {PhotonNetwork.CurrentRoom.PlayerCount}");
    }

    #endregion

    private void CreateRoom(string roomName)
    {
        var options = new RoomOptions()
        {
            MaxPlayers = 20,
        };
        PhotonNetwork.CreateRoom(roomName, options);
    }

    private void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    private void ShowAlert(string msg)
    {
        txtAlert.text = msg;
        txtAlert.gameObject.SetActive(true);
    }

    private void CloseAlert()
    {
        txtAlert.text = "";
        txtAlert.gameObject.SetActive(false);
    }

    private enum UITypes
    {
        Main,
        Connect,
        Room,
        Joining
    }

    private void SetUI(UITypes uiType)
    {
        CloseAlert();
        switch (uiType)
        {
            case UITypes.Main:
            {
                txtCaption.text = "Ana Menü";
                pnlMain.SetActive(true);
                pnlConnect.SetActive(false);
                pnlCreateOrJoinRoom.SetActive(false);
            }
                break;
            case UITypes.Connect:
            {
                txtCaption.text = "İsminizi Giriniz";
                pnlMain.SetActive(false);
                pnlConnect.SetActive(true);
                pnlCreateOrJoinRoom.SetActive(false);
            }
                break;
            case UITypes.Room:
            {
                txtCaption.text = "Oda Numarasını Giriniz";
                pnlMain.SetActive(false);
                pnlConnect.SetActive(false);
                pnlCreateOrJoinRoom.SetActive(true);
            }
                break;
        }
    }
}