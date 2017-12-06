using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    
    public AudioSource gamemusic;
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    

    void Awake()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("Pause");
        optionsMenu = GameObject.FindGameObjectWithTag("Options");

        



    }

    // Use this for initialization
    void Start ()
    {

        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0.1f;
            gamemusic.Pause();
        }
      
	}

    public void Gamereturn()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gamemusic.Play();
    }

    public void Optionsscreen()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void BacktoPauseMenu()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
