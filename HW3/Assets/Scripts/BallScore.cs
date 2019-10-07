using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallScore : MonoBehaviour
{

    public GameObject Net;
    public GameObject ball;
    private Vector3 ballPosition;
    private bool scored = false;
    public pointSystem pointManager;
    private void Start()
    {
        ballPosition = ball.GetComponent<Transform>().position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!scored)
        {
            scored = true;
            if (other.gameObject == Net)
            {
                Debug.Log("Hit");

                GameObject newBall = Instantiate(ball, ballPosition, Quaternion.identity/*, true, ballPosition.position, ballPosition.rotation*/);


                pointManager.incrementPoints();
                StartCoroutine(ChangeTheColor());

            }
        }
    }


    IEnumerator ChangeTheColor()
    {
        Debug.Log("Entered Net");

        Net.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(2);
        Net.GetComponent<Renderer>().material.color = Color.blue;
        Destroy(ball);

    }
}
