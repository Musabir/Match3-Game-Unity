using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    Image fillImage;
  

    public TimerForLoading loadingTime;

   public static float time;
	// Use this for initialization
	void Start () {
        fillImage = this.GetComponent<Image>();
        time = MenuInTheGame.time;
     


    }
	
	// Update is called once per frame
	void Update () {
        if (loadingTime.time <= 0)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                fillImage.fillAmount = time / MenuInTheGame.time;
            }
        }
        
    }
}
