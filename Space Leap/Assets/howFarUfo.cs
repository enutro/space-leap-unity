using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class howFarUfo : MonoBehaviour
{
    public Texture2D[] numbers;



    public Transform player;
    public Transform ufo;
    public int howFar;
    public Camera cam;

    TextMesh text;
    public float ypos;
    public float hideOffset = 1000;
    void Start()
    {

    }

    void Update()
    {
       howFar = Mathf.RoundToInt((player.transform.position.y - ufo.transform.position.y)*3)-6;

    }

    // Update is called once per frame
    void OnGUI()
    {
        int offset;
        int numOfDigits = howFar.ToString().Length;
        if (howFar < 10)
        {
            offset = 0;
        }
        else if (howFar >= 10 && howFar < 100)
        {
            offset = 32;

        }
        else
        {
            offset = 64;

        }
        for (int i = 0; i < numOfDigits; i++)
            {
                int a;
                if (i == 0)
                {
                    a = (howFar / (int)Mathf.Pow(10, numOfDigits - 1));


                }
                else
                {
                    a = (howFar % (int)Mathf.Pow(10, numOfDigits - i) / (int)Mathf.Pow(10, numOfDigits - i - 1));
                }
                if (a < numbers.Length  && a >= 0)
                {
                Vector3 screenPos = cam.WorldToScreenPoint(ufo.transform.position);


                GUI.DrawTexture(new Rect(i * ((Screen.width / 15.5f)) + screenPos.x + (Screen.width / 5.5f), Screen.height/1.11f, ((Screen.width / 16)), ((Screen.width / 16))), numbers[a]);
                }
            }

     

    }
     
    
}
