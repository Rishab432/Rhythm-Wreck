using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RhythmMatcher : MonoBehaviour
{
    public AudioSource Aud;
    public AudioClip Ta;
    public AudioClip Titi;
    public AudioClip TiTika;
    public AudioClip TikaTi;
    public AudioClip TikaTika;

    private int[] _rhythmList = new int[] { 0, 0, 0, 0 };
    private int[] _randomList = new int[] { 0, 0, 0, 0 };

    int[] temp = new int[] { 1, 3, 3, 2 };

    private float _waitTime = 3/4f;
    public int _iteration = 0;

    void PlayNote(int[] list, int iteration)
    {
        int currentAudio = list[iteration];
        if (currentAudio == 1)
            Aud.clip = Ta;
        if (currentAudio == 2)
            Aud.clip = Titi;
        if (currentAudio == 3)
            Aud.clip = TiTika;
        if (currentAudio == 4)
            Aud.clip = TikaTi;
        if (currentAudio == 5)
            Aud.clip = TikaTika;
        Aud.Play();
    }
    public void PlayBar()
    {
        _waitTime -= Time.deltaTime;
        if (_waitTime < 0f && _iteration < 4)
        {
            PlayNote(temp, _iteration);
            _waitTime = 3/4f;
            _iteration++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // hi
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            PlayBar();
        if (Input.GetKeyDown(KeyCode.Space))
            _iteration = 0;
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 12b11b74765f03a76060f1e36667f3d2ebf44c02
