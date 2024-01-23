using System.Collections;
using UnityEngine;

public class MobileHandler : MonoBehaviour
{
    public float checkIntervalSeconds = 2f;

    void Awake()
    {
        CheckScreen();
        StartCoroutine(CheckOrientationCoroutine());
    }

    IEnumerator CheckOrientationCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkIntervalSeconds);
            CheckScreen();

        }
    }

    void CheckScreen()
    {
        if (Screen.width > Screen.height)
        {
            // Debug.Log("Landscape Mode");
            EventRelay.Screen.LandscapeMode.Invoke();
        }
        else
        {
            // Debug.Log("Portrait Mode");
            EventRelay.Screen.PortraitMode.Invoke();
        }
    }
}
