using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _missesInARow;
    public float delay = 3f;
    [SerializeField] private AudioSource _beatmapAudio;
    [SerializeField] private AudioSource _missAudio;

    void Start()
    {
        _beatmapAudio.PlayDelayed(delay);
    }

    void Update()
    {
        if (_missesInARow == 400)
        {
            Debug.Log("dsdsadsdsds");
            SceneManager.LoadScene("Start");
        }
        if (NoteActuator.Missed && NoteActuator.Combo >= 5)
            _missAudio.Play();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (NoteActuator.Combo >= 5)
        {
            _missAudio.Play();
            Debug.Log("misssound");

        }
        Destroy(col.gameObject);
        NoteActuator.Combo = 0;
        _missesInARow += 1;
    }


}
