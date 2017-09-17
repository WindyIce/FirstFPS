using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    public enum RotationAxes
    {
        MouseXAndY=0,
        MouseX=1,
        MouseY=2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityHor = 9.0f;         //水平旋转速度
    public float sensitivityVert = 9.0f;        //垂直旋转速度

    public float minimumVert = -45.0f;      //垂直旋转限制
    public float maximumVert = 45.0f;

    private float _rotationX=0;


	// Use this for initialization
	void Start () {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (axes == RotationAxes.MouseX)
        {
            //horizontal rotation
            transform.Rotate(0,Input.GetAxis("Mouse X") * sensitivityHor, 0);  //getAxis()获取鼠标输入
        }
        else if (axes == RotationAxes.MouseY)
        {
            //vertical rotation
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;//基于鼠标增加垂直角度
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);//垂直角度限制

            float rotationY = transform.localEulerAngles.y;//保持Y轴脚都一样

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);//新存储的旋转值
        }
        else
        {
            //both horizontal and vertical rotation
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
	}
}
