using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonRestart : MonoBehaviour 
{
	// Use this for initialization
	void Start ()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            RestartStage();
        });
    }
	
    static public void RestartStage () 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}