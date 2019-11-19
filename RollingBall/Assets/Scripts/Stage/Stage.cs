using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Main game class.
public class Stage : MonoBehaviour
{
    // Screen borders.
    [SerializeField]
    private Transform _leftTop;
    [SerializeField]
    private Transform _rightBottom;


    public Vector3 LeftTop
    {
        get
        {
            if (_leftTop)
                return _leftTop.position;
            else
                return Vector3.zero;
        }
    }

    public Vector3 RightBottom
    {
        get
        {
            if (_rightBottom)
                return _rightBottom.position;
            else
                return Vector3.zero;
        }
    }


    // Scores and distance.
    public float score;
    public float distance;


    static bool firstLaunch = true;
    static private Stage _inst;
    static public Stage Inst
    {
        get { return _inst; }
    }


    private void Start()
    {
        // Dont show main menu after restart.
        if (firstLaunch)
        {
            MainMenu.Create();
            firstLaunch = false;
        }
    }

    private void Awake()
    {
        _inst = this;
    }

    private void OnDestroy()
    {
        _inst = null;
    }

    public void Win()
    {

    }

    public void Loose()
    {
        GameSave.BestDistance = distance;
        GameSave.BestScore = score;

        GameSave.SummDistance += distance;
        GameSave.SummScore += score;

        LooseMenu.Create();
    }
}
