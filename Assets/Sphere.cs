using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// readme
// Before build this application.
// You must add line "implementation 'com.google.android.gms:play-services-safetynet:16.0.0'" to build.gradle file.

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
                Debug.Log("clicked");
            }
        } else {
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("tapped");
                //ShowDialog();
                bool result = IsGooglePlayServicesAvailable();
                Debug.Log(result);
                Debug.Log("start attest");
                SendSafetyNetRequest();
            }
        }
    }

    void ShowDialog()
    {
#if UNITY_ANDROID
        AndroidJavaClass safetyNetAPIUtil = new AndroidJavaClass("com.kaihatsubu.android.safetynetapimodule.SafetyNetAPIUtil");
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject context = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        context.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            safetyNetAPIUtil.CallStatic(
                "showMessage",
                context,
                "test",
                "this is test dialog"
            );
        }));
#endif
    }

    void SendSafetyNetRequest() {
#if UNITY_ANDROID
        AndroidJavaClass safetyNetAPIUtil = new AndroidJavaClass("com.kaihatsubu.android.safetynetapimodule.SafetyNetAPIUtil");
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject context = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        safetyNetAPIUtil.CallStatic("sendSafetyNetRequest", context);
#endif
    }

    bool IsGooglePlayServicesAvailable() {
#if UNITY_ANDROID
        AndroidJavaClass safetyNetAPIUtil = new AndroidJavaClass("com.kaihatsubu.android.safetynetapimodule.SafetyNetAPIUtil");
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject context = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        bool result = safetyNetAPIUtil.CallStatic<bool>("isGooglePlayServicesAvailable", context);
        return result;
#endif
    }
}