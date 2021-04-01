using Photon.Pun;
using UnityEngine;

public class LoginManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnected()
    {
        base.OnConnected();
        Debug.Log("OnConnected çağrıldı. Sunucu erişilebilir durumda.");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Ana sunucuya bağlantı kuruldu.");
    }
}
