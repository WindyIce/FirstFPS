using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {

    public float speed = 6.0f;

    public float gravity = -9.8f;

    private CharacterController characterController;

	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);//将对角移动速率限制的和沿轴移动一样
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);//从本地坐标变为全局坐标
        characterController.Move(movement);
	}
}
