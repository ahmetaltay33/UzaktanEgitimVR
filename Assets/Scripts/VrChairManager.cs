using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrChairManager : MonoBehaviour
{
    public GameObject VrPlayer;
    public GameObject LookTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ButtonOtur_OnClick()
    {
        Debug.Log("Otur tetiklendi.");
        if (VrPlayer != null)
        {
            Debug.Log(VrPlayer);
            
            VrPlayer.transform.position = new Vector3(this.transform.position.x + 0.16f, this.transform.position.y + 0.50f, this.transform.position.z);

            var lookPos = LookTarget.transform.position - VrPlayer.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            Debug.Log("Rotating VR Player: " + rotation.eulerAngles);
            VrPlayer.transform.rotation = Quaternion.Euler(rotation.eulerAngles);

            VrPlayer.GetComponent<PlayerMovementController>().enabled = false;
        }
    }
    
    public void ButtonKalk_OnClick()
    {
        Debug.Log("Kalk tetiklendi.");
        if (VrPlayer != null)
        {
            Debug.Log(VrPlayer);
            VrPlayer.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y + 0.25f, this.transform.position.z);
            VrPlayer.GetComponent<PlayerMovementController>().enabled = true;
        }
    }
    
    public void ButtonMicAc_OnClick()
    {
        Debug.Log("Mic Aç tetiklendi.");
        if (VrPlayer != null)
        {
            Debug.Log(VrPlayer);
            // TODO: oyuncunun microfonu açılıp kapatılacak
        }
    }
}
