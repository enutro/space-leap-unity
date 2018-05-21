using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public Animator m_Animator;
    //Value from the slider, and it converts to speed level
    float m_MySliderValue;

    void Start()
    {
        //Get the animator, attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }

    void OnGUI()
    {

        m_Animator.speed = 2f;
    }
}