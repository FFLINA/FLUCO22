using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 게임매니저
    // 이전, 다음 씬으로 넘기는 기능

    // ---------- 구현 가능성 있는지 알아봐야함-----------
    // 세이브
    // 현재 씬의 Item 오브젝트들의 Position, Rotation, Scale, 상태(파괴 등)를 저장 (예정)
    // 로드
    // 넘어갈 씬의 저장된 데이터를 읽고 그대로 로드 (예정)


    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveStage(int index)
    {
        // TODO : 현재 스테이지의 상태를 세이브

    }

    public void LoadStage(int index)
    {
        // TODO : 바꿀 스테이지의 상태를 로드


    }

    public void StageChange(int sceneIndex)
    {
        int curIndex = SceneManager.GetActiveScene().buildIndex;
        SaveStage(curIndex);

        LoadStage(sceneIndex);
    }
}
