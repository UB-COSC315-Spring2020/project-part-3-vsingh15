using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCScreen : MonoBehaviour
{
    public static bool gamePause = false;

    public GameObject escapeScreen;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Resume()
    {
        escapeScreen.SetActive(false);
        Time.timeScale = 1f;
        gamePause = false;
    }
    void Pause()
    {
        escapeScreen.SetActive(true);
        Time.timeScale = 0f;
        gamePause = true;
    }
}
