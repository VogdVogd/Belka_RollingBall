using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Check ball colisions with spikes and platforms.
[RequireComponent(typeof(BallController))]
public class BallCollider : MonoBehaviour
{
    private int spikesLayer;
    private BallController ball;

    private void Start()
    {
        spikesLayer = LayerMask.NameToLayer("Spikes");
        ball = GetComponent<BallController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ball.AllowChangeSide();

        if (collision.gameObject.layer == spikesLayer)
            ball.Kill();
    }
}
