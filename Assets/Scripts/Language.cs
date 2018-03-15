using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Language : MonoBehaviour {
    static List<string> languages = new List<string>() { "English", "Russian", "Estonian", "Turkish", "Czech" };
    public Text[] text = new Text[2];

    string[] englishArray = new string[] { "Sound", "Back" };
    string[] russianArray = new string[] { "Звук", "Назад" };
    string[] estonianArray = new string[] { "Heli", "Tagasi" };
    string[] turkishArray = new string[] { "Ses", "Geri" };
	string[] czechArray = new string[] { "Zvuk", "Zpět" };

    private static int i;
    public Dropdown dropdown;

	// Use this for initialization
	void Start () {
        PopulateList();
	}
	
	// Update is called once per frame
	void PopulateList() {
       dropdown.AddOptions(languages);
        dropdown.value = i;

	
	}
   public void SetIndex(int index)
    {
        i = index;
    }
    public static int GetIndex()
    {
        Debug.Log(languages[i]);
        return i;
    }

    void Update()
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (GetIndex() == 0)
                text[i].text = englishArray[i];
            if (GetIndex() == 1)
                text[i].text = russianArray[i];
            if (GetIndex() == 2)
                text[i].text = estonianArray[i];
            if (GetIndex() == 3)
                text[i].text = turkishArray[i];
			if (GetIndex() == 4)
				text[i].text = czechArray[i];
        }
    }

}
