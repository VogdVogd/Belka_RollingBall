using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Generate platforms and spikes according to the ball speed.
public class MapGenerator : MonoBehaviour
{
    [Header("Params")]
    [SerializeField]
    private GenerateParams generatorParams;

    [Header("Game area borders")]
    [SerializeField]
    private Transform topPoint;
    [SerializeField]
    private Transform bottomPoint;
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private float freeBeginLength;

    [Header("Prefabs for construction")]
    [SerializeField]
    private GameObject platformPrefab;
    [SerializeField]
    private GameObject spikePrefab;

    [Header("Ball for getting generation params")]
    [SerializeField]
    private BallController ball;

    // Store all created objects.
    private Dictionary<GameObject, float> objects = new Dictionary<GameObject, float>();

    private Vector3 topEnd;
    private Vector3 bottomEnd;

    private void Start()
    {
        topEnd = startPoint.position;
        topEnd.y = topPoint.position.y;

        bottomEnd = startPoint.position;
        bottomEnd.y = bottomPoint.position.y;

        GameObject obj;
        obj = CreateGood(freeBeginLength, topEnd, -1);
        topEnd.x += freeBeginLength;
        objects.Add(obj, topEnd.x);

        obj = CreateGood(freeBeginLength, bottomEnd, 1);
        bottomEnd.x += freeBeginLength;
        objects.Add(obj, bottomEnd.x);
    }

    private void Update()
    {
        GenerateNew();
        DeleteOld();
    }

    private void GenerateNew()
    {
        Vector3 generatePoint = ball.transform.position + new Vector3(40, 0, 0);
        while (topEnd.x < generatePoint.x || bottomEnd.x < generatePoint.x)
            GenerateStep();
    }

    private void DeleteOld()
    {
        Vector3 deletePoint = ball.transform.position - new Vector3(20, 0, 0);

        foreach (KeyValuePair<GameObject, float> kV in objects)
        {
            if (kV.Value < deletePoint.x)
            {
                Destroy(kV.Key);
                objects.Remove(kV.Key);
                return;
            }
        }
    }

    // Generate four elements as a one step.
    private void GenerateStep()
    {
        GameObject obj;
        float w;
        float changeDistance = GetChangeDistance();

        // Create bottom bad part.
        w = generatorParams.SpikesWidth;
        obj = CreateBad(w, bottomEnd, 1);
        bottomEnd.x += w;
        objects.Add(obj, bottomEnd.x);

        // Create top good part.
        w = bottomEnd.x - topEnd.x + changeDistance;
        obj = CreateGood(w, topEnd, -1);
        topEnd.x += w;
        objects.Add(obj, topEnd.x);

        // Create top bad part.
        w = generatorParams.SpikesWidth;
        obj = CreateBad(w, topEnd, -1);
        topEnd.x += w;
        objects.Add(obj, topEnd.x);

        // Create bottom good part.
        w = topEnd.x - bottomEnd.x + changeDistance;
        obj = CreateGood(w, bottomEnd, 1);
        bottomEnd.x += w;
        objects.Add(obj, bottomEnd.x);
    }

    //Get distance while changing side.
    private float GetChangeDistance()
    {
        float speed = ball.MoveSpeed;
        float changeTime = 1.0f;

        return speed * changeTime;
    }

    // Wee need some functions to generate bad and good blocks of fixed length.
    private GameObject CreateGood( float width, Vector3 p, int direction )
    {
        GameObject obj = Instantiate(platformPrefab, p + new Vector3(width / 2, 0, 0), Quaternion.identity);
        Vector3 s = obj.transform.localScale;
        s.x = width;
        obj.transform.localScale = s;

        return obj;
    }

    private GameObject CreateBad( float width, Vector3 p, int direction )
    {
        GameObject container = new GameObject("BadContainer");
        container.transform.position = p;

        // Gap.
        float gapWidth = generatorParams.GapWidth;
        float platformWidth = width - gapWidth;
        
        // Platform.
        GameObject platform = Instantiate(platformPrefab, container.transform);
        platform.transform.position = p + new Vector3(platformWidth / 2, 0, 0) + new Vector3(gapWidth, 0, 0);
        Vector3 s = platform.transform.localScale;
        s.x = platformWidth;
        platform.transform.localScale = s;

        // Spikes - only on platform.
        Vector3 spikePos = p + new Vector3(0, direction * generatorParams.SpikeSize.y, 0);
        spikePos.x += gapWidth;
        spikePos.x += generatorParams.SpikeSize.x / 2;
        GameObject spikes = CreateSpikes.Create(spikePrefab, platformWidth, generatorParams.SpikeSize.x, spikePos);
        if (direction == -1)
        {
            s = spikes.transform.localScale;
            s.y = -s.y;
            spikes.transform.localScale = s;
        }
        spikes.transform.SetParent(container.transform);

        return container;
    }
}
