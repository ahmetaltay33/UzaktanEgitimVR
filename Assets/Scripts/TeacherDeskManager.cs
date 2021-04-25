using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class TeacherDeskManager : MonoBehaviour
{
    [SerializeField]
    public GameObject vrPlayer;
    [SerializeField]
    public GameObject lookTarget;
    [SerializeField]
    public VideoPlayer videoPlayer;
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
        OnClick_ButtonVideoPlayPause();
    }
    
    public void OnClick_ButtonVideoPlayPause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            buttonPlayPauseText.text = "Oynat";
        }
        else
        {
            videoPlayer.Play();
            buttonPlayPauseText.text = "Duraklat";
        }
    }
    
    public void OnClick_ButtonVideoStop()
    {
        videoPlayer.Stop();
        buttonPlayPauseText.text = "Oynat";
    }

    public void OnClick_ButtonVideoBack()
    {
        videoPlayer.Stop();
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
}
