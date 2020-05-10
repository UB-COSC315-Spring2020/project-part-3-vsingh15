using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //pellet pickup and adds to score
        if (collision.tag == "Player")
        {
            Score.score++;
            Destroy(gameObject);
        }
    }

}
