using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInTheGame : MonoBehaviour {

    public Timer timer;
    public GridManager grid;
    public   GameObject restart;
    public  GameObject returnToMenu;
    public  GameObject quit;
    public  GameObject resume;
    public GameObject next;
    private int tar = 600;
    private int tim = 120;
    public static int t=600;
    public static float time = 120;

    bool gameover, nextlevel;
    public  bool check;
    string levelName;
    public static int highScore;
    int ff;

    void Start()
    {
       
        levelName = Application.loadedLevelName;
        nextlevel = false;
        gameover = false;
        check = false;
    }
    void Update()
    {
        if (GridManager.score > ff)
        {
            highScore += GridManager.score - ff;
            ff = GridManager.score;
        }
       
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("main");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        highScore = 0;
        t = tar;
        time = tim;
        SceneManager.LoadScene("scene");
       

    }
    public void Resume()
    {

    //    HideButtons();
        check = false;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(levelName);
        ff = 0;
        GridManager.score = 0;
        time -= 10;
        t = t + 100; 

      

    }
   
    public void HideButtons()
    {
        restart.SetActive(false);
        resume.SetActive(false);
        quit.SetActive(false);
        returnToMenu.SetActive(false);
        next.SetActive(false);
      
    }
    public  void showButtons()
    {
        check = true;
        restart.SetActive(true);
        resume.SetActive(true);
        quit.SetActive(true);
        returnToMenu.SetActive(true);

    }
   
   

    public  void gameOver()
    {
        gameover = true;
        check = false;
        showButtons();
        resume.SetActive(false);
    }
    
    public void nextLevel()
    {
      
        check = true;
        quit.SetActive(true);
        restart.SetActive(true);
        returnToMenu.SetActive(true);
        next.SetActive(true);
        
    }
   

}

