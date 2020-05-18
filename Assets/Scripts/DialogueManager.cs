using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This script manages the dialogues
public class DialogueManager : MonoBehaviour
{
    public Rigidbody2D player_rb2d;
    public GameObject dialogue_canvas;
    public Text dialogue_text;

    public int start_dialogue_counter = 0;

    public Missions missions;
    public bool start1_bubble_stopper = false;
    public bool start1r_bubble_stopper = false;
    public bool start2_bubble_stopper = false;
    public bool mission1_bubble_stopper = false;
    public bool mission2_bubble_stopper = false;
    public bool mission3_bubble_stopper = false;
    public bool mission4_bubble_stopper = false;
    public bool mission1_car_bubble_stopper = false;


    [TextArea(3,10)]
    public string[] sentences;
    private Queue<string> queue_sentences;

    
    // Start is called before the first frame update
    void Start()
    {
        queue_sentences = new Queue<string>();
        Start_Dialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Display_Next_Sentence();
        }
    }

    public void Start_Dialogue()
    {
        player_rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

        dialogue_canvas.SetActive(true);
        queue_sentences.Clear();

        foreach (string sentence in Sentences())
        {
            queue_sentences.Enqueue(sentence);
        }

        Display_Next_Sentence();
    }
    public void Display_Next_Sentence()
    {
        if (queue_sentences.Count == 0)
        {
            End_Dialogue();
            return;
        }

        string sentence = queue_sentences.Dequeue();
        dialogue_text.text = sentence;
    }

    public void End_Dialogue()
    {
        player_rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;

        dialogue_canvas.SetActive(false);
    }

    public string[] Sentences()
    {
        string[] empty = { };
        if (SceneManager.GetActiveScene().buildIndex == 1 && start1_bubble_stopper == false)
        {
            start1_bubble_stopper = true;
            string[] start_game_sentences = {"It has been a while, since I was in my home town.", "Let's look around for old times sake!"};
            //string[] start_game_sentences = {"Mintha csak egy örökkévalóság mióta utoljára itthon voltam.", "Nézzünk körbe a régi szép idők kedvéért"};
            start_dialogue_counter++;
            return start_game_sentences;
        }

        if (SceneManager.GetActiveScene().buildIndex == 2 && start1r_bubble_stopper == false)
        {
            start1r_bubble_stopper = true;
            string[] start_game_sentences = { "Let's get those switches" };
            //string[] start_game_sentences = { "Na kapcsoljuk le azt a villanyt" };
            start_dialogue_counter++;
            return start_game_sentences;
        }

        if (SceneManager.GetActiveScene().buildIndex == 3 && start2_bubble_stopper == false)
        {
            start2_bubble_stopper = true;
            string[] start_game_sentences = { "It has become really warm compaired to couple of years ago.", "But I have a secret spot, that helps me these hot days.", "Let's visit it!" };
            //string[] start_game_sentences = { "Igazán felmelegedett az idő az elmúlt élvekben.", "De szerencsére tudok egy titkos helyet, ami segít ezeken az izzasztó napokon.", "Látogassuk meg!" };
            start_dialogue_counter++;
            return start_game_sentences;
        }

        if (missions.mission1 == true && mission1_bubble_stopper == false)
        {
            mission1_bubble_stopper = true;            
            string[] mission1_sentences = { "So electricity is created by burning fossil fuels, huh?", "It also increase greenhouse gases, that makes the Earth wamer!", "Electricity contributes 25% of total greenhouse gas emmissions?", "Oh, it says you can help by reduce e-waste!", "I need to turn off the lights at home!" };
            //string[] mission1_sentences = { "Szóval az elektromosság fosszilis üzemanyag égetésével állítódik elő?", "Ez okozza az üvegház hatású gázok növekedését, ami melegebbé teszi a Földet!", "Az elekromosság 25%-ban járul hozzá a teljes üvegházhatású gáz kibocsátásához", "Oh azt írják segíthetsz, ha csökkented az áram pazarlást", "Le kell kapcsoljam otthon a villanyt!""};
            return mission1_sentences;
        }

        if (missions.mission1 == true && mission1_car_bubble_stopper == false)
        {
            mission1_car_bubble_stopper = true;
            string[] mission2_sentences = { "I have heard that greenhose gas emission is 17-30% lower than petrol or diesel cars", "I should change my car when I have the time!" };
            //string[] mission2_sentences = { "Úgy hallottam 17-30%-al kevesebb üvegházhatású gázok kibocsájtására képesek ...", "... az elekromos autók mint a dízel vagy a benzin", "Le kellene cseréljem ha lesz rá időm!" };
            return mission2_sentences;
        }
        
        if (missions.mission2 == true && mission2_bubble_stopper == false)
        {
            mission2_bubble_stopper = true;
            string[] mission2_sentences = {"So much waste all around.", "These paper trashes could be recycled ...", "... meaning 65% less energy to produce new ones.", "This way lots of trees are saved that traps CO2 ...", "... resulting in less greenhouse gas in the air!", "Let's grab them!"};
            //string[] mission2_sentences = { "Mennyi szemét!", "Ezek a papír alapú szemeteket könnyen újra lehetne hasznosítani ...", "... ami 65%-al kevesebb energiát venne igénybe, mint vadonat újat készíteni.", "Ezáltal sok fát lehetne megmenteni, amik elzárják a CO2-t ...", "... így kevesebb üvegházhatású gáz lenne a levegőbe!", "Kapjuk fel őket!" };
            return mission2_sentences;
        }

        if (missions.mission3 == true && mission3_bubble_stopper == false)
        {
            mission3_bubble_stopper = true;
            string[] mission3_sentences = { "Climate change has increased the length of fire season ...", "... by atmosphere draws moisture from soils resulting in dry lands.", "These forests catching on fire more easily.", "4.5 million forest fires yearly? Insane, it will increase! Need to stop it!", "Is this popcorn I smell?..."};
            //string[] mission3_sentences = { "Klímaváltozás meghosszabbítja az erdőtüzek könnyebb kialakulásának időszakát ...", "... azzal, hogy a meleg atmoszféra nedvességet von ki a talajból ezzel, szárazab földeket teremtve ...", "...és így könnyebben kigyulladnak az erdők és termőföldek", "4.5 millió erdőtűz? Hihetetlen, és csak nőni fog!", "Meg kell állítani!" };
            return mission3_sentences;
        }

        if (missions.mission4 == true && mission4_bubble_stopper == false)
        {
            mission4_bubble_stopper = true;
            string[] mission4_sentences = { "Trees absorb and store the CO2 emissions that are driving global heating!", "Every minute, a football stadium size of trees have been cut!","That much should not be cut, but every minute?", "Let’s see: 'New research estimates that a worldwide planting programme ...", "... could remove two-thirds of all the emissions from human activities.'", "That could be a solution: if everyone plants trees ...", "... even with a little we could help decelerate climate change!"};
            //string[] mission4_sentences = { "A fák elnyelik a CO2-t ami a fő oka a globális felmelegedésnek", "Minden percben egy stadionnyi fát vágnak ki a világon", "Nem szabadna ennyit kivágni, pláne nem percenként?!", "Nézzük csak: 'Az új kutatás előrelátása szerint, a világszintű ültetés program ..., "... meg tudná szűntetni a kibocsájtás két harmadát.'", "Ez lehet még egy megoldás: ha mindenki ültet legalább egy fát ...", "még ha csak egy keveset is de segítene csökkenteni a klímaváltozást"};
            return mission4_sentences;
        }

        return empty;
    }
}
