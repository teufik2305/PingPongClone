using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public BallMovement ballMovement;
    public ScrollController scrollController;

    void BounceFromRecket(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 recketPosition = collision.gameObject.transform.position;

        float recketHeight = collision.collider.bounds.size.y;

        float x;
        if (collision.gameObject.name == "RecketPlayer1")
        {
            x = 1;
        }
        else
        {
            x = -1;
        }

        float y = (ballPosition.y - recketPosition.y) / recketHeight;
        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2(x, y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RecketPlayer1" || collision.gameObject.name == "RecketPlayer2")
        {
            BounceFromRecket(collision);
        }
        else if (collision.gameObject.name == "WallLeft")
        {
            Debug.Log("Collision with WallLeft");
            scrollController.GoalPlayer2();
            StartCoroutine(ballMovement.StartBall(true));
        }
        else if (collision.gameObject.name == "WallRight")
        {
            Debug.Log("Collision with WallRight");
            scrollController.GoalPlayer1();
            StartCoroutine(ballMovement.StartBall(false));
        }
    }
}
