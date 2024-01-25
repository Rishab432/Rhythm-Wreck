using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class NoteActuator : MonoBehaviour
{
    public KeyCode Key;
    static public int Combo;
    private int _score;
    static public int TotalScore;
    bool active = false;
    static public bool Missed;
    static public int MaxCombo;

    GameObject note;
    Color old;

    
    // Start is called before the first frame update
    void Start()
    {
        old = GetComponent<SpriteRenderer>().color;
        _score = 0;
        MaxCombo = 0;


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
            }
            else
            {
                Missed = true;
                Combo = 0;
            }

                
        }
        if (Input.GetKeyUp(Key))
            GetComponent<SpriteRenderer>().color = old;

        CheckMaxCombo();
        //CheckHighScores();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "LastNote"){
            Debug.Log("hitt");
            GameManager.Instance.Grade();
        }

        if (col.gameObject.tag == "Note"){
            active = true;
            note = col.gameObject;

        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        active = false; 
    }

    public void CheckMaxCombo()
    {
        if(Combo > MaxCombo){
            MaxCombo = Combo;
            Debug.Log(MaxCombo);
        }
    }
    //public void CheckHighScores()
    //{
        //if (TotalScore >  FileManager.Instance.HighScores[0])
        //{
            //FileManager.Instance.ChangeHighScore(0, TotalScore);
            //Debug.Log(TotalScore);
        //}
    //}


}
