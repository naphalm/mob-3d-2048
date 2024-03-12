using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Transform hand;
    bool pressed = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        EventRelay.Input.PointerDown.AddListener(OnInput);
    }

    private void Start()
    {
        StartCoroutine(StartMove());
    }

    IEnumerator StartMove()
    {
        while (!pressed)
        {
            hand.DOLocalMoveX(100f, 1f);
            yield return new WaitForSeconds(2.5f);
            hand.localPosition = new Vector3(0, -150, 0);
        }
    }

    void OnInput()
    {
        pressed = true;
        gameObject.SetActive(false);
    }
}
