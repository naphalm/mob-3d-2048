using System.Collections;
using UnityEngine;
using YG;

public class MobileHandler : MonoBehaviour
{
    public float checkIntervalSeconds = .5f;

    void Awake()
    {
        CheckScreen();

        if (YandexGame.EnvironmentData.isMobile)
        {
            StartCoroutine(CheckOrientationCoroutine());
        }
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
            // EventRelay.Screen.LandscapeMode.Invoke();
        }
        else
        {
            // Debug.Log("Portrait Mode");
            EventRelay.Screen.PortraitMode.Invoke();
        }
    }
}
