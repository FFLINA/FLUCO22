using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour {

    //List<string> stringNumbers = new List<string>();
    //List<string> correctNumbers = new List<string>() { "1", "0", "1", "7" };

    public Text textMonitor;
    string correctNumbers;


    // Start is called before the first frame update
    void Start() {
        correctNumbers = "1017";
    }

    // Update is called once per frame
    void Update() {

    }
    internal void InputNumber(string childname) {
        switch (childname) {
            case "keypad_0":
                if (textMonitor.text.Length < 9) {
                    textMonitor.text += "0";
                }
                break;

            case "keypad_1":
                if (textMonitor.text.Length < 9) {
                    textMonitor.text += "1";
                }
                break;

            case "keypad_2":
                if (textMonitor.text.Length < 9) {
                    textMonitor.text += "2";
                }
                break;

            case "keypad_3":
                if (textMonitor.text.Length < 9) {
                    textMonitor.text += "3";
                }
                break;

            case "keypad_4":
                if (textMonitor.text.Length < 9) {
                    textMonitor.text += "4";
                }
                break;

            case "keypad_5":
                if (textMonitor.text.Length < 9) {
                    textMonitor.text += "5";
                }
                break;

            case "keypad_6":
                if (textMonitor.text.Length < 9) {
                    textMonitor.text += "6";
                }
                break;

            case "keypad_7":
                if (textMonitor.text.Length < 9) {
                    textMonitor.text += "7";
                }
                break;

            case "keypad_8":
                if (textMonitor.text.Length < 9) {
                    textMonitor.text += "8";
                }
                break;

            case "keypad_9":
                if (textMonitor.text.Length < 9) {
                    textMonitor.text += "9";
                }
                break;


            case "keypad_clear":
                //clear는 그냥 다 지우고
                //stringNumbers.Clear();
                textMonitor.text = "";
                break;

            case "keypad_enter":
                //enter는 정답과 값을 비교한다음
                if (textMonitor.text == correctNumbers) {
                    //정답이면 지우고 맞았다고 표시
                    textMonitor.text = "정답";
                }
                else {
                    //오답이면 지우고 틀렸다고 표시
                    textMonitor.text = "오답";
                }
                break;

            default:
                break;
        }


    }
}
