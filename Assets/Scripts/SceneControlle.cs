using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControlle : MonoBehaviour {

    [SerializeField] private GameObject enemyPrefab;//序列化用于链接预设对象
    private GameObject enemy;//跟踪场景中敌人实例

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (enemy == null)
        {
            enemy = Instantiate(enemyPrefab) as GameObject;//复制了预设对象
            enemy.transform.position = new Vector3(0, 1, 5);
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }
	}
}
