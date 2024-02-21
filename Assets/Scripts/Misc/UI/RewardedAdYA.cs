using UnityEngine;
using UnityEngine.UI;
using YG;

public class RewardedAdYa : MonoBehaviour
{
    [SerializeField] int AdID;
    [SerializeField] Button button;

    int moneyCount = 0;

    private void OnEnable() => EventRelay.GameManager.RewardedContinue.AddListener(OnContinue);
    private void OnDisable() => EventRelay.GameManager.RewardedContinue.RemoveListener(OnContinue);



    void OnContinue()
    {
        button.interactable = false;
    }
}


