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

    private void CheckFirstRoom()
    {
        // 첫번째 방의 퍼즐을 계속 체크
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
