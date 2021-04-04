﻿using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;

#endif

public class MicPermissionHelper : MonoBehaviour
{
    void Start()

    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
    }
}