using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    [SerializeField] private GameObject enemyPrefab;    //用[SerializeField] private可以将变量暴露到editor中但是对别的class是private的
    private GameObject _enemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_enemy == null)
        {
	        _enemy = Instantiate(enemyPrefab) as GameObject;    //In C#, use the  ‘as’ keyword for typecasting
            _enemy.transform.position = new Vector3(0, 2.5f, 0);
	        _enemy.transform.Rotate(0, Random.Range(0, 360), 0);
        }
	}
}
