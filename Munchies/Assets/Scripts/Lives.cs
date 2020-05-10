using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    public GameObject Life1, Life2, Life3, Life4;
    public static int lives;

    // Start is called before the first frame update
    void Start()
    {
        //On screen life counter
        lives = 4;
        Life1.gameObject.SetActive(true);
        Life2.gameObject.SetActive(true);
        Life3.gameObject.SetActive(true);
        Life4.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (lives > 4)
            lives = 4;
        //Each life lost will cause one life symbol to disappear
        switch (lives)
        {
            case 4:
                Life1.gameObject.SetActive(true);
                Life2.gameObject.SetActive(true);
                Life3.gameObject.SetActive(true);
                Life4.gameObject.SetActive(true);
                break;
            case 3:
                Life1.gameObject.SetActive(true);
                Life2.gameObject.SetActive(true);
                Life3.gameObject.SetActive(true);
                Life4.gameObject.SetActive(false);
                break;
            case 2:
                Life1.gameObject.SetActive(true);
                Life2.gameObject.SetActive(true);
                Life3.gameObject.SetActive(false);
                Life4.gameObject.SetActive(false);
                break;
            case 1:
                Life1.gameObject.SetActive(true);
                Life2.gameObject.SetActive(false);
                Life3.gameObject.SetActive(false);
                Life4.gameObject.SetActive(false);
                break;
            case 0:
                Life1.gameObject.SetActive(false);
                Life2.gameObject.SetActive(false);
                Life3.gameObject.SetActive(false);
                Life4.gameObject.SetActive(false);
                //If all lives are lost, you are sent to the lose screen
                SceneManager.LoadScene(3);
                break;
        }

    }
}
