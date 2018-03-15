using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sound : MonoBehaviour {

   public  Toggle toogle;
    private static bool t;
	// Update is called once per frame
	void Update()
    {
        method();
    }

    void method()
    {
        toogle.isOn = t;
    }

  public  void SetOn(bool toog)
    {
       
        t = toog;
    }
    public static bool GetOn()
    {
        return t;
    }
}
