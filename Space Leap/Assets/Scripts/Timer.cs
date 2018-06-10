using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

        public int fps;
        public int counter;
        public float startTime;
        public static bool gameRunning;
    public Transform start;

	// Use this for initialization
	void Start () {
            fps = 60;
            counter = 0;
            startTime =3f;
        start.gameObject.SetActive(true);

        Timer.gameRunning = false;
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
                if (counter % (fps/2) == 0) {
                    startTime--;
                    if (startTime > 0.5) {
                start.gameObject.SetActive(false);

            }
            else if (startTime > 0 && startTime <0.5)
            {

                start.gameObject.SetActive(true);

            }
            else if (startTime < 0)
            {
                Timer.gameRunning = true;

                start.gameObject.SetActive(false);

            }
        }
	}
}
