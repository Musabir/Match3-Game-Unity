using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Text button;

    void Start()
    {
       
    }
  
    public void Play()
    {

        SceneManager.LoadScene("scene");

    }
    public void Option()
    {

        SceneManager.LoadScene("Options");

    }


    public void Help()
    {
        SceneManager.LoadScene("Help");
       
    }

    public void Quit()
    {
       
        Application.Quit();
    }

}
