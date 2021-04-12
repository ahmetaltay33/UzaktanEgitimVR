using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    private VideoPlayer player;
    [SerializeField]
    public string VideoUrl;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInChildren<VideoPlayer>();
        player.url = VideoUrl;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPlay_OnClick()
    {
        Debug.Log("Play tıklandı.");
        Debug.Log("Video URL: " + player.url);
        player.Play();
    }
    
    public void ButtonPause_OnClick()
    {
        Debug.Log("Pause tıklandı.");
        player.Pause();
    }
}
