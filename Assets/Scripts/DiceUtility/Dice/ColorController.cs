using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Material material;
    private ColorMatch colorMatch = new();

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;
    }



    public void SetColor(int value)
    {
        Debug.Log("Setting color for value: " + value);
        Color color = colorMatch.GetColorForValue(value);
        if (material != null)
        {
            material.color = color;
        }
        else
        {
            Debug.LogError("Material is not assigned to the MeshRenderer component.");
        }
    }
}

class ColorMatch
{
    private Dictionary<Color, int> colorValues;

    public ColorMatch()
    {
        // Initialize the color-values hashtable
        colorValues = new Dictionary<Color, int>();

        // Add color-value pairs to the hashtable
        colorValues.Add(HexToColor("#FF2500"), 2); // 2
        colorValues.Add(HexToColor("#345BEA"), 4); // 4
        colorValues.Add(HexToColor("#47EF00"), 8); // 8
        colorValues.Add(HexToColor("#FF00C0"), 16); // 16 
        colorValues.Add(HexToColor("#A909D9"), 32);  // 32 
        colorValues.Add(HexToColor("#FF8B00"), 64); // 64 
        colorValues.Add(HexToColor("#00E2E1"), 128); // 128
        colorValues.Add(HexToColor("#0004FF"), 256); // 256
        colorValues.Add(HexToColor("#007E24"), 512); // 512
        colorValues.Add(HexToColor("#8600D4"), 1024); // 1024
        colorValues.Add(HexToColor("#3F3F3F"), 2048); // 2048
        colorValues.Add(HexToColor("#00B4FF"), 4096); // 4096
        colorValues.Add(HexToColor("#002E55"), 8192); // 8192
        colorValues.Add(HexToColor("#8E5986"), 16384); // 16384/
        colorValues.Add(HexToColor("#E73700"), 32768); // 32768

        // colorValues.Add(new Color32(155, 55, 55, 255), 256); // 256 //
        // colorValues.Add(new Color32(255, 210, 0, 255), 512); // 512
        // colorValues.Add(new Color32(0, 12, 202, 255), 1024); // 1024
        // colorValues.Add(new Color32(130, 0, 48, 255), 2048); // 2048
        // colorValues.Add(new Color32(36, 72, 55, 255), 4096); // 4096
        // colorValues.Add(new Color32(255, 28, 0, 255), 8192); // 8192
        // colorValues.Add(new Color32(38, 0, 127, 255), 16384); // 16384
        // colorValues.Add(new Color32(45, 65, 41, 255), 32768); // 32768
        // colorValues.Add(new Color32(0, 116, 55, 255), 65536); // 65536
        //==
        // colorValues.Add(new Color32(35, 114, 61, 255), 131072); // 131072
        // colorValues.Add(new Color32(0, 38, 77, 255), 262144); // 262144
        // colorValues.Add(new Color32(61, 77, 66, 255), 524288); // 524288
        // colorValues.Add(new Color32(0, 0, 0, 255), 1048576); // 1048576
        // colorValues.Add(new Color32(50, 0, 0, 255), 2097152); // 2097152

        // colorValues.Add(new Color32(73, 73, 73, 255), 4194304); // 4194304
        // colorValues.Add(new Color32(0, 0, 50, 255), 8388608); // 8388608
        // colorValues.Add(new Color32(50, 50, 0, 255), 16777216); // 16777216
        // colorValues.Add(new Color32(50, 0, 50, 255), 33554432); // 33554432
    }

    // Convert HEX notation to Color
    private Color HexToColor(string hex)
    {
        Color color = Color.white;
        if (ColorUtility.TryParseHtmlString(hex, out color))
        {
            return color;
        }

        Debug.LogError("Invalid HEX color: " + hex);
        return Color.white; // Or any default color
    }

    // Example method to retrieve the value for a given color
    public int GetValueForColor(Color color)
    {
        if (colorValues.ContainsKey(color))
        {
            return colorValues[color];
        }
        else
        {
            Debug.LogError("No value found for color: " + color);
            return 0; // Or any default value
        }
    }

    internal Color GetColorForValue(int value)
    {
        foreach (KeyValuePair<Color, int> pair in colorValues)
        {
            if (pair.Value == value)
            {
                return pair.Key;
            }
        }

        Debug.LogError("No color found for value: " + value);
        return Color.red; // Or any default color
    }
}