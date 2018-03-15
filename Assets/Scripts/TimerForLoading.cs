using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerForLoading : MonoBehaviour {

   
    Image loadingBar;
   
    public float time;
    public float loadingTime = 2;
    // Use this for initialization
    void Start()
    {
        loadingBar = this.GetComponent<Image>();
        time = loadingTime;
  
    }

    // Update is called once per frame
    void Update()
    {
       
            if (time > 0)
            {
                time -= Time.deltaTime;
                loadingBar.fillAmount = time / loadingTime;
            }
        }
     
    
}
