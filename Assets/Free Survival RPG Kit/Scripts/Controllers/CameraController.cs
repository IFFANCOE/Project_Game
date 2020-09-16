using UnityEngine;


/* Makes the camera follow the player */

public class CameraController : MonoBehaviour {
    // private const float Y_ANGLE_MIN = 0.0f;
    // private const float Y_ANGLE_MAX = 50.0f;
    
    // public Transform lookAt;
    // public Transform camTransform;

    // private Camera cam;
    
    // private float distance = 10.0f;
    // private float currentX = 0.0f;
    // private float currentY = 0.0f;
    // private float sensivityX = 4.0f;
    // private float sensivityY = 1.0f;
	public Transform target;
	public Vector3 offset;
	public float smoothSpeed = 2f;

	public float currentZoom = 1f;
	public float maxZoom = 3f;
	public float minZoom = .3f;
	public float yawSpeed = 70;
	public float zoomSensitivity = .7f;
	float dst;

	float zoomSmoothV;
	float targetZoom;

	private void Start() {
        // camTransform =  transform;
        // cam = Camera.main;

		dst = offset.magnitude;
		transform.LookAt (target);
		targetZoom = currentZoom;
	}

	private void Update ()
	{
        // currentX += Input.GetAxis("Mouse X");
        // currentY += Input.GetAxis("Mouse Y");
    
        // Check if Joystick are connected to change scroll whell event
        // Use this for make better controller, using mouse or joystick axis.
        PlayerController pController = target.gameObject.GetComponent<PlayerController>();
        float scroll;
        if (pController.usingJoystick)
            scroll = Input.GetAxisRaw("Mouse ScrollWheel Joystick") * zoomSensitivity;
        else
            scroll = Input.GetAxisRaw("Mouse ScrollWheel") * zoomSensitivity;

        if (scroll != 0f)
		{
			targetZoom = Mathf.Clamp(targetZoom - scroll, minZoom, maxZoom);
		}
		currentZoom = Mathf.SmoothDamp (currentZoom, targetZoom, ref zoomSmoothV, .15f);
	}

	private void LateUpdate () {

        // Vector3 dir = new Vector3(0,0,-distance);
        // Quaternion rotation = Quaternion.Euler(currentY,currentX,0);
        // camTransform.position = lookAt.position +  rotation *dir;
        // camTransform.LookAt(lookAt.position);

		transform.position = target.position - transform.forward * dst * currentZoom;
		transform.LookAt(target.position);

       // detect player variable for check controllers and apply on camera rotate system
        PlayerController pController = target.gameObject.GetComponent<PlayerController>();
         
        // point click
        if (pController.pointClickMovement)
        {
            float yawInput;
            yawInput = Input.GetAxisRaw("Horizontal");
            transform.RotateAround(target.position, Vector3.up, -yawInput * yawSpeed * Time.deltaTime);
        }
        else
        {
            // keyboard
            if (Input.GetMouseButton(1) && !pController.usingJoystick)
            {
                float yawInput;
                yawInput = Input.GetAxisRaw("Mouse X");
                transform.RotateAround(target.position, Vector3.up, -yawInput * yawSpeed * Time.deltaTime);
            }
            
        }            
	}
}
