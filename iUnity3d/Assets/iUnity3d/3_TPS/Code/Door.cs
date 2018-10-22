using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public float speed = 0.1f;

    [SerializeField] private Vector3 openPosition;
                    private Vector3 closePosition;

    private bool isOpen = false;
    private bool isOperating = false;

    private void Start()
    {
        closePosition = transform.position;
    }

    public void Operate()
    {
        isOperating = true;

        while (isOperating)
        {
            Vector3 currentPosition = transform.position;
            Vector3 move = Vector3.zero;

            if (!isOpen)
            {
                move = (openPosition - currentPosition) * speed;
                transform.Translate(move);
            }
            else
            {
                move = (closePosition - currentPosition) * speed;
                transform.Translate(move);
            }

            if (Mathf.Abs(move.magnitude) < Mathf.Abs((openPosition - closePosition).magnitude))
            {
                isOpen = !isOpen;
                isOperating = false;
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, openPosition);
    }
}
