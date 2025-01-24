using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Awake()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }


    public void Pause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pauseMenu.SetActive(isPaused);
    }

    public void Continue()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Continue();
                Debug.Log("Game should NOT be paused rn");
            }
            else
            {
                Pause();
                Debug.Log("Game should be paused rn");
            }
        }
    }
}
