using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteActuator : MonoBehaviour
{
    public KeyCode key;
    static public int Combo;
    private int Score;
    static public int TotalScore;
    bool active = false;
    GameObject note;
    Color old;

    
    // Start is called before the first frame update
    void Start()
    {
        old = GetComponent<SpriteRenderer>().color;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            GetComponent<SpriteRenderer>().color = new Color(0,0,0);
            if(active)
            {
                Destroy(note);
                Combo += 1;
                Debug.Log(Combo);
                Score = 197 * Combo;
                TotalScore = TotalScore + Score; 
            }
        }
        if (Input.GetKeyUp(key))
            GetComponent<SpriteRenderer>().color = old;
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
}
