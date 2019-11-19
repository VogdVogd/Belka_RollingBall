using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create spikes with some length at position.
public class CreateSpikes
{
    static public GameObject Create( GameObject spikePrefab, float width, float oneWidth, Vector3 position )
    {
        int num = (int)(width / oneWidth);
        GameObject obj = CreateSpikesArray(spikePrefab, num, oneWidth);

        obj.transform.position = position;

        return obj;
    }

    static private GameObject CreateSpikesArray( GameObject prefab, int amount, float oneWidth )
    {
        GameObject container = new GameObject("spikes");
        for (int i = 0; i < amount; i++)
        {
            GameObject spike = GameObject.Instantiate(prefab, container.transform);
            spike.transform.position = new Vector3(i * oneWidth, 0, 0);
        }

        return container;
    }
}
