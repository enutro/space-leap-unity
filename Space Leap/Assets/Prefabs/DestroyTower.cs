using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DestroyTower : MonoBehaviour {
    public GameObject player;

    // Use this for initialization
    void Start () {
		player= GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y < player.transform.position.y-6f)
        {
            Destroy(gameObject);
            Destroy(this);

        }
    }


}
