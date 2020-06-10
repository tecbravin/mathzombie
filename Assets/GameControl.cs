using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
// In the Start function of this script I call a function on the webpage to let it know that the game has loaded.
    void Start () {
        #if (UNITY_WEBPLAYER || UNITY_WEBGL) && !UNITY_EDITOR
        try {
            Application.ExternalCall("GameControlReady");
        } catch (System.Exception e) {
            Debug.LogError("GameControlReady function not on webpage"+e);
        }
        #endif
    }

    // This function will be called from the webpage
    public void FocusCanvas (string p_focus) {
        #if !UNITY_EDITOR && UNITY_WEBGL
        if (p_focus == "0") {
            WebGLInput.captureAllKeyboardInput = false;
        } else {
            WebGLInput.captureAllKeyboardInput = true;
        }
        #endif
    }
}
