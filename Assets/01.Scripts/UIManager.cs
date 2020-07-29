using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    //평소에는 [CameraRig]-Camera-Canvas-MenuGroup-Panel이 비활성화 되어있다가 이벤트(주로 충돌처리)가 발생하면
    //Panel을 활성화 시키고 해당 이벤트에 맞는 글자를 출력시킨다.

    public Text textNotification;
    public GameObject panel;

    public static UIManager Instance;

    private void Awake() {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start() {
        panel.SetActive(false);


    }

    // Update is called once per frame
    void Update() {

    }


    IEnumerator NotificationOnOff() {
        panel.SetActive(false);
        panel.SetActive(true);
        //true로 전환하면서 플레이어에게 사운드로 알려줄 필요가 있어보임
        yield return new WaitForSeconds(6.0f);
        panel.SetActive(false);
    }
    //게임 시작 후 알려줄 메시지
    internal void WakeUp1() {
        textNotification.text = "제 249호 실험체는 감염되었습니다. 완전히 감염되기까지 20분 남았습니다.";
        StartCoroutine("NotificationOnOff");
    }

    internal void WakeUp2() {
        textNotification.text = "실험실 내부에 바이러스가 퍼져 있습니다. 탈출하십시오.";
        StartCoroutine("NotificationOnOff");
    }


    internal void SylingeGrabed() {
        // 이 함수가 호출되면 UI의 텍스트가 바뀐다
    }


}