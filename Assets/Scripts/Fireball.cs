using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public float speed = 10.0f;
    public int damage = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, speed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)//其他对象和该触发器碰撞时
    {
        PlayCharacter playCharacter = other.GetComponent<PlayCharacter>();
        if (playCharacter != null)
        {
            playCharacter.Hurt(damage);
        }
        Destroy(this.gameObject);
    }
}
