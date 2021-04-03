using Photon.Pun;
using UnityEngine;

public class LoginManager : MonoBehaviourPunCallbacks
{
    /*public void ConnectToPhotonServer(string playerName)
    {
        if (!string.IsNullOrWhiteSpace(playerName))
        {
            PhotonNetwork.NickName = playerName;
        }
        PhotonNetwork.ConnectUsingSettings();
    }
    
    public override void OnConnected()
    {
        base.OnConnected();
        Debug.Log("OnConnected çağrıldı. Sunucu erişilebilir durumda.");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log($"Ana sunucuya bağlantı kuruldu. Oyuncu adı: {PhotonNetwork.NickName}");
        PhotonNetwork.LoadLevel("Classroom");
    }*/
}
