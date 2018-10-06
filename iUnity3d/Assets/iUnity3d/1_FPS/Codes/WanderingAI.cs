using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

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
                GameObject hitobject = hit.transform.gameObject;
                if (hitobject.GetComponent<PlayerCharacter>())  //if is player
                {
                    if (_fireball==null)                        //if haven't fired 
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
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

