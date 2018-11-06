using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class howFarUfo : MonoBehaviour
{
    public Texture2D[] numbers;



    public Transform player;
    public Transform ufo;
    public int howFar;

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
                    GUI.DrawTexture(new Rect(i * 60+ 760+(ufo.transform.position.x*420)- offset, 1750, 50, 50), numbers[a]);
                }
            }

     

    }
     
    
}
