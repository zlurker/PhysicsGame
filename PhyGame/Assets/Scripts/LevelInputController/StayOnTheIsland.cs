using UnityEngine;
using System.Collections;

public class StayOnTheIsland : Level {

    public Rigidbody2D instance;
    public int currentPlayerZone;

    public Collider2D axis;
    public Transform player;
    public Collider2D playerC;
    public Collider2D[] beatZones;

    void Start() {

    }

    void Update() {        
        player.position = axis.bounds.center + axis.transform.TransformDirection(0, axis.bounds.extents.y, 0);        
    }

    public override void PassBeatInfo(int noteNum) {
        if (playerC.IsTouching(beatZones[noteNum])) {
            axis.transform.localScale = new Vector3(axis.transform.localScale.x + 0.1f, axis.transform.localScale.y + 0.1f, axis.transform.localScale.z);
        }
    }
}
