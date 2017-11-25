using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayCharacter : MonoBehaviour {

    private int health = 5;
    private bool isDead;
    [SerializeField] private Text healthLabel;
    private double timeCount;

	// Use this for initialization
	void Start () {
        isDead = false;
        timeCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead)
        {
            timeCount += Time.deltaTime;
            if (timeCount > 3.0f)
            {
                health = 5;
                SceneManager.LoadScene("DoneScene");
            }
        }
	}

    public void Hurt(int damage)
    {
        health -= damage;
        if (health >= 0)
            healthLabel.text = health.ToString();
        else
            healthLabel.text = "0";
        if (health == 0)
        {
            isDead = true;
            Messenger.Broadcast(GameEvent.PLAYER_DIED);
        }
    }
}
