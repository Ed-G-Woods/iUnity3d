using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraC : MonoBehaviour {

    [SerializeField] private float OffsetH = -10;
    [SerializeField] private float OffsetV = 20;
    [SerializeField] private float OffsetSpeed=1;
    [SerializeField] private GameObject targetObject;
    [SerializeField] private bool isLookAt=true;
    

	// Use this for initialization
	void Start () {
		
	}

    private void FixedUpdate()
    {
        Offset();
        Look();
    }

    private void Offset()
    {
        Vector3 target = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y + OffsetV, targetObject.transform.position.z + OffsetH);
        Vector3 direction = target - transform.position;
        transform.position += direction * OffsetSpeed * Time.deltaTime;
    }

    private void Look()
    {
        if (isLookAt)
        {
            transform.LookAt(targetObject.transform.position);
        }
    }
}

