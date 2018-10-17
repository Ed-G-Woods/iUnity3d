using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSPlayer : MonoBehaviour {

    public float speed = 1f;
    [SerializeField] private GameObject playerCamera;
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
    }
}
