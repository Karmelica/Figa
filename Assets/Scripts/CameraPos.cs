using UnityEngine;

public class CameraMouseLook : MonoBehaviour
{

    public Transform orientation;
    public float sensitivity = 2f;

    private Vector2 currentRotation = Vector2.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if(!GameMenuScript.isPaused)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            currentRotation.x += mouseX;
            currentRotation.y -= mouseY;
            currentRotation.y = Mathf.Clamp(currentRotation.y, -90f, 90f);

            orientation.localRotation = Quaternion.Euler(0f, currentRotation.x, 0f);
            transform.localRotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0f);
        }
    }
}

