using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetDropdownValue : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown dropdown;

    public void HandleInputData()
    {
        int val = dropdown.value;
        Debug.Log(val);
        if (val == 0)
        {
            SongManager.SongNum = 0;
        }
        if (val == 1)
        {
            SongManager.SongNum = 1;
        }
    }
}
