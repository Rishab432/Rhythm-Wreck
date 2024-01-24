using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CollectiblesManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _collectibles;
    [SerializeField] private GameObject[] _names;
    [SerializeField] private GameObject[] _buyButtons;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (KeyValuePair<string, bool> keyValuePair in FileManager.Instance.Collectibles)
        {
            if (keyValuePair.Value)
            {
                _collectibles[i].color = Color.white;
                _buyButtons[i].SetActive(false);
                _names[i].SetActive(true);
            }
            i++;
        }
    }

    public void BuyCococup()
    {
        if (FileManager.Instance.Tokens > 20)
        {
            FileManager.Instance.RemoveTokens(20);
            FileManager.Instance.ChangeCollectibles("Cococup");
            _collectibles[0].color = Color.white;
            _buyButtons[0].SetActive(false);
            _names[0].SetActive(true);
        }
    }
}
