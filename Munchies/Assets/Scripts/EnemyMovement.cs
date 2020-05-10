using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;
public enum enemyState
{
    Wander,
    Attack,
}
public class EnemyMovement : MonoBehaviour
{
    private float range = 3f;
    public enemyState currentState = enemyState.Wander;
    private bool chooseDirection = false;
    private Vector3 randomDirection;
    public float moveSpeed = 1.9f;
    public Node startingPosition;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case (enemyState.Wander):
                Wander();
                break;
            case (enemyState.Attack):
                Attack();
                break;
        }
        if (isPlayerInRange(range) && currentState != enemyState.Attack)
        {
            currentState = enemyState.Attack;
        }
        else if (!isPlayerInRange(range))
        {
            currentState = enemyState.Wander;
        }
    }
    private bool isPlayerInRange(float range)
    {
        //checks if player is in range
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }
    private IEnumerator ChooseDirection()
    {
        //How the ghost chooses which direction to go
        chooseDirection = true;
        yield return new WaitForSeconds(Random.Range(1f, 7f));
        randomDirection = new Vector3(0, 0, Random.Range(0, 360));
        Quaternion nextRotation = Quaternion.Euler(randomDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chooseDirection = false;
    }
    void Wander()
    {
        //Ghost wanders the map
        if (!chooseDirection)
        {
            StartCoroutine(ChooseDirection());
        }
        transform.position += -transform.right * moveSpeed * Time.deltaTime;
    }
    void Attack()
    {
        //ghst tracks the player
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       //player loses a life if caught by ghost
        if (other.tag == "Player") 
        {
            Lives.lives -= 1;
            Debug.Log("Chomp");
        }
            
    }
}
