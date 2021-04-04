using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LabUIManager : MonoBehaviour
{

    public void ExitLab_OnClick()
    {
        SceneManager.LoadScene("Scenes/LoginScene");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
