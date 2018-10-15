using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterC: MonoBehaviour {

    [SerializeField] private GameObject Player;
    [SerializeField] private float MoveSpeed =3 ;

    private Vector3 mousePosition;
    private Vector3 lookDirection;

    private void Start()
    {
        if (Player==null)
        {
            Player = gameObject;
        }
    }
    

    private void FixedUpdate()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        Quaternion rot = getPlayerRotation();
        Player.transform.rotation =rot;

        Vector3 move = getPlayerMove();
        Player.transform.Translate(move * MoveSpeed * Time.deltaTime,Space.World);
    }

    private Quaternion getPlayerRotation()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 relativeMousePos = new Vector2(mousePos.x - Screen.width / 2, mousePos.y - Screen.height / 2);

        float angle = Mathf.Atan2(relativeMousePos.y, relativeMousePos.x) * Mathf.Rad2Deg * -1;

        Quaternion rotation  =Quaternion.AngleAxis(angle,Vector3.up);
        return rotation;
        
    }

    private Vector3 getPlayerMove()
    {
        Vector3 move = Vector3.zero;
        move.x = Input.GetAxis("Horizontal");
        move.z = Input.GetAxis("Vertical");

        return move;
    }
}
