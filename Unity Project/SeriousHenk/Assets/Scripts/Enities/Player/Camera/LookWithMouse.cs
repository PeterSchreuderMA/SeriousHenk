using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWithMouse : MonoBehaviour
{
    [Header("Invert Mouse Axis")]
    public bool invertHorizontal = false;
    public bool invertVertical = false;

    [Header("Other")]
    [SerializeField]
    private float sensitivity = 10f;
    [SerializeField]
    private float maxYAngle = 80f;
    private Vector2 currentRotation;

    void Update()
    {
        LookAtMousePosition();
    }


    void LookAtMousePosition()
    {

        currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
        currentRotation.y += Input.GetAxis("Mouse Y") * sensitivity;
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
        currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);

        //Rotate the transform by the currentRotation influenced by the invertion
        transform.rotation = Quaternion.Euler(currentRotation.y * (invertVertical ? 1 : -1), currentRotation.x * (invertHorizontal ? -1 : 1), 0);

        //Switch cursor mode for the editor
        if (Input.GetMouseButtonDown(2))
        {
            if (Cursor.lockState != CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;
        }

    }
}
