using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobiUIManager : MonoBehaviourPunCallbacks
{
    /// <summary>Giriş ekranında oluşacak durumları son kullanıcıya göstermek için kullanılır.</summary>
    public TMP_Text TextCanliDersBaslik;
    public TMP_Text TextCanliDersUyari;

    public GameObject PanelCanliDersAna;
    public GameObject PanelCanliDersBaglan;
    public GameObject PanelCanliDersOdayaKatil;
    public TMP_InputField InputOyuncuAdi;
    public TMP_InputField InputOdaNo;

    private void Start()
    {
        SetUI(UITypes.Main);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void ButtonCanliDers_OnClick()
    {
        SetUI(UITypes.Connect);
    }

    public void ButtonLab_OnClick()
    {
        SetUI(UITypes.Joining);
        SceneManager.LoadScene("LabScene");
    }

    public void ButtonCikis_OnClick()
    {
        Application.Quit();
    }

    public void ButtonCanliDersBaglan_OnClick()
    {
        if (string.IsNullOrWhiteSpace(InputOyuncuAdi.text))
        {
            ShowAlert("Kullanıcı Adı Girilmedi!");
            return;
        }

        PhotonNetwork.NickName = InputOyuncuAdi.text;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void ButtonCanliDersVagec_OnClick()
    {
        SetUI(UITypes.Main);
    }

    public void ButtonCanliDersOdaKatil_OnClick()
    {
        if (string.IsNullOrWhiteSpace(InputOdaNo.text))
        {
            ShowAlert("Oda ID girilmedi!");
            return;
        }

        JoinRoom(InputOdaNo.text);
    }
    
    public void ButtonCanliDersOdaVazgec_OnClick()
    {
        PhotonNetwork.Disconnect();
        SetUI(UITypes.Connect);
    }

    #region PUN Callbacks

    public override void OnConnected()
    {
        Debug.Log("OnConnected çağrıldı. Sunucu erişilebilir durumda.");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log($"Ana sunucuya bağlantı kuruldu. Oyuncu adı: {PhotonNetwork.NickName}");
        PhotonNetwork.JoinLobby();
        SetUI(UITypes.Room);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"OnJoinRoomFailed, returnCode: {returnCode}, message: {message}");
        CreateRoom(InputOdaNo.text);
        JoinRoom(InputOdaNo.text);
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
        TextCanliDersUyari.text = msg;
        TextCanliDersUyari.gameObject.SetActive(true);
    }

    private void CloseAlert()
    {
        TextCanliDersUyari.text = "";
        TextCanliDersUyari.gameObject.SetActive(false);
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
                TextCanliDersBaslik.gameObject.SetActive(false);
                PanelCanliDersAna.SetActive(true);
                PanelCanliDersBaglan.SetActive(false);
                PanelCanliDersOdayaKatil.SetActive(false);
            }
                break;
            case UITypes.Connect:
            {
                TextCanliDersBaslik.text = "İsminizi Giriniz";
                TextCanliDersBaslik.gameObject.SetActive(true);
                PanelCanliDersAna.SetActive(false);
                PanelCanliDersBaglan.SetActive(true);
                PanelCanliDersOdayaKatil.SetActive(false);
            }
                break;
            case UITypes.Room:
            {
                TextCanliDersBaslik.text = "Oda Numarasını Giriniz";
                TextCanliDersBaslik.gameObject.SetActive(true);
                PanelCanliDersAna.SetActive(false);
                PanelCanliDersBaglan.SetActive(false);
                PanelCanliDersOdayaKatil.SetActive(true);
            }
                break;
        }
    }
}