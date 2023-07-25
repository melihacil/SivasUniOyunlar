using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    Vector3 ballPosition;
    CountDown ct;

    [SerializeField]
    private InputActionReference _resetBall;
    [SerializeField]
    private InputActionReference _reloadBall;

    bool secondaryValue;
    bool triggerValue;

    Vector3[] ballPositions;

    private void Start()
    {

        ct = GetComponent<CountDown>();
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Basketball");
        ballPositions = new Vector3[balls.Length];

        for (int i = 0; i < balls.Length; i++)
        {
            ballPositions[i] = balls[i].transform.position;
        }
    }


    private void Update()
    {
        if (_resetBall.action.IsPressed())
        {
             ResetBall();
            
        }
        if (_reloadBall.action.IsPressed())
        {
            Reload();
        }
    }

    public void ResetBall()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Basketball");

        for (int i = 0; i < balls.Length; i++)
        {
            Rigidbody ballRigidbody = balls[i].GetComponent<Rigidbody>();
            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.angularVelocity = Vector3.zero;
            balls[i].transform.position = ballPositions[i];
        }
    }



      public void Reload()
      {
        SceneManager.LoadScene(0);
      }

        


        void ResetBallInput(InputAction.CallbackContext context)
        {

        var ball = GameObject.FindGameObjectWithTag("Basketball");
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.transform.position = ballPosition;
        }
    void ReloadInput(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(0); 
    }
}
