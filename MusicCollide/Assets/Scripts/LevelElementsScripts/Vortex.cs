using UnityEngine;
using System.Collections;

public class Vortex : MonoBehaviour {

    [System.Serializable]
    public struct Ball {
        public Transform ballT;
        public Rigidbody2D ballRb;
    }

    public Ball[] balls;
    

    void Start() {

    }

    void Update() {
        foreach (Ball obj in balls) {
            obj.ballT.position = new Vector3(obj.ballT.position.x + ((transform.position.x - obj.ballT.position.x) / 200), obj.ballT.position.y + ((transform.position.y - obj.ballT.position.y) / 200), transform.position.z);
            obj.ballRb.velocity = new Vector2(obj.ballRb.velocity.x - (obj.ballRb.velocity.x / 100), obj.ballRb.velocity.y - (obj.ballRb.velocity.y / 100));
        }
    }
}
