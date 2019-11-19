using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Calculate score for a jump.
public class BallScores : MonoBehaviour
{
    [Header("Game params for score values")]
    [SerializeField]
    private GameParams gameParams;


    private int spikesLayer;

    private void Start()
    {
        spikesLayer = LayerMask.NameToLayer("Spikes");
    }

    public float GetScore( Vector3 p )
    {
        // Find distance to nearest spikes.
        Collider2D[] all = Physics2D.OverlapCircleAll(p, gameParams.IncreaseRadius);
        float min = float.MaxValue;

        for (int i = 0; i < all.Length; i++)
            if (all[i].gameObject.layer == spikesLayer)
            {
                float d = (p - all[i].transform.position).magnitude;
                if (d < min)
                {
                    min = d;
                }
            }

        if (min < gameParams.IncreaseRadius)
            return Mathf.Lerp(gameParams.MaxScore, gameParams.MinScore, min / gameParams.IncreaseRadius);
        else
            return 1;
    }
}
