using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    private void Awake()
    {
        EventRelay.Board.Bonus.AddListener(BonusHandle);
        EventRelay.Board.ResetBonus.AddListener(ResetBonus);
        EventRelay.Screen.LandscapeMode.AddListener(OnLandscapeMode);
        EventRelay.Screen.PortraitMode.AddListener(OnPortraitMode);
        gameObject.SetActive(false);
    }

    void BonusHandle(int combo)
    {
        if (combo >= 2)
        {
            gameObject.SetActive(true);
            text.text = "X" + combo;
        }
    }

    void ResetBonus()
    {
        gameObject.SetActive(false);
    }

    protected void OnPortraitMode()
    {
        transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
        transform.localPosition = new Vector3(0, -130, 0);
    }

    protected void OnLandscapeMode()
    {
        transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        transform.localPosition = new Vector3(0, 0, 0);
    }
}
