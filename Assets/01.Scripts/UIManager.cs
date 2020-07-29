using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    /// <summary>
    /// FirstRoom
    /// 게임 시작시, PuzzleManager가 UIManager의 StartUIPopUp() 실행
    /// - 게임 도중 주사기를 집으면 PuzzleManager가 UIManager의 SylingeUIPopUp() 실행
    /// - 
    /// </summary>

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

    // ----------------- First Puzzle Room --------------------
    public void StartUIPopUp()
    {
        StartCoroutine("StartUI");
    }

    public void SylingeUIPopUp()
    {
        StartCoroutine("SylingeUI");
    }

    IEnumerator StartUI() 
    {
        panel.SetActive(false);
        panel.SetActive(true);

        textNotification.text = "제 249호 실험체는 감염되었습니다.\n완전히 감염되기까지 20분 남았습니다.";
        textNotification.enabled = false;
        yield return new WaitForSeconds(0.2f);
        textNotification.enabled = true;
        yield return new WaitForSeconds(0.2f);
        textNotification.enabled = false;
        yield return new WaitForSeconds(0.2f);
        textNotification.enabled = true;
        yield return new WaitForSeconds(6.0f);

        textNotification.text = "실험실 내부에 바이러스가 퍼져 있습니다.\n실험실을 탈출하십시오.";
        textNotification.enabled = false;
        yield return new WaitForSeconds(0.2f);
        textNotification.enabled = true;
        yield return new WaitForSeconds(0.2f);
        textNotification.enabled = false;
        yield return new WaitForSeconds(0.2f);
        textNotification.enabled = true;
        yield return new WaitForSeconds(6.0f);

        panel.SetActive(false);
    }

    IEnumerator SylingeUI()
    {
        panel.SetActive(true);
        textNotification.text = "방 안에 남아있는 생명체를 찾으십시오.";
        textNotification.enabled = false;
        yield return new WaitForSeconds(0.2f);
        textNotification.enabled = true;
        yield return new WaitForSeconds(0.2f);
        textNotification.enabled = false;
        yield return new WaitForSeconds(0.2f);
        textNotification.enabled = true;
        yield return new WaitForSeconds(6.0f);

        panel.SetActive(false);
    }
}