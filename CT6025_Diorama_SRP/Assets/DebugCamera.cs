using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCamera : MonoBehaviour
{
	public float movementSpeed = 5.0f; // Adjust this value to control the camera's movement speed

	private void Update()
	{
		// Check if the user is holding down the left mouse button
		if (Input.GetMouseButton(1))
		{
			// Get the mouse delta (difference between the current and previous mouse position)
			float mouseDeltaX = Input.GetAxis("Mouse X");
			float mouseDeltaY = Input.GetAxis("Mouse Y");
			
			// Invert the mouse delta Y
			mouseDeltaY = -mouseDeltaY;

			// Rotate the camera based on the mouse delta
			transform.Rotate(Vector3.up, mouseDeltaX, Space.World);
			transform.Rotate(Vector3.right, mouseDeltaY, Space.Self);
		}

		// Check if the user is pressing the WASD keys
		if (Input.GetKey(KeyCode.W))
		{
			// Move the camera forward
			transform.position += transform.forward * movementSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S))
		{
			// Move the camera backward
			transform.position -= transform.forward * movementSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A))
		{
			// Move the camera left
			transform.position -= transform.right * movementSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D))
		{
			// Move the camera right
			transform.position += transform.right * movementSpeed * Time.deltaTime;
		}
	}
} 