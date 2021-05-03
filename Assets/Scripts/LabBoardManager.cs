using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;

public class MicrochipDto
{
    public string Caption { get; set; }
    public string Details { get; set; }
    public string ImageUrl { get; set; }
    public string VideoUrl { get; set; }
}

public class LabBoardManager: MonoBehaviour
{
    [SerializeField]
    private GameObject panelMain;
    [SerializeField] 
    private GameObject panelContent;
    [SerializeField] 
    private GameObject panelDetailedText;
    [SerializeField] 
    private GameObject panelVideo;
    [SerializeField] 
    private TMP_Text textCaption;
    [SerializeField] 
    private TMP_Text textDetail;
    [SerializeField] 
    private Image image;
    [SerializeField] 
    private RawImage rawImage;
    [SerializeField] 
    private VideoPlayer videoPlayer;
    [SerializeField] 
    private Button buttonVideoPlayPause;
    [SerializeField] 
    private Sprite spriteVideoPlay;
    [SerializeField] 
    private Sprite spriteVideoPause;

    private List<MicrochipDto> microChips;
    private int totalData;
    private int activeDataIndex;
        
    private List<MicrochipDto> GetData()
    {
        // TODO: İçerik firebase den çekilebilir. Deneme amaçlı elle girildi. (Ahmet)
        return new List<MicrochipDto>(3)
        {
            new MicrochipDto
            {
                Caption = "STM32 ARM için EasyMx Pro v7 Geliştirme Kartı",
                Details = "USB 2.0 on-board programmer and debugger\n" +
                          "Board üzerindeki USB 2.0 destekli ST-LINK v2 programlama arabirimi, ilave bir programlayıcıya ihtiyaç duymadan ve ARM entegresini devre üzerinden sökmeden programlama imkanı sağlamaktadır. Programlayıcı sayesinde ana mikrodenetleyiciyi programlayabilir ve değişken değerleri görebilirsiniz. (Special Function Register, RAM, CODE ve EEPROM)",
                ImageUrl = "https://www.yildirimelektronik.com/urun/buyuk/8315e5d7-40c4-4e08-a2c1-6cdf21e7a941.jpg",
                VideoUrl = "https://unity3dcollege.blob.core.windows.net/site/YTDownloads/test.mp4"
            },
            new MicrochipDto
            {
                Caption = "Mikrodenetleyici Geliştirme Kartı",
                Details = "Easy PIC7 Kartı\n"+
                          "Ürün CD si\n"+
                          "USB Kablo\n"+
                          "Devre şeması ve kullanım kitabı\n"+
                          "Grafik LCD\n"+
                          "Touch panel\n"+
                          "Karakter LCD\n"+
                          "DS1820 ve LM35 Sıcaklık Sensörleri\n"+
                          "Kalem",
                ImageUrl = "https://www.yildirimelektronik.com/urun/buyuk/05a12465-a923-4878-9ddf-0988f76dd830.jpg",
                VideoUrl = "https://unity3dcollege.blob.core.windows.net/site/YTDownloads/test.mp4"
            },
            new MicrochipDto
            {
                Caption = "NodeMCU Uygulama Kartı",
                Details = "NodeMCU uygulama kartı, NodeMCU ESP8266 geliştirme kartı ile birlikte kullanılmak için tasarlanmış olan ve " +
                          "üzerinde farklı bir çok donanım barındıran bir eğitim seti olarak tanımlanabilir. NodeMCU Uygulama Kartı’nın " +
                          "tasarlanma amacı ESP8266 mikrodenetleyicisinin ülkemizde daha iyi tanınmasını sağlamak, yapılabilecek projeler " +
                          "için bir temel basamak oluşturmak ve kullanıcıya prototipleme aşamasında üzerindeki donanımlardan faydalandırarak " +
                          "kolaylık sağlamak olarak özetlenebilir. NodeMCU Uygulama Kartı üzerinde farklı donanımlar modüller haline " +
                          "getirilmiş ve her bir modülü aktif veya pasif edebilmek amacıyla bir modül seçme anahtarı eklenmiştir.",
                ImageUrl = "https://www.yildirimelektronik.com/urun/buyuk/10d53adc-b061-430e-a8bf-6dc820dd1469.jpg",
                VideoUrl = "https://unity3dcollege.blob.core.windows.net/site/YTDownloads/test.mp4"
            }
        };
    }

    private void Start()
    {
        microChips = GetData();
        totalData = microChips.Count;
        activeDataIndex = 0;
        SetUI(UIType.Main);
    }

    private void FillBoard(int index)
    {
        var data = microChips[index];
        textCaption.text = data.Caption;
        textDetail.text = data.Details;
        videoPlayer.url = data.VideoUrl;
        StartCoroutine(nameof(ImageLoader), data.ImageUrl);
    }

    private IEnumerator ImageLoader(string url)
    {
        var req = UnityWebRequestTexture.GetTexture(url);
        yield return req.SendWebRequest();
        if(req.isNetworkError || req.isHttpError)
            Debug.Log(req.error);
        else
            rawImage.texture = ((DownloadHandlerTexture) req.downloadHandler).texture;
    }
    
    private enum UIType
    {
        Main,
        Content,
        Detail,
        Video
    }
    private void SetUI(UIType uiType)
    {
        panelMain.SetActive(uiType == UIType.Main);
        panelContent.SetActive(uiType == UIType.Content);
        panelDetailedText.SetActive(uiType == UIType.Detail);
        panelVideo.SetActive(uiType == UIType.Video);
        buttonVideoPlayPause.image.sprite = spriteVideoPause;
    }
    
    public void Board_ButtonStart_OnClick()
    {
        SetUI(UIType.Content);
        activeDataIndex = 0;
        FillBoard(activeDataIndex);
    }

    public void Content_ButtonClose_OnClick()
    {
        SetUI(UIType.Main);
    }

    public void Content_ButtonNext_OnClick()
    {
        if (activeDataIndex == totalData - 1)
            activeDataIndex = 0;
        else
            activeDataIndex++;
        FillBoard(activeDataIndex);
    }

    public void Content_ButtonPrevious_OnClick()
    {
        if (activeDataIndex == 0)
            activeDataIndex = totalData - 1;
        else
            activeDataIndex--;
        FillBoard(activeDataIndex);
    }

    public void Content_ButtonDetail_OnClick()
    {
        SetUI(UIType.Detail);
    }

    public void Content_ButtonPlayVideo_OnClick()
    {
        SetUI(UIType.Video);
        videoPlayer.Play();
    }

    public void Detail_ButtonClose_OnClick()
    {
        SetUI(UIType.Content);
    }

    public void Video_ButtonClose_OnClick()
    {
        videoPlayer.Stop();
        SetUI(UIType.Content);
    }

    public void Video_ButtonPlayPause_OnClick()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            buttonVideoPlayPause.image.sprite = spriteVideoPlay;
        }
        else
        {
            videoPlayer.Play();
            buttonVideoPlayPause.image.sprite = spriteVideoPause;
        }
    }

    public void Video_ButtonStop_OnClick()
    {
        videoPlayer.Stop();
        videoPlayer.frame = 0;
        buttonVideoPlayPause.image.sprite = spriteVideoPlay;
    }
    
    public void Video_ButtonForward_OnClick()
    {
        videoPlayer.frame += 27 * 10;
    }
    
    public void Video_ButtonBackward_OnClick()
    {
        videoPlayer.frame -= 27 * 10;
    }
}