using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    public int _hp = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void hitPlayer(int damage)
    {
        _hp -= damage;
        Debug.Log("HP: " + _hp);
    }
}
