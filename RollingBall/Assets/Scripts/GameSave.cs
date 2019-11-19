using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave
{
    static public float BestScore
    {
        get
        {
            return PlayerPrefs.GetFloat("BestScore");
        }
        set
        {
            float best = PlayerPrefs.GetFloat("BestScore");
            if (value > best)
                PlayerPrefs.SetFloat("BestScore", value);
        }
    }

    static public float BestDistance
    {
        get
        {
            return PlayerPrefs.GetFloat("BestDistance");
        }
        set
        {
            float best = PlayerPrefs.GetFloat("BestDistance");
            if (value > best)
                PlayerPrefs.SetFloat("BestDistance", value);
        }
    }

    static public float SummScore
    {
        get
        {
            return PlayerPrefs.GetFloat("SummScore");
        }
        set
        {
            PlayerPrefs.SetFloat("SummScore", value);
        }
    }

    static public float SummDistance
    {
        get
        {
            return PlayerPrefs.GetFloat("SummDistance");
        }
        set
        {
            PlayerPrefs.SetFloat("SummDistance", value);
        }
    }
}
