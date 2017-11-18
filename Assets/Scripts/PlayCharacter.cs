using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCharacter : MonoBehaviour {

    private int health = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hurt(int damage)
    {
        health -= damage;
        // TODO:让玩家可以死，用事件系统？
        Debug.Log("Health: " + health);
    }
}
