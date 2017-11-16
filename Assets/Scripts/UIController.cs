using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField] private Text scoreLabel;

	// Use this for initialization
	void Start () {
        scoreLabel.text = Time.realtimeSinceStartup.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnOpenSettings()
    {
        Debug.Log("open setting");
    }
}
