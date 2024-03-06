using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSizeHandle : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        EventRelay.Screen.PortraitMode.AddListener(OnPortraitMode);
        EventRelay.Screen.LandscapeMode.AddListener(OnLandscapeMode);
    }

    protected virtual void OnPortraitMode()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        EventRelay.Screen.PortraitMode.RemoveListener(OnPortraitMode);
    }

    protected virtual void OnLandscapeMode()
    {
        transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        EventRelay.Screen.LandscapeMode.RemoveListener(OnLandscapeMode);

    }
}
