using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject pausescreen;
    public GameObject Optionscreen;
    public AudioSource gamemusic;

    

    void Awake()
    {
        pausescreen = GameObject.Find("Pause");
        Optionscreen = GameObject.Find("Options");
        pausescreen.SetActive(false);
        Optionscreen.SetActive(false);

        

    }

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.Escape))
        {
            pausescreen.SetActive(true);
            Time.timeScale = 0.1f;
            gamemusic.Pause();
        }
      
	}

    public void Gamereturn()
    {
        pausescreen.SetActive(false);
        Time.timeScale = 1;
        gamemusic.Play();
    }

    public void Optionsscreen()
    {
        pausescreen.SetActive(false);
        Optionscreen.SetActive(true);
    }

    public void BacktoPauseMenu()
    {
        pausescreen.SetActive(true);
        Optionscreen.SetActive(false);
    }
}
