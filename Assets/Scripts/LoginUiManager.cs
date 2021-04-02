using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LoginUiManager : MonoBehaviour
{
    /// <summary>Giriş ekranında oluşacak durumları son kullanıcıya göstermek için kullanılır.</summary>
    [FormerlySerializedAs("Caption Text")] 
    public Text txtCaption;
    [FormerlySerializedAs("Connect Option Panel")]
    public GameObject pnlConnectOptions;
    [FormerlySerializedAs("Connect With Name Panel")]
    public GameObject pnlConnectWithName;
    [FormerlySerializedAs("Name Input")]
    public InputField inpName;

    private void Start()
    {
        SetDefaults();
    }

    public void ConnectWithName_OnClick()
    {
        txtCaption.text = "İsminizi Giriniz";
        pnlConnectWithName.SetActive(true);
        pnlConnectOptions.SetActive(false);
    }
    
    public void ConnectAnonymous_OnClick()
    {
        txtCaption.text = "Anonim giriş yapılıyor...";
    }
    
    public void Connect_OnClick()
    {
        txtCaption.text = inpName.text + " isimi ile giriş yapılıyor...";
    }
    
    public void ConnectBack_OnClick()
    {
        SetDefaults();
    }

    private void SetDefaults()
    {
        txtCaption.text = "Uzaktan Eğitim Giriş";
        pnlConnectWithName.SetActive(false);
        pnlConnectOptions.SetActive(true);
    }
}
