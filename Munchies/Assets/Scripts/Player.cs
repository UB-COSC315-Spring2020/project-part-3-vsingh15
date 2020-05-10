using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float speed = 2.0f;
    private Vector2 direction = Vector2.zero;
    [SerializeField]
    public static int Lives = 4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();

        Move();
    }
    //Movements
    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }
    }
    //Continuous movement.
    void Move ()
    {
        transform.localPosition += (Vector3) (direction * speed) * Time.deltaTime;
    }
    //Lives
    public void loseLives(int livesLost)
    {
        Lives -= livesLost;

    }
    
}
