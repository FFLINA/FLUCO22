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
    public bool wakeUp1;
    public bool wakeUp2;
    private void CheckFirstRoom() {
        // 첫번째 방의 퍼즐을 계속 체크
        // 현재 wakeUp을 체크하는게 따로 없으므로 Inspector에서 직접 체크하면서 테스트하였음.
        if (wakeUp1) {
            UIManager.Instance.WakeUp1();
            wakeUp1 = false;
        }
        if (wakeUp2) {
            UIManager.Instance.WakeUp2();
            wakeUp2 = false;
        }

        if (sylingeGrabed) {
            UIManager.Instance.SylingeGrabed();
        }

    }

    private void CheckSecondRoom()
    {
        // 두번째 방의 퍼즐을 계속 체크

    }

    private void CheckEndingRoom()
    {
        // 엔딩 방의 퍼즐을 계속 체크

    }
}
