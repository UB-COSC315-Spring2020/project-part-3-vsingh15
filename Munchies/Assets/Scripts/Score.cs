using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
   public static Score instance;
    public TextMeshProUGUI text;
   public static int score;

    void Start()
    {
        score = 0;
        if (instance == null)
        {
            instance = this;
        }
    }
    public void ChangeScore()
    {
       //adds to score text on screen
        text.text = "Score: " + score.ToString();
    }
    private void Update()
    {
        ChangeScore();
        //When food is eaten, load winscreen
        if (!GameObject.FindGameObjectWithTag("Food")) 
        {
            SceneManager.LoadScene(2);
        }
    }
   
}
 