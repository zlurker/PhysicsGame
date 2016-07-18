using UnityEngine;
using System.Collections;

public class StayAfloatLevel : Level {

    public Rigidbody2D player;
    public Collider2D[] beatZones;

    public override void PassBeatInfo(int noteNum) {
        player.velocity = new Vector2(0, 0);
        player.AddForce(beatZones[noteNum].transform.TransformDirection(5, 5, 0), ForceMode2D.Impulse);
    }
}
