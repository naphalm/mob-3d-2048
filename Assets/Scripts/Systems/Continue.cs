using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TylerCode.SoundSystem;
using UnityEngine;

public class Continue : MonoBehaviour
{
    [SerializeField] GameObject particlePrefab;
    S4SoundSource sound;
    public float moveTime = 1f;



    void Start()
    {
        EventRelay.GameManager.RewardedContinue.AddListener(OnContinue);
        gameObject.SetActive(false);
        sound = GetComponent<S4SoundSource>();
    }

    void OnContinue()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        gameObject.SetActive(true);
        transform.DOLocalMoveX(-5, moveTime);
        StartCoroutine(Timer());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dice"))
        {
            other.GetComponent<BaseDice>().RemoveDice();

            //INSTANTIATE PARTICLE AT other.gameObject.position LOCATION
            Instantiate(particlePrefab, other.transform.position, Quaternion.identity);
            sound.PlaySound("Hit");
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(moveTime);
        EventRelay.GameManager.ContinueEnded.Invoke();
        gameObject.SetActive(false);
    }
}
