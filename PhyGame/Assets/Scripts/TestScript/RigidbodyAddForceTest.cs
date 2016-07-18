using UnityEngine;
using System.Collections;

public class RigidbodyAddForceTest : MonoBehaviour {

    Rigidbody2D inst;
	// Use this for initialization
	void Start () {
        inst = GetComponent<Rigidbody2D>();
        //inst.AddForce(new Vector2(10, 10), ForceMode2D.Impulse);
        InvokeRepeating("Test", 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update () {
        
    }

    void Test() {
        inst.AddForce(new Vector2(10, 10), ForceMode2D.Impulse);
    }
}
