using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _missesInARow;
    public float delay = 3f;
    [SerializeField] private AudioSource _beatmapAudio;

    void Start()
    {
        _beatmapAudio.PlayDelayed(delay);
    }

    void Update()
    {
        if (_missesInARow == 3)
        {
            Debug.Log("dsdsadsdsds");
            SceneManager.LoadScene("Start");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        NoteActuator.Combo = 0;
        Debug.Log(NoteActuator.Combo);
        _missesInARow += 1;
    }


}
