using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{
    public GameObject XRRigObject;
    public GameObject MainAvatarObject;
    public GameObject AvatarHeadObject;
    public GameObject AvatarBodyObject;
    public TextMeshProUGUI PlayerNameText;
    
    // Start is called before the first frame update
    void Start()
    {
        // Setup the player
        if (photonView.IsMine)
        {
            // The player is local
            XRRigObject.SetActive(true);
            gameObject.GetComponent<PlayerMovementController>().enabled = true;
            SetLayerRecursively(AvatarBodyObject, 8);
            SetLayerRecursively(AvatarHeadObject, 9);

            MainAvatarObject.AddComponent<AudioListener>();
        }
        else
        {
            // The player is remote
            XRRigObject.SetActive(false);
            gameObject.GetComponent<PlayerMovementController>().enabled = false;
            SetLayerRecursively(AvatarBodyObject, 0);
            SetLayerRecursively(AvatarHeadObject, 0);            
        }

        if (PlayerNameText != null)
        {
            PlayerNameText.text = photonView.Owner.NickName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (var trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}
