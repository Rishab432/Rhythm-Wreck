using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;

public class SongManager : MonoBehaviour
{
    public static int SongNum = 0;
    public static SongManager Instance;
    public AudioSource MLaudioSource;
    public AudioSource JTaudioSource;

    public Lane[] lanes;
    public float songDelayInSeconds;
    //public double marginOfError; // in seconds

    //public int inputDelayInMilliseconds;


    public string MLfileLocation;
    public string JTfileLocation;
    public string fileLocation;
    public float noteTime;
   
    public float noteTapY; 
    public float noteTapX;


    public static MidiFile midiFile;


    // Start is called before the first frame update
    void Start()
    {

        Instance = this;
        ReadFromFile();
        
    }

    private void ReadFromFile()
    {
        if (SongNum == 0)
            fileLocation = MLfileLocation;
        if (SongNum == 1)
            fileLocation = JTfileLocation;

        midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + fileLocation);
        GetDataFromMidi();
    }

    private void GetDataFromMidi()
    {
        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        foreach (var lane in lanes) lane.SetTimeStamps(array);

        Invoke(nameof(StartSong), songDelayInSeconds);
    }
    public void StartSong()
    {
        if (SongNum == 0)
            MLaudioSource.Play();
        if (SongNum == 1)
            JTaudioSource.Play();
    }
    public static double GetAudioSourceTime()
    {
        if (SongNum == 0)
            return (double)Instance.MLaudioSource.timeSamples / Instance.MLaudioSource.clip.frequency;
        else
            return (double)Instance.JTaudioSource.timeSamples / Instance.JTaudioSource.clip.frequency;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
