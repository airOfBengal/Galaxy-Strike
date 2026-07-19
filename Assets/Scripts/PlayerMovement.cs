using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Control Parameters")]
    [SerializeField] Vector2 xMoveRange = new Vector2(10, 10);
    [SerializeField] Vector2 yMoveRange = new Vector2(5, 5);
    [SerializeField] float controlSpeed = 50f;
    Vector2 movementInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
    }

    private void ProcessTranslation()
    {
        float xOffset = movementInput.x * controlSpeed * Time.deltaTime; // Mathf.Clamp(movementInput.x * controlSpeed * Time.deltaTime, xMoveRange.x, xMoveRange.y);
        float yOffset = movementInput.y * controlSpeed * Time.deltaTime; // Mathf.Clamp(movementInput.y * controlSpeed * Time.deltaTime, yMoveRange.x, yMoveRange.y);

        transform.localPosition = new Vector3(transform.localPosition.x + xOffset, transform.localPosition.y + yOffset, 0f);
    }

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }
}
