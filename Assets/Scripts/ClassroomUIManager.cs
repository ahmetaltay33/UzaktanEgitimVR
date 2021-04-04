using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassroomUIManager : MonoBehaviour
{
    public void ExitClassroom_OnClick()
    {
        VirtualWorldManager.Instance.LeaveRoomAndLoadHomeScene();    
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
