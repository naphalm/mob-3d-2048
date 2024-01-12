using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : Singleton
{
    private void Start()
    {
        EventRelay.Input.PointerUp.AddListener(OnPointerUp);
    }

    void OnPointerUp()
    {
        EventRelay.Spawner.Spawn.Invoke();
    }
}
