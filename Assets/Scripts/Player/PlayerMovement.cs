using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float initialSpeed;
    public float movementSpeed;
    public float leftRightSpeed;
    static public bool canMove = false;
    private bool isJumping = false;
    private bool isSliding = false;
    private bool comingDown = false;
    private bool goingUp = false;
    public GameObject player;


    public float speedIncreaseRate = 0.3f;

    public float speedIncreaseInterval = 5;

    public float maxMovementSpeed = 20;

    private Rigidbody rb;

    private void Start()
    {
        movementSpeed = initialSpeed;
        StartCoroutine(IncreaseSpeedOverTime());
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed, Space.World);

        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);

                }

            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
                }
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if (isJumping == false)
                {
                    isJumping = true;
                    player.GetComponent<Animator>().Play("Jump");
                    StartCoroutine(JumpSequence());
                }
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (isSliding == false)
                {
                    isSliding = true;
                    player.GetComponent<Animator>().Play("Soccer Tackle");
                    StartCoroutine(SlideSequence());
                }
                //StartCoroutine(SlideSequence());

            }
        }
        if (isJumping == true)
        {
            if (comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3.5f, Space.World);
            }
            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -1, Space.World);
            }
        }
        if (isSliding == true)
        {
            if (goingUp == false)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * 1, Space.World);
            }
            if (goingUp == true)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * -1, Space.World);
            }
        }


    }


    public void Die()
    {
        if (rb != null)
        {
            rb.useGravity = true; // Karaktere yer çekimi uygula
            rb.isKinematic = true; // Karakterin fiziksel etkileþimi durdur
        }
    }
    IEnumerator IncreaseSpeedOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(speedIncreaseInterval);

            if (movementSpeed < maxMovementSpeed)
            {
                movementSpeed += speedIncreaseRate;
            }
        }
    }

    IEnumerator SlideSequence()
    {
        yield return new WaitForSeconds(0.7f);
        goingUp = true;
        yield return new WaitForSeconds(0.7f);
        isSliding = false;
        goingUp = false;
        player.GetComponent<Animator>().Play("Standard Run");

    }


    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        player.GetComponent<Animator>().Play("Standard Run");
    }

    
}
