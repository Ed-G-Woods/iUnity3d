using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSPlayer : MonoBehaviour {

    public float speed = 5f;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject playerMesh;
    private CharacterController _controller;

	// Use this for initialization
	void Start () {
        _controller = GetComponent<CharacterController>();

    }
	
	// Update is called once per frame
	void Update () {
        HandleInput();
	}

    private void HandleInput()
    {

        /*
        //get forward 
        Quaternion cameraRotation = playerCamera.transform.rotation;
        cameraRotation.x = 0;
        Vector3 ForwardDirection = (cameraRotation * Vector3.forward).normalized;
        //Debug.Log(ForwardDirection);
        Vector3 RightDirection = (cameraRotation * Vector3.right).normalized;
        //Debug.Log(RightDirection);

        float forwardAxis = Input.GetAxis("Vertical");
        float rightAxis = Input.GetAxis("Horizontal");

        Vector3 Movement =( forwardAxis * ForwardDirection + rightAxis*RightDirection)* speed*Time.deltaTime;
        Movement.y = _controller.velocity.y;
        
        //transform.Translate(Movement, Space.World);
        _controller.Move(Movement);
        */

        RotateWithCamera();

        Vector3 ForwardDirection = playerCamera.transform.forward;
        Vector3 RightDirection = playerCamera.transform.right;

        float forwardAxis = Input.GetAxis("Vertical");
        float rightAxis = Input.GetAxis("Horizontal");

        Vector3 Movement = (forwardAxis * ForwardDirection + rightAxis * RightDirection) * speed ;
        Movement.y -= 9.8f;
        Movement *= Time.deltaTime;

        //transform.Translate(Movement, Space.World);
        _controller.Move(Movement);
    }

    private void RotateWithCamera()
    {
        Quaternion cameraRotation = playerCamera.transform.localRotation;
        Vector3 euler = cameraRotation.eulerAngles;
        euler.Set(0, euler.y - 90, 0);

        playerMesh.transform.localRotation = Quaternion.Euler(euler);

    }
}
