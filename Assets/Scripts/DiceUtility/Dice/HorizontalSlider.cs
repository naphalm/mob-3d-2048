using UnityEngine;

public class HorizontalSlider : MonoBehaviour
{
    public float sensitivity = 5f; // Adjust this value to control the sensitivity of movement
    public float minX = -2f; // Minimum X-axis value
    public float maxX = 2f; // Maximum X-axis value
    public float forwardForce = 10f; // Forward force applied to the dice
    private bool isDragging = false;
    private Vector3 touchStartPosition;
    private Vector3 diceStartPosition;

    //=============

    private void Update()
    {
        // Check for mouse or touch input
        if (Input.GetMouseButtonDown(0))
        {
            EventRelay.Input.PointerDown.Invoke();
            isDragging = true;
            touchStartPosition = GetNormalizedInputPosition(Input.mousePosition);
            diceStartPosition = transform.position;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EventRelay.Input.PointerUp.Invoke();
            isDragging = false;
        }

        // Update dice position during dragging
        if (isDragging)
        {
            Vector3 currentTouchPosition = GetNormalizedInputPosition(Input.mousePosition);
            Vector3 touchDelta = (currentTouchPosition - touchStartPosition) * sensitivity;
            Vector3 dicePosition = diceStartPosition + touchDelta;
            float clampedX = Mathf.Clamp(dicePosition.x, minX, maxX);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }

    private Vector3 GetNormalizedInputPosition(Vector3 inputPosition)
    {
        return new Vector3(
            inputPosition.x / Screen.width,
            inputPosition.y / Screen.height,
            inputPosition.z
        );
    }
}
