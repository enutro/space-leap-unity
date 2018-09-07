using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendoToweroonie : MonoBehaviour
{
    public Animator animator;
    public Transform tower;
    public Transform player;
    private float maxTime=1f;
    private float distanceBetweenTower = 0.89f;
    public int numOfTowers = 0;
    public bool animEnded = false;
    public bool triggered = false;

    public float yolo;
    void Start()
    {
    }
    void Update()
    {
        

                AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorClipInfo[] myAnimatorClip = animator.GetCurrentAnimatorClipInfo(0);
        float myTime =  animationState.normalizedTime;
        yolo = myTime;

            if (myTime > maxTime && maxTime!=6)
        {
            maxTime++;
            Object.Instantiate(tower, new Vector3(0, -0.49f + (numOfTowers* distanceBetweenTower), 0), transform.rotation);
            numOfTowers++;
        }

    }
}