using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteButtons : MonoBehaviour
{
    public int Index;
    //static Random random = new Random();
    private int[] _inputList = new int[] { Random.Range(1, 6), 0, 0, 0 };

    // Start is called before the first frame update
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
       if (Input.GetKey(KeyCode.C))
        {
            if (CheckList(RhythmMatcher.GetComponent<RhythmList>(), 0))
                Debug.Log("CORRECT");
            else
                Debug.Log("LOUD INCORRECT BUZZER");
        }
        Debug.Log(_inputList[1]);
    }
}
