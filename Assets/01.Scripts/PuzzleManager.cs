using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    Vector3 stageOneDoorUpPosition;
    Vector3 stageTwoDoorUpPosition;
    bool stageOneClear = false;
    bool stageTwoClear = false;
    public GameObject stageOneDoor;
    public GameObject stageTwoDoor;

    //cuttingImage의 자식이 없으면 퍼즐이 완료된걸로 판단
    public GameObject cuttingImage;

    // Start is called before the first frame update
    void Start()
    {
        stageOneDoorUpPosition = stageOneDoor.transform.position + (Vector3.up * 5f);
        stageTwoDoorUpPosition = stageTwoDoor.transform.position + (Vector3.up * 5f);

    }
    // Update is called once per frame
    void Update()
    {
        if(stageOneClear)
        {
            stageOneDoor.transform.position = Vector3.Lerp(stageOneDoor.transform.position, stageOneDoorUpPosition, Time.deltaTime * 0.5f);
        }

        //GetComponentsInChildren에 본인도 포함되기때문에 Length가 1인가로 체크
        if (cuttingImage.GetComponentsInChildren<Transform>().Length == 1)
        {
            //문 여는거 들어가면됨
            stageTwoDoor.transform.position = Vector3.Lerp(stageTwoDoor.transform.position, stageTwoDoorUpPosition, Time.deltaTime * 0.5f);
        }

        //if (stageTwoClear)
        {

            
        }
    }
    int stageOneSolveCount = 2;
    int stageOneCount;


    internal void StageOneOnTrigger()
    {
        stageOneCount++;
        if (stageOneSolveCount == stageOneCount)
        {
            stageOneClear = true;
        }
    }


    internal void StageOneOffTrigger()
    {
        stageOneCount--;
        if (stageOneCount < 0)
            stageOneCount = 0;
    }
}
