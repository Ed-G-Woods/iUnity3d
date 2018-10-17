using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour {

    //     public float offsetZ=5f;
    //     public float offsetY=2f;
    public Vector3 offset = new Vector3(0, 2, 5);
    public Vector3 originLocation = new Vector3(0, 3, 0);
    public float rotSpeed = 1.5f;

    private float rotationEulerY = 0f;
    private float rotationEulerX = 0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //         Debug.Log("eulerY : "+ rotationEulerY);
        //         float rotationY = transform.rotation.y;
        //         Debug.Log("rotationY : " + rotationY);
        rotationEulerY += Input.GetAxis("Mouse X") * rotSpeed;
        rotationEulerX += Input.GetAxis("Mouse Y") * rotSpeed *-1;  //*-1反转y轴

        Quaternion rotation = Quaternion.Euler(rotationEulerX, rotationEulerY, 0);
        transform.localPosition = originLocation - (rotation * offset);      //Quaternion* Vector3 ，根据Quaternion取在以Vector为半径的圆面（圆周）上的点
        transform.localRotation = rotation;

    }
}
