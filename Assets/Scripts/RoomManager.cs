using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomManager : MonoBehaviourPunCallbacks
{
    /*public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        var roomName = "RandomRoom_" + Random.Range(0, 10000);
        CreateRoom(roomName);
        JoinRoom(roomName);
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log($"Oda oluşturuldu, oda adı: {PhotonNetwork.CurrentRoom.Name}");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log($"Yerel oyuncu {PhotonNetwork.NickName}, {PhotonNetwork.CurrentRoom.Name} odasına katıldı. Oyuncu sayısı: {PhotonNetwork.CurrentRoom.PlayerCount}");
        PhotonNetwork.LoadLevel("Classroom");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log($"{newPlayer.NickName} isimli oyuncu {PhotonNetwork.CurrentRoom.Name} odaya katıldı.");
        Debug.Log($"Toplam oyuncu sayısı: {PhotonNetwork.CurrentRoom.PlayerCount}");        
    }

    public void CreateRoom(string roomName)
    {
        var options = new RoomOptions()
        {
            MaxPlayers = 20,
        };
        PhotonNetwork.CreateRoom(roomName, options);
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }*/
}