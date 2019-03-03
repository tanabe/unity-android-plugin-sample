using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor) {
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("クリックした瞬間");
            }
        } else {
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("クリックした瞬間");
                ShowDialog();
            }
        }
    }

    void ShowDialog() {
#if UNITY_ANDROID
        AndroidJavaClass nativeDialog = new AndroidJavaClass("com.kaihatsubu.android.safetynetapimodule.SafetyNetAPIUtil");
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject context = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        context.Call("runOnUiThread", new AndroidJavaRunnable(() => {
            nativeDialog.CallStatic(
                "showMessage",
                context,
                "test",
                "this is test dialog"
            );
        }));
#endif
    }
}