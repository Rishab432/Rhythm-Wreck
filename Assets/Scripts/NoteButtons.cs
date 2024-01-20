using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteButtons : MonoBehaviour
{
    public int Value;
    private int[] _inputList = new int[4];
    private string[] _fruit = new string[5] { "GRAPE", "KIWI", "PINEAPPLE", "COCONUT", "WATERMELON" };
    //static Random random = new Random();

    // Start is called before the first frame update
    //--------------------------------------
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
//--------------------------------------
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
//--------------------------------------
    public void CheckValues()
    {
        if (CheckList(RhythmMatcher.Instance.RhythmList, 0))
            Debug.Log("CORRECT");
        else
            Debug.Log("LOUD INCORRECT BUZZER");

        Debug.Log($"original {RhythmMatcher.Instance.RhythmList[0]}");
        Debug.Log($"original {RhythmMatcher.Instance.RhythmList[1]}");
        Debug.Log($"original {RhythmMatcher.Instance.RhythmList[2]}");
        Debug.Log($"original {RhythmMatcher.Instance.RhythmList[3]}");
        Debug.Log($"input {_inputList[0]}");
        Debug.Log($"input {_inputList[1]}");
        Debug.Log($"input {_inputList[2]}");
        Debug.Log($"input {_inputList[3]}");

        RhythmMatcher.Instance.RhythmList = new int[4] { Random.Range(1, 6), Random.Range(1, 6), Random.Range(1, 6), Random.Range(1, 6) };
    }
//--------------------------------------

    public bool CheckList(int[] list, int num)
    {
        if (list[num] == _inputList[num])
        {
            if (num < 3)
                CheckList(list, num + 1);
            return true;
        }
        return false;

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
