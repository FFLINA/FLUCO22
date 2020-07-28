using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_PuzzleTrigger : MonoBehaviour
{
    string answer;
    // Start is called before the first frame update
    void Start()
    {
        switch (gameObject.name)
        {
            case "Stage 1 Trigger_Red":
                answer = "Stage 1 Item_Red";
                break;

            case "Stage 1 Trigger_Green":
                answer = "Stage 1 Item_Green";
                break;
        }

    }


    // Update is called once per frame
    void Update()
    {

    }

    string itemName;
    private void OnTriggerEnter(Collider item)
    {
        itemName = item.gameObject.name;
        if (itemName == answer)
        {
            Invoke("Stage1_SetTrigger", 2f);
        }
    }

    private void OnTriggerExit(Collider item)
    {
        if (itemName == answer)
        {
            CancelInvoke("Stage1_SetTrigger");
            //PuzzleManager.Instance.StageOneOffTrigger();
        }
    }

    void Stage1_SetTrigger()
    {
        //PuzzleManager.Instance.StageOneOnTrigger();
    }
}
