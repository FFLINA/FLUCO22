using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    enum Stage
    {
        StartRoom, Stage1, Stage2, Stage3, EndingRoom
    }
    Stage stage;

    public GameObject player;
    public GameObject[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        stage = Stage.StartRoom;
        player.transform.position = spawnPoints[(int)stage].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextStage()
    {
        // TODO : 스테이지 변경 시 암전 효과 필요
        stage++;
        player.transform.position = spawnPoints[(int)stage].transform.position;
    }

}
