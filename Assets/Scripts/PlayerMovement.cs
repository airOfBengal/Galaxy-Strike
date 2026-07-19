using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Control Parameters")]
    [SerializeField] Vector2 xMoveRange = new Vector2(-10, 10);
    [SerializeField] Vector2 yMoveRange = new Vector2(-5, 5);
    [SerializeField] float controlSpeed = 50f;
    Vector2 movementInput;

    [Header("Rotation Control Parameters")]
    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float controlPitchFactor = 20f;
    [SerializeField] float rotationSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessRotation()
    {
        float pitch = controlPitchFactor * movementInput.y;
        float roll = controlRollFactor * movementInput.x;
        Quaternion targetRotation = Quaternion.Euler(-pitch, 0f, -roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void ProcessTranslation()
    {
        float xOffset = movementInput.x * controlSpeed * Time.deltaTime;
        float x = transform.localPosition.x + xOffset;
        float clampedX = Mathf.Clamp(x, xMoveRange.x, xMoveRange.y);


        float yOffset = movementInput.y * controlSpeed * Time.deltaTime;
        float y = transform.localPosition.y + yOffset;
        float clampedY = Mathf.Clamp(y, yMoveRange.x, yMoveRange.y);

        transform.localPosition = new Vector3(clampedX, clampedY, 0f);
    }

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }
}
