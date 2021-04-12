using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject GenericVRPlayerPrefab;
    [SerializeField]
    public List<VrChairManager> Chairs;
    [SerializeField]
    public TeacherDeskManager teacherDesk;

    public Vector3 SpawnPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            var newPlayer = PhotonNetwork.Instantiate(GenericVRPlayerPrefab.name, SpawnPosition, Quaternion.identity);
            foreach (var chair in Chairs)
            {
                chair.VrPlayer = newPlayer;
            }

            teacherDesk.vrPlayer = newPlayer;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
