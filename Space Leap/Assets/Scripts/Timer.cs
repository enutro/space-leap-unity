using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

        public int fps;
        public int counter;
        public int startTime;
        public Text timer;
        public static bool gameRunning;

	// Use this for initialization
	void Start () {
            fps = 60;
            counter = 0;
            startTime = 3;
            timer.text = startTime.ToString();
            Timer.gameRunning = false;
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
                if (counter % (fps/2) == 0) {
                    startTime--;
                    if (startTime > 0) {
                        timer.text = startTime.ToString();
                    } else if (startTime == 0) {
                        timer.text = "GO!";
                    } else {
                        timer.text = "";
                        Timer.gameRunning = true;
                    }
                }
	}
}
