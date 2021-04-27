using UnityEngine;
using UnityEngine.SceneManagement;

public class LabUIManager : MonoBehaviour
{
    public void ButtonExitLab_OnClick()
    {
        SceneManager.LoadScene("Scenes/LoginScene");
    }
}
