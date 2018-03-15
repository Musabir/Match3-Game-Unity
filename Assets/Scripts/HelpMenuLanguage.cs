using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HelpMenuLanguage : MonoBehaviour {


    public Text ins;
    public Text cont; 
    string englishInstruction = "How to play?";
    string russianInstruction = "Как играть?";
    string estonianInstruction = "Kuidas mängida?";
    string turkishInstruction = "Bilgi";
	string czechInstruction = "Jako tuto hru hrat?";






    string englishContex = "After starting the game, you can choose the language of instruction, and enable or disable sound accoridng to your preference. The main goal of the game is to align at least 3 same shaped and colored diamonds. Target score is set at the beginning, and by merging the diamonds larger score has to be reached in order to pass the current level and enter another one.  ";
    string russianContex = "После начала игры Вам предоставляется возможность выбрать язык для указаний, а также включить и выключить звук согласно вашим предпочтениям. Главной задачей игры является соединение как минимум трёх схожих по цвету и форме драгоценных камней. Нужное количество пунктов определяется в начале игры, и, соединяя камни в цепочки, должно быть достигнуто максимальное количество очков, чтобы вступить на следующий уровень.";
    string estonianContex = "Mängu algul on võimalik valida instruktsioonide keel ning lülitada heli sisse ja välja vastavalt eelistusele. Mängu põhiline eesmärk on järjestada 3 või enam sama kuju ja värviga juveeli. Taseme algul määratakse punktisumma, mille peab juveelidega kombinatsioone saades ületama, et jõuda järgmisele tasemele.";
    string turkishContex = "Bu oyunda siz kendinize uygun dili seçe bilir, ve sesi açıp-kapata bilirsiniz. Oyunun amacı en azı 3 ayni formda ve rengde olan elmasları dizmekdir. Her kademenin başında belirli bir miktarda hadef scor koyulur ve oteki kademeye geçmek için hadefdeki miktarın üzerinde scor toplamak lazım. ";
	string czechContex = "Na začátku hry máte možnost výběru jazyka a zapnout nebo vypnout zvuk podle vášeho přání. Hlávním cílem hry je spojování tří shodných drahokamů nebo více. Spojováním pobíráte body a když máte dost bodů přejete na nový úroveň. ";
   
	// Use this for initialization
    void Start () {
        if(Language.GetIndex()==0)
        {
            cont.text = englishContex;
            ins.text = englishInstruction;
        }
        if (Language.GetIndex() == 1)
        {
            cont.text = russianContex;
            ins.text = russianInstruction;
        }
        if (Language.GetIndex() == 2)
        {
            cont.text = estonianContex;
            ins.text = estonianInstruction;
        }
        if (Language.GetIndex() == 3)
        {
            cont.text = turkishContex;
            ins.text = turkishInstruction;
        }
		if (Language.GetIndex() == 4)
		{
			cont.text = czechContex;
			ins.text = czechInstruction;
		}


    }
	
}
