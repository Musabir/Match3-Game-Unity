using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainSceneLanguage : MonoBehaviour {
    //  public Text 
    // Use this for initialization
    public Text[] text=  new Text[4];
   
    string[] englishArray = new string[] { "P   l  a  y", "H   e   l   p", "O  p  t  i  o  n  s", "Q   u   i   t" };
    string[] russianArray = new string[] { "И  г  р  а  т  ь", "П  о  м  о  щ  ь", "Н  а  с  т  р  о  й  к  и", "В  ы  х  о  д" };
    string[] estonianArray = new string[] { "M  ä  n  g  i", "A   b   i", "S  ä  t  t  e  d", "V  ä  l  j  a" };
    string[] turkishArray = new string[] { "B  a  ş  l  a", "Y  a  r  d  i  m", "A  y  a  r  l  a  r ", "Ç   ı  k" };
	void Start () {
        
        for(int i = 0; i < text.Length; i++)
            {
            if (Language.GetIndex() == 0)
                text[i].text = englishArray[i];
            if (Language.GetIndex() == 1)
                text[i].text = russianArray[i];
            if (Language.GetIndex() == 2)
                text[i].text = estonianArray[i];
            if (Language.GetIndex() == 3)
                text[i].text = turkishArray[i];
        }
	}
	
	
}
