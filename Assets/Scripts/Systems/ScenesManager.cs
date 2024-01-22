using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private void Start()
    {
        EventRelay.GameManager.Replay.AddListener(OnReplay);
    }

    void OnReplay()
    {
        SceneManager.LoadScene(0);
    }
}
