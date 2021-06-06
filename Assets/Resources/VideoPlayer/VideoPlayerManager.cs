using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    [SerializeField]
    private Image imageProgress;

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.frameCount > 0)
            imageProgress.fillAmount = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
    }
}
