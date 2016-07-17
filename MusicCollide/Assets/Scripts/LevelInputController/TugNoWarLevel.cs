using UnityEngine;
using System.Collections;

public class TugNoWarLevel : Level {

    public Rigidbody2D tugOfWar;
    public float force;
    public float forceMultiplier;

    void Update() {
        tugOfWar.velocity = new Vector2(tugOfWar.velocity.x - (tugOfWar.velocity.x / 50), tugOfWar.velocity.y - (tugOfWar.velocity.y / 50));
    }

    public override void PassBeatInfo(int noteNum) {

        float temp = force * forceMultiplier;
        tugOfWar.velocity = new Vector2(0, 0);

        switch (noteNum) {
            case 2: //push left
            case 3:
                tugOfWar.AddForce(new Vector2(temp,0));
                break;
            case 1: //push right
            case 0:
                tugOfWar.AddForce(new Vector2(-temp, 0));
                break;
        }
    }

    public void ChangeForceMultiplier(float change) {
        forceMultiplier = change;
    }
}
