using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class TeacherDeskManager : MonoBehaviour
{
    [Header("Runtime Adapting Objects")]
    [SerializeField]
    public GameObject vrPlayer;
    [SerializeField]
    public VideoPlayer videoPlayer;
    
    [Header("Design Time Adapting Objects")]
    [SerializeField]
    public GameObject lookTarget;
    [SerializeField]
    public GameObject chair;
    [SerializeField]
    public GameObject panelMain;
    [SerializeField]
    public GameObject panelVideoPlayer;
    [SerializeField] 
    public TMP_InputField inputFieldVideoPlayer;
    [SerializeField]
    public TMP_Text buttonPlayPauseText;
    [SerializeField]
    public GameObject quadVideoPlayer;

    private PhotonView photonView => PhotonView.Get(this);
    
    private void Start()
    {
        panelMain.SetActive(true);
        panelVideoPlayer.SetActive(false);
        quadVideoPlayer.SetActive(false);
    }

    public void OnClick_ButtonOtur()
    {
        if (vrPlayer != null)
        {
            var chairPos = chair.transform.position;
            vrPlayer.transform.position = new Vector3(chairPos.x + 0.16f, Constants.PlayerSitedPositionY, chairPos.z);

            var lookPos = lookTarget.transform.position - vrPlayer.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);

            vrPlayer.transform.rotation = Quaternion.Euler(rotation.eulerAngles);

            vrPlayer.GetComponent<PlayerMovementController>().enabled = false;
        }
    }
    
    public void OnClick_ButtonKalk()
    {
        if (vrPlayer != null)
        {
            var chairPos = chair.transform.position;
            vrPlayer.transform.position = new Vector3(chairPos.x + 1, Constants.PlayerPositionY, chairPos.z);
            vrPlayer.GetComponent<PlayerMovementController>().enabled = true;
        }
    }

    public void OnClick_ButtonVideoOpen()
    {
        panelMain.SetActive(false);
        panelVideoPlayer.SetActive(true);
        quadVideoPlayer.SetActive(true);
        videoPlayer.url = inputFieldVideoPlayer.text;
        photonView.RPC(nameof(RpcVideoUrl), RpcTarget.AllBuffered, inputFieldVideoPlayer.text);
        OnClick_ButtonVideoPlayPause();
    }
    
    public void OnClick_ButtonVideoPlayPause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            photonView.RPC(nameof(RpcVideoPause), RpcTarget.AllBuffered);            
            buttonPlayPauseText.text = "Oynat";
        }
        else
        {
            videoPlayer.Play();
            photonView.RPC(nameof(RpcVideoPlay), RpcTarget.AllBuffered);            
            buttonPlayPauseText.text = "Duraklat";
        }
    }
    
    public void OnClick_ButtonVideoStop()
    {
        videoPlayer.Stop();
        photonView.RPC(nameof(RpcVideoStop), RpcTarget.AllBuffered);
        buttonPlayPauseText.text = "Oynat";
    }

    public void OnClick_ButtonVideoBack()
    {
        videoPlayer.Stop();
        photonView.RPC(nameof(RpcVideoStop), RpcTarget.AllBuffered);
        buttonPlayPauseText.text = "Oynat";
        panelMain.SetActive(true);
        panelVideoPlayer.SetActive(false);
        quadVideoPlayer.SetActive(false);
    }

    public void OnClick_ButtonVideoForward()
    {
        Debug.Log("Video Forwarded.");
    }
    
    public void OnClick_ButtonVideoBackward()
    {
        Debug.Log("Video Backwarded.");
    }

    [PunRPC]
    public void RpcVideoUrl(string url)
    {
        videoPlayer.url = url;
        Debug.Log("RPC Video URL Değişti. URL: " + url);
    }
    
    [PunRPC]
    public void RpcVideoPlay()
    {
        videoPlayer.Play();
        Debug.Log("RPC Video Oynatıldı.");
    }
    
    [PunRPC]
    public void RpcVideoPause()
    {
        videoPlayer.Pause();
        Debug.Log("RPC Video Duraklatıldı.");
    }
    
    [PunRPC]
    public void RpcVideoStop()
    {
        videoPlayer.Stop();
        Debug.Log("RPC Video Durduruldu.");
    }
}
