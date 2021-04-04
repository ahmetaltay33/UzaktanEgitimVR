using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class VirtualWorldManager : MonoBehaviourPunCallbacks
{

    public static VirtualWorldManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    public void LeaveRoomAndLoadHomeScene()
    {
        PhotonNetwork.LeaveRoom();
    }
    
    #region Photon Callbacks Methods

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"Oyuncu {newPlayer.NickName}, {PhotonNetwork.CurrentRoom.Name} odaya katıldı. Oyuncu sayısı: {PhotonNetwork.CurrentRoom.PlayerCount}");
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        PhotonNetwork.LoadLevel("LoginScene") ;
    }

    #endregion
    
}
