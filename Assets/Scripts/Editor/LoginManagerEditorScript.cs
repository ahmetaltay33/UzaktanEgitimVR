using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

[CustomEditor(typeof(LoginManager))]
public class LoginManagerEditorScript : Editor
{
    /*private string playerName = "YeniOyuncu";
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.HelpBox("Kullanıcı girişlerinden sorumlu editördür.", MessageType.Info);

        var man = (LoginManager) target;
        GUILayout.Label("Oyuncu Nick: ");
        playerName = GUILayout.TextField(playerName, 20);
        if (GUILayout.Button("Yeni Oturum Oluştur"))
        {
            man.ConnectToPhotonServer(playerName);
        }
    }*/
}
