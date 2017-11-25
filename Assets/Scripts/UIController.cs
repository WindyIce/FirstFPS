using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingPopup settingPopup;
    [SerializeField] private EndingPopUp endingPopUp;
    

    private int score;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);//响应事件的方法
        Messenger.AddListener(GameEvent.PLAYER_DIED, OnOpenEnding);
    }

    private void OnEnemyHit()
    {
        score += 1;
        scoreLabel.text = score.ToString();
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT,OnEnemyHit);
        Messenger.RemoveListener(GameEvent.PLAYER_DIED, OnOpenEnding);
    }

    // Use this for initialization
    void Start () {
        score = 0;
        scoreLabel.text = score.ToString();

        settingPopup.Close();
        endingPopUp.Close();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnOpenSettings()
    {
        settingPopup.Open();
    }

    public void OnOpenEnding()
    {
        endingPopUp.Open();
    }
}
