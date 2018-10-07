using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendoToweroonie : MonoBehaviour
{
    public Animator animator;
    Transform initialTower;
    public Transform tower;
    public Transform player;
    private float maxTime = 1f;
    private float distanceBetweenTower = 0.89f;
    public int numOfTowers = -1;
    public bool animEnded = false;
    public bool triggered = false;
    public float myTime;
    void Start()
    {
        initialTower = Object.Instantiate(tower, new Vector3(0, -0.49f + (numOfTowers * distanceBetweenTower), 20), transform.rotation);
        numOfTowers++;
    }
    void Update()
    {

        AnimatorStateInfo animationState = initialTower.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        float myTime = animationState.normalizedTime;

        if (myTime > maxTime && maxTime != 5)
        {
            maxTime++;
            Object.Instantiate(tower, new Vector3(0, -0.49f + (numOfTowers * distanceBetweenTower), 20), transform.rotation);
            numOfTowers++;
        }
       
            if (player.position.y > (numOfTowers * distanceBetweenTower) - (distanceBetweenTower * 3) && maxTime>=5)
            {
                Object.Instantiate(tower, new Vector3(0, -0.49f + (numOfTowers * distanceBetweenTower), 20), transform.rotation);
                numOfTowers++;
            }
            //Look for player position. NO animation. Kill off any old towers. 


        
    }
}