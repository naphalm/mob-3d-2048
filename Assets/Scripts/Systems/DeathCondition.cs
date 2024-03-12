using System.Collections;
using UnityEngine;

public class DeathCondition : MonoBehaviour
{
    BoxCollider bc;
    GameObject enteredObject; // Reference to the object that entered the trigger

    private void Start()
    {
        bc = GetComponent<BoxCollider>();
        EventRelay.GameManager.Death.AddListener(OnLevelEnd);
        EventRelay.GameManager.ContinueEnded.AddListener(OnContinueEnded);
    }

    private Coroutine timerCoroutine;
    public readonly float timerThreshold = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        enteredObject = other.gameObject;
        timerCoroutine = StartCoroutine(StartTimerCoroutine());
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the trigger is the same as the one entered
        if (other.gameObject == enteredObject)
        {
            StopCoroutine(timerCoroutine);
            enteredObject = null;
        }
    }

    private IEnumerator StartTimerCoroutine()
    {
        float timer = 0f;
        while (timer < timerThreshold)
        {
            timer += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Check if the entered object is still valid before invoking the death condition
        if (enteredObject != null)
        {
            HandleTimerThreshold();
        }
    }

    private void HandleTimerThreshold()
    {
        Debug.Log("DEATH!");
        EventRelay.GameManager.Death.Invoke();
    }

    void OnLevelEnd()
    {
        bc.enabled = false;
    }

    void OnContinueEnded()
    {
        bc.enabled = true;
    }
}
