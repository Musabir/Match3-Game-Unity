using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameSceneLanguage : MonoBehaviour {

    public Text[] text = new Text[9];

    string[] englishArray = new string[] { "Resume", "Main Menu", "Restart", "Quit","Score", "Menu","High Score","Target","Next Level" };
    string[] russianArray = new string[] { "Продолжить", "Главное Mеню", "Заново", "Выхoд", "Cчет", "Mеню", "Рекорд", "Цель", "Следующий Уровень" };
    string[] estonianArray = new string[] { "Jätka", "Peamenüü", "Uuesti", "Välja", "Punktid", "Menüü" , "Kõrgeim punktisumma", "Sihtmärk", "Järgmisele Tasemele" };
    string[] turkishArray = new string[] { "Devam", "Menu", "Yeniden başla ", "Çık", "Puan", "Menu", "Yüksek puan","Hedef","Öteki Kademe" };
	string[] czechArray = new string[] { "Pokračovat", "Hlavní Menu", "Znova ", "Konec", "Počet Bodů", "Menu", "Nejlepší skóre","Cíl", "Další Úroveň" };
	void Start()
    {

        for (int i = 0; i < text.Length; i++)
        {
            if (Language.GetIndex() == 0)
                text[i].text = englishArray[i];
            if (Language.GetIndex() == 1)
                text[i].text = russianArray[i];
            if (Language.GetIndex() == 2)
                text[i].text = estonianArray[i];
            if (Language.GetIndex() == 3)
                text[i].text = turkishArray[i];
			if (Language.GetIndex() == 4)
				text[i].text = czechArray[i];
        }
    }
}
