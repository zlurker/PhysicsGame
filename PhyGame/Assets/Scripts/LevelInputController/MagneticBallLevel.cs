using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class MagneticBallLevel : Level {

    Rigidbody2D instance;

    public override void PassBeatInfo(int noteNum) {
        if (instance) {
            instance.velocity = new Vector2(0, 0);
            switch (noteNum) {
                case 0:
                    instance.AddForce(new Vector2(-5f, 5f), ForceMode2D.Impulse);
                    break;
                case 1:
                    instance.AddForce(new Vector2(-5f, -5f), ForceMode2D.Impulse);
                    break;
                case 2:
                    instance.AddForce(new Vector2(5f, 5f), ForceMode2D.Impulse);
                    break;
                case 3:
                    instance.AddForce(new Vector2(5f, -5f), ForceMode2D.Impulse);
                    break;
            }
        }
    }

    public void BallSelected(Rigidbody2D clickedOn) {
        instance = clickedOn;
    }

    public void ChangeColour(Image clickedOn) {
        clickedOn.color = Color.black;
    }

    public void Uncolor(Image clickedOn) {
        clickedOn.color = Color.clear;
    }
}
