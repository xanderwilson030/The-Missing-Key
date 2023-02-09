using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    
    public bool hideMouse = false;

    void Start()
	{
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
	}

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        hideMouse = true;
        if (hideMouse)
		{
            Cursor.visible = false;
		}
    } 

    public void QuitGame()
	{
        Debug.Log("Quit!");
        Application.Quit();
	}
}
