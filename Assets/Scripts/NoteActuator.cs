using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteActuator : MonoBehaviour
{
    public KeyCode key;
    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        if (col.gameObject.tag == "Note")
            Destroy(col.gameObject);
    }
}
