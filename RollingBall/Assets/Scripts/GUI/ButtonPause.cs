using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonPause : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            Click();
        });
    }
	
    void Click() 
    {
        MainMenu.Create();
    }
}