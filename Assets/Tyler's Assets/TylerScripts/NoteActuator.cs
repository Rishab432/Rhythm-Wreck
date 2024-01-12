using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteActuator : MonoBehaviour
{
    public KeyCode key;
    bool active = false;
    GameObject note;
    Color old;
    
    // Start is called before the first frame update
    void Start()
    {
        old = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            GetComponent<SpriteRenderer>().color = new Color(0,0,0);
            if(active)
                Destroy(note);
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
