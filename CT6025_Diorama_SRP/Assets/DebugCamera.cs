using UnityEngine;

public class DebugCamera : MonoBehaviour
{
	public float movementSpeed = 10.0f; 
	public float rotationSpeed = 10.0f; 
	private bool lightingOn = true;

	[SerializeField] private Light _directionalLight;

	private void Awake()
	{
		_directionalLight.enabled = false;
	}

	private void Update()
	{
		if (Input.GetMouseButton(1))
		{
			// Difference between the current and previous mouse position)
			float mouseDeltaX = Input.GetAxis("Mouse X");
			float mouseDeltaY = Input.GetAxis("Mouse Y");
			
			// Invert vertical movement 
			mouseDeltaY = -mouseDeltaY;

			transform.Rotate(Vector3.up, mouseDeltaX, Space.World);
			transform.Rotate(Vector3.right, mouseDeltaY, Space.Self);
		}

		// Check if the user is pressing the WASD keys
		if (Input.GetKey(KeyCode.W))
		{
			transform.position += transform.forward * movementSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.position -= transform.forward * movementSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.position -= transform.right * movementSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.position += transform.right * movementSpeed * Time.deltaTime;
		}
	}
	
	private void OnGUI()
	{
		Rect windowRect = new Rect(10, 10, 200, 200);
		GUI.Window(0, windowRect, DrawWindow, "Camera Settings");
	}

	private Color color;
	private void DrawWindow(int windowID)
	{
		// Movement speed
		movementSpeed = GUI.HorizontalSlider(new Rect(10, 30, 180, 30), movementSpeed, 0.0f, 20.0f);
		GUI.Label(new Rect(10, 10, 180, 20), "Movement Speed: " + movementSpeed.ToString("F2"));

		// Rotation speed
		rotationSpeed = GUI.HorizontalSlider(new Rect(10, 70, 180, 30), rotationSpeed, 0.0f, 20.0f);
		GUI.Label(new Rect(10, 50, 180, 20), "Rotation Speed: " + rotationSpeed.ToString("F2"));
		
		if (GUI.Toggle(new Rect(10, 110, 180, 20), lightingOn, "Art Lighting") != lightingOn)
		{
			lightingOn = !lightingOn;
			UpdateLighting();
		}
	}
	
	private void UpdateLighting()
	{
		_directionalLight.enabled = !lightingOn;
	}
} 