using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

        public int fps;
        public int counter;
        public float startTime;
    public float fadeTime;
    public static bool gameRunning;
        public GameObject instruction;
	// Use this for initialization
	void Start () {
        fps = 60;
            counter = 0;
            startTime =3f;
        fadeTime = 24f;
        Timer.gameRunning = false;
	}
	
	// Update is called once per frame
	void Update () {

            counter++;

        var trans = 0.5f;
        var col = instruction.GetComponent<Renderer>().material.color;
        instruction.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, fadeTime/ 24f);

        if (counter % (fps / 2) == 0)
        {
            startTime--;
        }

        if (counter % (fps / 16) == 0)
        {
            fadeTime--;
        }

        if (startTime < 0)
        {
            Timer.gameRunning = true;


        }
        
	}
}
