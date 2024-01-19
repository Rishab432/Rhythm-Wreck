using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteButtons : MonoBehaviour
{
    public int Index;
    public int Value;
    //static Random random = new Random();
    private int[] _inputList = new int[] { Random.Range(1, 6), 0, 0, 0 };

    // Start is called before the first frame update
//--------------------------------------
    public void SetValueToTa()
    {
        Value = 1;
    }
    public void SetValueToTiti()
    {
        Value = 2;
    }
    public void SetValueToTiTika()
    {
        Value = 3;
    }
    public void SetValueToTikaTi()
    {
        Value = 4;
    }
    public void SetValueToTikaTika()
    {
        Value = 5;
    }
//--------------------------------------
    public void SetIndexToTa()
    {
        _inputList[1] = Value;
    }
    public void SetIndexToTiti()
    {
        _inputList[2] = Value;
    }
    public void SetIndexToTiTika()
    {
        _inputList[3] = Value;
    }
    public void SetIndexToTikaTi()
    {
        _inputList[4] = Value;
    }
//--------------------------------------
    public void CheckValues()
    {
        //if (CheckList(RhythmMatcher.GetComponent<RhythmList>(), 0))
        //    Debug.Log("CORRECT");
        //else
            //Debug.Log("LOUD INCORRECT BUZZER");
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
