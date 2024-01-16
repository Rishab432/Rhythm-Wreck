using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System;
using Unity.VisualScripting;


// data persistence code from https://pavcreations.com/data-persistence-or-how-to-save-load-game-data-in-unity/.
public class DataManager : MonoBehaviour
{
    [Serializable]
    public class GameData
    {
        //public static GameData Instance;

        public string FileName1 { get; set; }
        public string FileName2 { get; set; }
        public string FileName3 { get; set; }
        public string FileName4 { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public int Score3 { get; set; }
        public int Score4 { get; set; }
        public float BGMSliderVal { get; set; } = 1.00f;
        public float SFXSliderVal { get; set; } = 1.00f;
        public bool BGMToggle { get; set; } = true;
        public bool SFXToggle { get; set; } = true;

        public Dictionary<string, KeyCode> Keybinds = new()
        {
            { "Up", KeyCode.UpArrow },
            { "Down", KeyCode.DownArrow },
            { "Left", KeyCode.LeftArrow },
            { "Right", KeyCode.RightArrow }
        };
    }

    public static DataManager Instance;
    public GameData Data = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadData();
    }

    public void SaveData()
    {
        BinaryFormatter binaryFormatter = new();
        FileStream fileStream = File.Create(Application.persistentDataPath + "/GameData.dat");
        // set the data attributes to the current ones.
        binaryFormatter.Serialize(fileStream, Data);
        fileStream.Close();
    }

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/GameData.dat"))
        {
            BinaryFormatter binaryFormatter = new();
            FileStream fileStream = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);
            Data = binaryFormatter.Deserialize(fileStream) as GameData;
            fileStream.Close();
        }
        else
        {
            Debug.LogError($"Error: Save file could not be found in the given path: {Application.persistentDataPath + "/GameData.dat"}");
        }
    }
}