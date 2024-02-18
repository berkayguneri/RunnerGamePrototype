using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObjects : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveDistance = 10f;
    private bool isMoving = true;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = initialPosition + new Vector3(0, 0, Mathf.PingPong(Time.time * moveSpeed, moveDistance));
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            isMoving = false; 
        }
    }

}
