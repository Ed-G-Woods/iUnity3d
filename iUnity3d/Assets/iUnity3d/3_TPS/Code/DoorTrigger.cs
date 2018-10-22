using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

    [SerializeField] private GameObject targetDoor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        targetDoor.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);
        //targetDoor.GetComponent<Door>().Operate();
        
    }
}
