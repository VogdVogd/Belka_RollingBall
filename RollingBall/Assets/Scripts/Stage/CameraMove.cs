using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Camera follow target by x.
public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private Vector3 dPosition;

    private void Start()
    {
        dPosition = transform.position - target.position;
    }

    private void Update()
    {
        if (target)
        {
            Vector3 pos = transform.position;
            pos.x = target.position.x + dPosition.x;
            transform.position = pos;
        }
    }
}
