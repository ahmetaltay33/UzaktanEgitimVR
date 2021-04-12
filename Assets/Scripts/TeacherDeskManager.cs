using TMPro;
using TMPro.EditorUtilities;
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
    public GameObject QuadVideoPlayer;

    private void Start()
    {
        panelMain.SetActive(true);
        panelVideoPlayer.SetActive(false);
        QuadVideoPlayer.SetActive(false);
    }

    public void OnClick_ButtonOtur()
    {
        if (vrPlayer != null)
        {
            var chairPos = chair.transform.position;
            vrPlayer.transform.position = new Vector3(chairPos.x + 0.16f, chairPos.y + 0.50f, chairPos.z);

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
            vrPlayer.transform.position = new Vector3(chairPos.x + 1, chairPos.y + 0.25f, chairPos.z);
            vrPlayer.GetComponent<PlayerMovementController>().enabled = true;
        }
    }

    public void OnClick_ButtonVideoOpen()
    {
        panelMain.SetActive(false);
        panelVideoPlayer.SetActive(true);
        QuadVideoPlayer.SetActive(true);
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
        QuadVideoPlayer.SetActive(false);
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
