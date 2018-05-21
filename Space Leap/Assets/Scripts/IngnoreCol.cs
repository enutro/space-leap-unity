using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngnoreCol : MonoBehaviour {
    public Transform bulletPrefab;
    // Use this for initialization
    void Start () {
        Physics2D.IgnoreLayerCollision(8, 12);

        Physics2D.IgnoreCollision(bulletPrefab.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), true);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
