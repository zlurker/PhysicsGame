using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeatMapCreator : MonoBehaviour {

    public BeatData beatmap;

    float offset;
    float currentTime;
    float holdingDownTimer;

	void Start () {
        offset = Time.realtimeSinceStartup;
        beatmap.beats = new List<Beat>();
	}
	
	void Update () {
        currentTime = Time.realtimeSinceStartup - offset;
        if (Input.GetKeyDown("left")) {
            beatmap.beats.Add(new Beat(0, currentTime, 0));
        }

        if (Input.GetKeyDown("down")) {
            beatmap.beats.Add(new Beat(1, currentTime, 0));
        }

        if (Input.GetKeyDown("up")) {
            beatmap.beats.Add(new Beat(2, currentTime, 0));
        }  

        if (Input.GetKeyDown("right")) {
            beatmap.beats.Add(new Beat(3, currentTime, 0));
        }        
    }
}
