using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    // 현재 씬에 따라
    // 해당 씬의 퍼즐을 체크하고 조건 완료시 스테이지 클리어
    // 스테이지 클리어 시 다음 방으로 갈 수 있게 문이 열리고 이동 트리거 등장

    public static PuzzleManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    int sceneIndex;
    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        switch (sceneIndex)
        {
            case 0: // Intro
                break;

            case 1: // FirstRoom
                CheckFirstRoom();
                break;

            case 2: // SecondRoom
                CheckSecondRoom();
                break;

            case 3: // EndingRoom
                CheckEndingRoom();
                break;

            case 4: // Outro
                break;

            default:
                break;
        }
    }

    public bool sylingeGrabed;
    bool sylingeFirstGrab = true;
    public bool wakeUp1;
    public bool wakeUp2;

    /// <summary>
    /// 어두웠던 화면이 밝아지면서 게임 시작
    /// 게임시작 후 5초 후에 wakeUp 1 표시
    /// 
    /// </summary>
    /// 
    float startTime = 5f;
    float curTime;
    bool startFlag;
    private void CheckFirstRoom()
    {
        if (startFlag == false)
            curTime += Time.deltaTime;

        if (curTime >= startTime)
        {
            //UIManager.Instance.StartUIPopUp();
            curTime = 0;
            startFlag = true;
        }

        if (sylingeGrabed)
        {
            if (sylingeFirstGrab)
            {
                //UIManager.Instance.SylingeUIPopUp();
                sylingeFirstGrab = false;
            }
        }
    }
    internal bool room2_computerKeypadCheck;
    internal bool room2_doorKeypadCheck;

    public GameObject room2_Monitor;
    private void CheckSecondRoom()
    {
        // 두번째 방의 퍼즐을 계속 체크
        if (room2_computerKeypadCheck == true) {
            //computerKeypad에 답을 입력하면 음악파일이 있는 모니터 출력
            room2_Monitor.SetActive(true);
        }
        // 비밀번호 입력 및 화면 터치를 캔버스로?

    }

    private void CheckEndingRoom()
    {
        // 엔딩 방의 퍼즐을 계속 체크

    }
}
