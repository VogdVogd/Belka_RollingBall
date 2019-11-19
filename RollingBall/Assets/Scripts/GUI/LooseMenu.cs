using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Loose menu with reset button and stage scores.
public class LooseMenu : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text distanceText;
    [SerializeField]
    private Text bestScoreText;
    [SerializeField]
    private Text bestDistanceText;

    private void Start()
    {
        scoreText.text = Stage.Inst.score.ToString("0");
        distanceText.text = Stage.Inst.distance.ToString("0");

        bestScoreText.text = GameSave.BestScore.ToString("0");
        bestDistanceText.text = GameSave.BestDistance.ToString("0");
    }
    
    static public void Create()
    {
        UnityEngine.Object obj = Resources.Load("LooseMenu");
        GameObject obj2 = Instantiate(obj as GameObject);

        // Set camera.
        Canvas c = obj2.GetComponent<Canvas>();
        if (c)
            c.worldCamera = Camera.main;
    }
}
