using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderigAI : MonoBehaviour {
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    public float gravity = -9.8f;
    private bool alive;

    public void SetAlive(bool _alive)
    {
        alive = _alive;
    }

	// Use this for initialization
	void Start () {
        alive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
	}
}
