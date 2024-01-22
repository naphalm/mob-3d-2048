using System.Collections;
using UnityEngine;
public class DeathCondition : MonoBehaviour
{
    int counter = 0;
    BoxCollider bc;
    private void Start()
    {
        bc = GetComponent<BoxCollider>();
        EventRelay.GameManager.Death.AddListener(OnLevelEnd);
        EventRelay.GameManager.ContinueEnded.AddListener(OnContinueEnded);
        counter = 0;
    }
    private Coroutine timerCoroutine;
    public readonly float timerThreshold = .5f;



    private void OnTriggerEnter(Collider other)
    {

        // Increase dice counter
        counter++;

        if (counter >= 1)
        {
            timerCoroutine = StartCoroutine(StartTimerCoroutine());
        }

    }

    private void OnTriggerExit(Collider other)
    {

        // Decrease dice counter
        counter--;

        // If there are no more dice, stop the timer
        if (counter < 1 && timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
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
        if (counter > 0)
        {
            Debug.Log("DEATH!");
            EventRelay.GameManager.Death.Invoke();
        }
    }

    void OnLevelEnd()
    {
        bc.enabled = false;
    }
    void OnContinueEnded()
    {
        bc.enabled = true;
        counter = 0;
    }
}
