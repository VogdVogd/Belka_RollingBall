using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Game gui with score and distance for this run.
public class GameGui : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text distanceText;

    private void Update()
    {
        scoreText.text = Stage.Inst.score.ToString("0");
        distanceText.text = Stage.Inst.distance.ToString("0");
    }
}
