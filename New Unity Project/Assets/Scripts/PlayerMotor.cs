using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;
    Vector3 rotation = Vector3.zero;
    Vector3 camRot = Vector3.zero;

    [SerializeField]
    private Camera playerCam;

    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per physics frame 
	void FixedUpdate ()
    {
        PerformMovement();
        PerformRotation();
    }

    // Function that gets the player's velocity from the PlayerController script
    public void SetVelocity(Vector3 _vel)
    {
        velocity = _vel;
    }

    // Function that rotates the "player object" horizontally 
    public void SetRotation(Vector3 _rot)
    {
        rotation = _rot;
    }

    // Function that rotates the "camera" vertically 
    public void SetCameraRotation(Vector3 _rot)
    {
        camRot = _rot;
    }

    // Function that performs movement every frame
    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(transform.position + velocity * Time.deltaTime);
        }
    }

    // Function that perform rotation every frame
    void PerformRotation()
    {
        if (rotation != null)
        {
            rb.MoveRotation(transform.rotation * Quaternion.Euler(rotation));
        }

        if (playerCam != null)
        {
            playerCam.transform.Rotate(-camRot);
        }
    }
}
