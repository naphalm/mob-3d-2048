using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DiceBuilder : MonoBehaviour
{
    [SerializeField] DiceController dice;
    [SerializeField] ValueController value;
    [SerializeField] ColorController color;

    private void Awake()
    {
        // dice = GetComponent<DiceController>();
        Assert.IsNotNull(dice, "DiceController null");
        // color = GetComponent<ColorController>();
        Assert.IsNotNull(color, "ColorController null");
        // value = GetComponentInChildren<ValueController>();
        Assert.IsNotNull(value, "ColorController null");
    }

    public void BuildDice(int val)
    {
        value.SetDiceValue(val);
        color.SetColor(val);
    }
}
