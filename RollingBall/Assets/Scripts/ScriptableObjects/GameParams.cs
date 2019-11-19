
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "New GameParams", menuName = "Game Params", order = 51)]
public class GameParams : ScriptableObject
{
    [Header("Score for changing side")]
    [SerializeField]
    private float _minScore;
    [SerializeField]
    private float _maxScore;
    [SerializeField]
    private float _increaseRadius;


    // Access.
    public float MinScore
    {
        get { return _minScore; }
    }

    public float MaxScore
    {
        get { return _maxScore; }
    }

    public float IncreaseRadius
    {
        get { return _increaseRadius; }
    }

}
