using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource wallSound;
    public AudioSource recketSound;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RecketPlayer1" || collision.gameObject.name == "RecketPlayer2")
        {
            recketSound.Play();
        }
        else
            wallSound.Play();
    }
}
