using UnityEngine;
using System.Collections;

public class QuitScript : MonoBehaviour {

    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
	
}
