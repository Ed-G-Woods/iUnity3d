﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }


    public RotationAxes axes = RotationAxes.MouseXandY;
    public float sensitivity = 10f;
    public float minimumVert = -45f;
    public float maximumVert = 45f;

    private float _rotationX = 0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if( axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, sensitivity * Input.GetAxis("Mouse X"), 0);
        }
        else if(axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else if(axes == RotationAxes.MouseXandY)
        {
            
        }


    }
}
