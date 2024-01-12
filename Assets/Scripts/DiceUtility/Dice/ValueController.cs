using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValueController : MonoBehaviour
{

    private List<TextMeshPro> valueTexts = new List<TextMeshPro>();

    private void Awake()
    {
        // Get all the TextMeshPro objects
        foreach (Transform child in transform)
        {
            TextMeshPro textMesh = child.GetComponent<TextMeshPro>();
            if (textMesh != null)
            {
                valueTexts.Add(textMesh);
            }
        }
        ClearValues();
    }

    public void SetDiceValue(int value)
    {
        // ClearValues();
        // Set the same value on all the TextMeshPro objects
        for (int i = 0; i < valueTexts.Count; i++)
        {
            valueTexts[i].text = value.ToString();
        }
    }

    public void ClearValues()
    {
        for (int i = 0; i < valueTexts.Count; i++)
        {
            valueTexts[i].text = string.Empty;
        }
    }
}