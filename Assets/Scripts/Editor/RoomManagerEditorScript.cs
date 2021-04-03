using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RoomManager))]
public class RoomManagerEditorScript : Editor
{
    /*private string roomId = "3364";
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.HelpBox("Oda girişlerinden sorumlu editördür.", MessageType.Info);

        var man = (RoomManager) target;
        GUILayout.Label("Room ID: ");
        roomId = GUILayout.TextField(roomId, 20);
        if (GUILayout.Button("Yeni Oda Oluştur"))
        {
            man.CreateRoom(roomId);
        }
        if (GUILayout.Button("Odaya Katıl."))
        {
            man.JoinRoom(roomId);
        }
    }*/
}

