using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] GameObject gamePedal;
    private Vector2 difference; //difference between ball and pedal

    private bool throwBallFlag = false;
    private bool ballPedalaFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        difference = transform.position - gamePedal.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MyBall();
    }

    private void MyBall()
    {  
        if (!ballPedalaFlag && !Input.GetMouseButtonDown(0))
        {
            BallPedala();      
        }
        
        if(!throwBallFlag  && Input.GetMouseButtonDown(0))
        {
            ThrowBall();
            throwBallFlag = true;
            ballPedalaFlag = true;
        }
        
    }

    private void BallPedala()
    {
        Vector2 pedalPosition = new Vector2(gamePedal.transform.position.x, gamePedal.transform.position.y);
        transform.position = pedalPosition + difference;
    }

    private void ThrowBall() 
    {   
         GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 14f);
        
    }
}
