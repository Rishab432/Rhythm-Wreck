using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TopScores : MonoBehaviour
{
    [SerializeField] private Text _topScore1;
    [SerializeField] private Text _topScore2;
    [SerializeField] private Text _topScore3;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _topScore1.text = NoteActuator.HighScore1.ToString();
        _topScore2.text = NoteActuator.HighScore2.ToString();
        _topScore3.text = NoteActuator.HighScore3.ToString();

    }
}
