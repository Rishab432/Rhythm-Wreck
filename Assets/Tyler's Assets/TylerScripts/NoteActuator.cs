using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteActuator : MonoBehaviour
{
    // y value of the start of the song y = 11.25
    public KeyCode Key;
    static public int Combo;
    private int _score;
    static public int TotalScore;
    bool active = false;
    static public bool Missed;
    private int _coins;
    private int _totalCoins;

    GameObject note;
    Color old;

    
    // Start is called before the first frame update
    void Start()
    {
        old = GetComponent<SpriteRenderer>().color;
        _score = 0;
        _coins = GetCoins();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            GetComponent<SpriteRenderer>().color = new Color(0,0,0);
            if(active)
            {
                Destroy(note);
                Combo += 1;
                _score = 197 * Combo;
                TotalScore = TotalScore + _score;
                _totalCoins = _coins + TotalScore/100;
                SetCoins(_totalCoins);
            }
            else
            {
                Missed = true;
                Combo = 0;
                Debug.Log(GetCoins());
            }

                
        }
        if (Input.GetKeyUp(Key))
            GetComponent<SpriteRenderer>().color = old;


        CheckHighScores(TotalScore);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        if (col.gameObject.tag == "Note")
            note = col.gameObject;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        active = false; 
    }

    private void CheckHighScores(int Score)
    {
        if (Score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", Score);
            Debug.Log(Score);
        }
    }

    public int GetHighScores()
    {
        return PlayerPrefs.GetInt("Highscore");
    }

    public void SetCoins(int Coins)
    {
        PlayerPrefs.SetInt("Coins", Coins);
    }

    public int GetCoins()
    {
        return PlayerPrefs.GetInt("Coins");
    }


}
