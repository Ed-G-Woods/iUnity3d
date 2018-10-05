using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {

    public float WalkSpeed = 3f;
    public float obstacleRange = 5f;

    private bool _isAlive = true;

	// Use this for initialization
	void Start () {
        _isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (_isAlive == true)
        {
	        transform.Translate(0, 0, WalkSpeed*Time.deltaTime);
	
	        Ray ray = new Ray(transform.position, transform.forward);
	        RaycastHit hit;
	        if(Physics.SphereCast(ray,0.75f,out hit))
	        {
	            if (hit.distance <= obstacleRange)
	            {
	                float angle = Random.Range(-100, 100);
	                transform.Rotate(0, angle, 0);
	            }
	        }
        }
	}

    public void setAlive(bool b)
    {
        _isAlive = b;
    }
}

