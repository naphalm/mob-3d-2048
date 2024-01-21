using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCondition : MonoBehaviour
{
    private List<BaseDice> diceList = new List<BaseDice>();
    private Coroutine timerCoroutine;
    public readonly float timerThreshold = .5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dice"))
        {
            // Increase dice counter
            diceList.Add(other.GetComponent<BaseDice>());

            if (diceList.Count >= 1 && timerCoroutine == null)
            {
                timerCoroutine = StartCoroutine(StartTimerCoroutine());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Dice"))
        {
            // Decrease dice counter
            diceList.Remove(other.GetComponent<BaseDice>());

            // If there are no more dice, stop the timer
            if (diceList.Count == 0 && timerCoroutine != null)
            {
                StopCoroutine(timerCoroutine);
                timerCoroutine = null;
            }
        }
    }

    private IEnumerator StartTimerCoroutine()
    {
        yield return new WaitForSeconds(timerThreshold);

        // Perform the desired action when the timer reaches the threshold
        HandleTimerThreshold();
    }

    private void HandleTimerThreshold()
    {
        Debug.Log("DEATH!");
        EventRelay.GameManager.Death.Invoke();
        SceneManager.LoadScene(0);
    }
}
