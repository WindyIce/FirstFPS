using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPopUp : MonoBehaviour {

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
