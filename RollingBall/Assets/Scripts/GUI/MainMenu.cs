using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Main menu class.
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text distanceText;

    private void Start()
    {
        Time.timeScale = 0;
        scoreText.text = GameSave.SummScore.ToString("0");
        distanceText.text = GameSave.SummDistance.ToString("0");
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    static public void Create()
    {
        UnityEngine.Object obj = Resources.Load("MainMenu");
        GameObject obj2 = Instantiate(obj as GameObject);

        // Set camera.
        Canvas c = obj2.GetComponent<Canvas>();
        if (c)
            c.worldCamera = Camera.main;
    }
}
