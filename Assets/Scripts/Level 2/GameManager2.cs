using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using gs = goldScript2;
using mg = MapGenerator2;

public class GameManager2 : MonoBehaviour
{
    //public  static string[] wordList = {"DOG"};
    public  static string[] wordList = {"CANDLE","FUTURE","QUEUE","PIANO","STARS","CLOCK","CLOUDS","COFFIN","SKULL","JOKES"};
    // public  static string[] wordList = {"HEAL"};
    // public  static string[] hintList = {"Most Adopted Pet"};
    public static List<char> solvedList = new List<char>();
    public  static List<TMP_Text> letterHolderList = new List<TMP_Text>();
    public  static List<TMP_Text> healHolderList = new List<TMP_Text>();
    public  GameObject letterPrefab;
    public  GameObject HealPopup;
    public int healCount = 0;
    public TMP_Text healText;
    public bool healCollected = false;
    public  Transform letterHolder;
    public  Transform healHolder;
    public  TMP_Text hint;
    public  ScoringSystem instance;
    public static int hints;
    public static int index;
    public static string correct_word;

    public GameObject A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z;
    public static List<GameObject> chars = new List<GameObject>();

    public TMP_Text riddle;
    public static List<char> healList = new List<char>{'H', 'E', 'A', 'L'};
    public static string healWord = "HEAL";
    [SerializeField] GameObject scoreAnimPrefab;

    public  static List<TMP_Text> RiddleletterHolderList = new List<TMP_Text>();
    public  Transform RiddleletterHolder;
    public bool check = true;
    public TMP_Text RiddleCanvasriddle;
    public  GameObject RiddleCanvas;
    public  GameObject L2Canvas;

    public int count = 0;
    public AudioSource HintAudioPlayer, PowerAudioPlayer, WinAudioPlayer, LoseAudioPlayer, CorrectLetterAudioPlayer, WrongLetterAudioPlayer;
    
    void Start(){

        HealPopup.SetActive(false);
        mg.correctCharacters.Clear();
        mg.healCharacters.Clear();
        chars.Clear();
        hints = 3;
        chars.AddRange(new List<GameObject> {A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z });
        index = Random.Range(0, wordList.Length);
        correct_word = wordList[index];
        Debug.Log("CORRECT WORD IS:" + correct_word);

        // Analytics : LevelName, wordLength
        PlayerPrefs.SetString("levelName", "Level 2");
        PlayerPrefs.SetInt("wordLength", correct_word.Length);

        gs.assign_values();

        // hint.text = hintList[index]
        // hint.text = "Hint: " + gs.goldList[gs.goldIndex].ToString();
        riddle.text = gs.goldList[0].ToString();
        RiddleCanvasriddle.text = gs.goldList[0].ToString();
        

        string tempWord = wordList[index];

        string[] splittedWord = tempWord.Split(' ', tempWord.Length);
        char[] splitWord = tempWord.ToCharArray();
        // Debug.Log(tempWord);
        foreach (char letter in splitWord){
            solvedList.Add(letter);
            foreach(GameObject letter_prefab in chars){
              char inputLetter = char.Parse(letter_prefab.tag);
              if(inputLetter == letter){
                    mg.correctCharacters.Add(letter_prefab);
              }
            }
        }

        //Add letters of the word HEAL
        foreach (char letter in healList){
            foreach(GameObject letter_prefab in chars){
              char inputLetter = char.Parse(letter_prefab.tag);
              if(inputLetter == letter){
                mg.healCharacters.Add(letter_prefab);
              }
            }
        }

        for (int i = 0; i < tempWord.Length; i++)
        {
            GameObject temp = Instantiate(letterPrefab, letterHolder, false);
            TMP_Text tempText = temp.GetComponent<TMP_Text>();
            tempText.color = Color.black;
            letterHolderList.Add(tempText);
            GameObject temp1 = Instantiate(letterPrefab, RiddleletterHolder, false);
            RiddleletterHolderList.Add(temp1.GetComponent<TMP_Text>());

        }

        for (int i = 0; i < healWord.Length; i++)
        {
            GameObject temp = Instantiate(letterPrefab, healHolder, false);
            TMP_Text tempText = temp.GetComponent<TMP_Text>();
            tempText.color = Color.black;
            tempText.fontSize = 60;
            tempText.fontStyle = FontStyles.Bold;
            healHolderList.Add(tempText);
        }
    }

    // To call non static methods.
    public static GameManager2 gamag;
    internal static object displayCharacter;
    void Awake()
    {
        gamag = this;
    }

    public void updateGameHint()
    {
        hint.text = "Hint: " + gs.goldList[gs.goldIndex].ToString();
        showScoreAnim("1000000");
    }
    public void showScoreAnim(string text){
        Debug.Log("Anime Function Here");
        if(scoreAnimPrefab)
        {
            GameObject prefab = Instantiate(scoreAnimPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TMP_Text>().text = text;
            Debug.Log("Anime Here");
        }
    }

        public void Update(){
        if (check)
            Time.timeScale = 0; 
        if(count == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Continue Bar was pressed");
            L2Canvas.SetActive(false);
            RiddleCanvas.SetActive(true); 
            count++;
            
        }

        else if(count == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Continue Bar was pressed");
            
            RiddleCanvas.SetActive(false);
            Time.timeScale = 1;
            check = false;
            count++;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (gs.goldIndex > 0)
            {
                gs.currGoldIndex = (gs.currGoldIndex % gs.goldIndex) + 1;
                hint.text = "Hint: " + gs.goldList[gs.currGoldIndex].ToString();
            }
        }
}
}
