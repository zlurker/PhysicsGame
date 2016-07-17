using UnityEngine;
using System.Collections;

public class SeeSawLevel : Level {
    public Rigidbody2D seeSaw;

    public float force;
    public float forceMultiplier;

    public override void PassBeatInfo(int noteNum) {
        seeSaw.angularVelocity = 0;
        float temp = force * forceMultiplier;
        switch (noteNum) {
            case 3: 
            case 1:
                //seeSaw.eulerAngles = new Vector3(0, 0, seeSaw.eulerAngles.z - temp);
                seeSaw.AddTorque(temp, ForceMode2D.Impulse);
                break;
            case 2: 
            case 0:
                //seeSaw.eulerAngles = new Vector3(0, 0, seeSaw.eulerAngles.z + temp);
                seeSaw.AddTorque(-temp, ForceMode2D.Impulse);
                break;
        }
    }
    public void ChangeForceMultiplier(float change) {
        forceMultiplier = change;
    }

}
