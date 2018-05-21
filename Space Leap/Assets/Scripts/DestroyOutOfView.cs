using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfView : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter(Collision col)
    {
        Destroy(col.gameObject);

        print(col.gameObject.name + " -------> test");

    }
}