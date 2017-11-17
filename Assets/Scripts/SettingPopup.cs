using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : MonoBehaviour {

    [SerializeField] private Slider slider;

    public void Open()
    {
        gameObject.SetActive(true);//开启对象，打开窗口
    }

    public void Close()
    {
        gameObject.SetActive(false);//对象无效化，关闭窗口
    }

    //在用户输入时调用方法
    public void OnSubmitName(string name)
    {
        Debug.Log(name);
    }

    //调整滑动条时触发
    public void OnSpeedValue(float speed)
    {
        //这个速度一直是0，只能换了个方法，天呐，求解释
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, slider.value);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
