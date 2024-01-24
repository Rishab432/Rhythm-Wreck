using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _missesInARow;
    private float _delay = 4f;
    [SerializeField] private AudioSource _beatmapAudio;
    [SerializeField] private AudioSource _missAudio;

    void Start()
    {
        _beatmapAudio.PlayDelayed(_delay);
    }

    void Update()
    {
        if (_missesInARow == 400)
        {
            SceneManager.LoadScene("Start");
        }
        if (NoteActuator.Missed && NoteActuator.Combo >= 5)
            _missAudio.Play();
        if (EventManager.Paused == true)
            Debug.Log("pausemusic");
            _beatmapAudio.Pause();
        if (EventManager.Paused == false)
            _beatmapAudio.Play();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (NoteActuator.Combo >= 5)
        {
            _missAudio.Play();

        }
        Destroy(col.gameObject);
        NoteActuator.Combo = 0;
        _missesInARow += 1;
    }


}
