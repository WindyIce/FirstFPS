using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneControlle : MonoBehaviour {

    [SerializeField] private GameObject enemyPrefab;//序列化用于链接预设对象
    private GameObject enemy;//跟踪场景中敌人实例
    private double timeCount;
    private const int enemyProducedPerSecond = 3;
    private List<int> enemySeconds;

	// Use this for initialization
	void Start () {
        timeCount = 0;
        enemySeconds = new List<int>();
	}
	
	// Update is called once per frame
	void Update () {
        //每个帧都加上每帧所用秒数
        timeCount += Time.deltaTime;
        if ((int)timeCount%enemyProducedPerSecond==0&&
            !enemySeconds.Contains((int)timeCount / enemyProducedPerSecond))
        {
            enemy = Instantiate(enemyPrefab) as GameObject;//复制了预设对象
            enemy.transform.position = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(1.0f,20.0f), Random.Range(-20.0f, 20.0f));
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
            //这一秒如果已经加了敌人，就不用再加
            enemySeconds.Add((int)timeCount / enemyProducedPerSecond);
        }
	}
}
