
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "New GenerateParams", menuName = "Generate Params", order = 51)]
public class GenerateParams : ScriptableObject
{
    [Header("Bad block generate params")]
    [SerializeField]
    private Vector2 _gapWidth;
    [SerializeField]
    private Vector2 _spikesWidth;

    [Header("One spike size")]
    [SerializeField]
    private Vector2 _spikeSize;


    // Access.
    public float GapWidth
    {
        get { return Random.Range(_gapWidth.x, _gapWidth.y); }
    }

    public float SpikesWidth
    {
        get { return Random.Range(_spikesWidth.x, _spikesWidth.y); }
    }

    public Vector2 SpikeSize
    {
        get { return _spikeSize; }
    }
}
