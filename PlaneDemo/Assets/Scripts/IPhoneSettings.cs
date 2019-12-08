using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPhoneSettings : MonoBehaviour
{

    // Ensured that landscape mode is used if the build is switched to IOS
    void Start()
    {
        #if UNITY_EDITOR
            Debug.Log("This build is for Windows PC platoforms");
        #endif

        #if UNITY_IOS
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        #endif
    }
}
