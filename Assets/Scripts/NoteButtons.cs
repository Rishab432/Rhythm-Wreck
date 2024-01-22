using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteButtons : MonoBehaviour
{
/*
Initializing variables
*/

    public int Value;
    private int[] _inputList = new int[4];
    private string[] _fruit = new string[5] { "GRAPE", "KIWI", "PINEAPPLE", "COCONUT", "WATERMELON" };

    public AudioSource Aud;
    public AudioClip Correct;
    public AudioClip Incorrect;

/*
These functions set the cursor value to their respective fruits. They later get
added into the input list in the next funcitons
*/
    public void SetValueToTa()
    {
        Value = 1;
        Debug.Log("YOU PICKED UP GRAPE");
    }
    public void SetValueToTiti()
    {
        Value = 2;
        Debug.Log("YOU PICKED UP KIWI");
    }
    public void SetValueToTiTika()
    {
        Value = 3;
        Debug.Log("YOU PICKED UP PINEAPPLE");
    }
    public void SetValueToTikaTi()
    {
        Value = 4;
        Debug.Log("YOU PICKED UP COCONUT");
    }
    public void SetValueToTikaTika()
    {
        Value = 5;
        Debug.Log("YOU PICKED UP WATERMELON");
    }
/*
These functions set values to their respective indexes of the input list based
on the user input given in the previous funcitons.
*/

    public void SetIndexValueOne()
    {
        _inputList[0] = Value;
        Debug.Log($"INDEX 1 IS NOW {_fruit[Value - 1]}");

    }
    public void SetIndexValueTwo()
    {
        _inputList[1] = Value;
        Debug.Log($"INDEX 2 IS NOW {_fruit[Value - 1]}");
    }
    public void SetIndexValueThree()
    {
        _inputList[2] = Value;
        Debug.Log($"INDEX 3 IS NOW {_fruit[Value - 1]}");
    }
    public void SetIndexValueFour()
    {
        _inputList[3] = Value;
        Debug.Log($"INDEX 4 IS NOW {_fruit[Value - 1]}");
    }

/*
This function calls the CheckList function to see what value it returns. If the
value is true it plays the correct audio and if not it plays the incorrect audio.
After that it re-randomizes the rhythm list and resets the input list to its
default state regardless of if the player gets the answer correct.
*/
    public void CheckValues()
    {
        //Debug.Log($"original {RhythmMatcher.Instance.RhythmList[0]}");
        //Debug.Log($"original {RhythmMatcher.Instance.RhythmList[1]}");
        //Debug.Log($"original {RhythmMatcher.Instance.RhythmList[2]}");
        //Debug.Log($"original {RhythmMatcher.Instance.RhythmList[3]}");
        //Debug.Log($"input {_inputList[0]}");
        //Debug.Log($"input {_inputList[1]}");
        //Debug.Log($"input {_inputList[2]}");
        //Debug.Log($"input {_inputList[3]}");

        if (CheckList(RhythmMatcher.Instance.RhythmList, 0))
        {
            Aud.clip = Correct;
            Debug.Log("Correct");
        }
        else
        {
            Aud.clip = Incorrect;
            Debug.Log("Incorrect");
        }

        Aud.Play();

        RhythmMatcher.Instance.RhythmList = new int[4] { Random.Range(1, 6), Random.Range(1, 6), Random.Range(1, 6), Random.Range(1, 6) };
        _inputList = new int[4];
    }

/*
This function recursively iterates through the input and rhythm lists to check 
if all values are equal. If they are, it returns the value true.
*/
    public bool CheckList(int[] list, int num)
    {
        if (list[num] == _inputList[num])
        {
            if (num < 3)
                return CheckList(list, num + 1);
            return true;
        }
        return false;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
