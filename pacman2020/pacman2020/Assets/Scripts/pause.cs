using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour {


      public GameObject pausepanel, pausebutton;

    public void Pause()
    {
        Time.timeScale = 0;

        pausebutton.SetActive(false);
        pausepanel.SetActive(true);

    }

    public void Unpause()
    {
        Time.timeScale = 1;
        pausebutton.SetActive(true);
        pausepanel.SetActive(false);
        
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}