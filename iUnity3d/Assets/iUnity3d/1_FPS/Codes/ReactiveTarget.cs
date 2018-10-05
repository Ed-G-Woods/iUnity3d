using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {

    private WanderingAI _wAIScript;

	// Use this for initialization
	void Start () {
        _wAIScript = GetComponent<WanderingAI>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReactToHit()
    {
        StartCoroutine(Die());

        if (_wAIScript != null)
        {
            _wAIScript.setAlive(false);
        }
        else
        {
            Debug.Log("have not WanderingAI script");
        }
    }

    private IEnumerator Die()
    {
        transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
