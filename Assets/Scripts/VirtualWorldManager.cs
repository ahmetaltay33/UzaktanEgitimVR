using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class VirtualWorldManager : MonoBehaviourPunCallbacks
{

    #region Photon Callbacks Methods

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"Oyuncu {newPlayer.NickName}, {PhotonNetwork.CurrentRoom.Name} odaya katıldı. Oyuncu sayısı: {PhotonNetwork.CurrentRoom.PlayerCount}");
    }

    #endregion
    
}
