using UnityEngine;
using System.Collections;

public class BlowMeAwayLevel : Level {

    public Collider2D boss;
    public Rigidbody2D bossR;

    public Collider2D[] beatZones;

    public override void PassBeatInfo(int noteNum) {
        if (boss.IsTouching(beatZones[noteNum])) {
            bossR.velocity = new Vector2(0, 0);
            bossR.AddForce(beatZones[noteNum].transform.TransformDirection(5,5,0),ForceMode2D.Impulse);
        }
    }
}
