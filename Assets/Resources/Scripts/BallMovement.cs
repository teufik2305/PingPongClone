using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float movementSpeed;
    public float extraSpeedPerHit;
    public float extraSpeed;

    int hitCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartBall(true));
    }

    public void PositionBall(bool isStartingPlayer1)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (isStartingPlayer1)
        {
            gameObject.transform.localPosition = new Vector3(-100, 0, 0);
        }else
            gameObject.transform.localPosition = new Vector3(100, 0, 0);
    }

    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        PositionBall(isStartingPlayer1);

        hitCounter = 0;
        yield return new WaitForSeconds(2);
        if (isStartingPlayer1)
        {
            MoveBall(new Vector2(-1, 0));
        }
        else
        {
            MoveBall(new Vector2(1, 0));
        }
    }

    public void MoveBall(Vector2 dir)
    {
        dir = dir.normalized;

        float speed = movementSpeed + hitCounter * extraSpeedPerHit;

        Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

        rigidbody2D.velocity = dir * speed;
    }
    
    public void IncreaseHitCounter()
    {
        if (hitCounter*extraSpeedPerHit <= extraSpeed)
        {
            hitCounter++;
        }
    }
}
