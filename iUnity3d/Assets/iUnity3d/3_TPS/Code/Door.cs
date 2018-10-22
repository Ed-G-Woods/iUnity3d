using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public float speed = 0.3f;

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
        while (!isOperating)
        {
            isOperating = true;
            StartCoroutine(DoorOperating());
        }
    }

    private IEnumerator DoorOperating()
    {
        while (isOperating)
        {
            yield return null;
            
            Vector3 currentPosition = transform.position;
            Vector3 distance = Vector3.zero;

            if (!isOpen)
            {
                distance = (openPosition - currentPosition);
                Vector3 move = distance * Time.deltaTime * speed;
                transform.Translate(move);
            }
            else
            {
                distance = (closePosition - currentPosition);
                Vector3 move = distance * Time.deltaTime * speed;
                transform.Translate(move);
            }
            Debug.Log("on");

            if (Mathf.Abs(distance.magnitude) < Mathf.Abs((openPosition - closePosition).magnitude) * 0.05)
            {
                isOpen = !isOpen;
                isOperating = false;
                Debug.Log("out");
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, openPosition);
    }
}
