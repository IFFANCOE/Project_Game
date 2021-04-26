using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    // // Start is called before the first frame update

    private const float Y_ANGLE_MIN = 15.0f;
    private const float Y_ANGLE_MAX = 55.0f;

    public Transform lookAt;
    public Transform camTransform;
    private Camera cam;

    private float distance = 6.5f;
    private float currentX = 10.0f;
    private float currentY = 10.0f;
    private float sensivityX = 4.0f;
    private float sensivityY = 1.0f;

    void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        
    }
    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        

        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
