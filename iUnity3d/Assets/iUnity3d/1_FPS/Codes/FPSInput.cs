using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("MyComp/FPSInput")]
public class FPSInput : MonoBehaviour {

    public float WalkSpeed = 10f;
    public float gravity = -9.8f;

    private CharacterController _charController;

	// Use this for initialization
	void Start () {
        _charController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        float forwardSpeed = WalkSpeed * Input.GetAxis("Horizontal");
        float rightSpeed = WalkSpeed * Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(forwardSpeed, 0, rightSpeed);
        movement = Vector3.ClampMagnitude(movement, WalkSpeed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        movement.y += gravity;
        _charController.Move(movement);
	}
}
