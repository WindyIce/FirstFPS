﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour {

    private new Camera camera;
	// Use this for initialization
	void Start () {
        //访问相同对象上附加的其他组件
        camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        //响应鼠标按键
        if (Input.GetMouseButtonDown(0)&&!EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 point = new Vector3(camera.pixelWidth/2,camera.pixelHeight/2,0);//屏幕中心
            Ray ray = camera.ScreenPointToRay(point);//在摄像机所在位置创建射线
            RaycastHit hit;//射线交叉信息的包装
            //Raycast给引用的变量填充信息
            if(Physics.Raycast(ray,out hit))   //out确保在函数内外是同一个变量
            {
                //hit.point:射线击中的坐标
                GameObject hitObject = hit.transform.gameObject;//获取射中的对象
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)   //检查对象上是否有ReactiveTarget组件
                {
                    target.ReactToHit();
                    Messenger.Broadcast(GameEvent.ENEMY_HIT);
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));//响应击中
                }

            }
        }
	}

    //onGUI在每帧被渲染之后执行
    private void OnGUI()
    {
        int size = 12;
        float posX = camera.pixelWidth / 2 - size / 4;
        float posY = camera.pixelHeight / 2 - size / 4;
        GUI.Label(new Rect(posX,posY,size,size),"*");
    }

    //协程，随着时间推移逐步执行
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);   //yield：协程在何处暂停

        Destroy(sphere);   //移除GameObject并释放占用的内存
    }
}
