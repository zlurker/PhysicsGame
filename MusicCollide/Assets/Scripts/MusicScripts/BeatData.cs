using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeatData : MonoBehaviour {

    public Transform[] spawnZone;
    public Transform endZone;
    public BeatScript[] arrows;

    public int currentBeat;
    public int beatToCheck;
    public float delayTime;

    public Level currentLevelScript;
    [SerializeField]
    public List<Beat> beats; //beats: 0 - leftup, 1 - leftdown, 2- rightup, 3- rightdown


    float offset;
    float currentTime;

    void Start() {
        currentBeat = 0;
        beatToCheck = 0;
        offset = Time.realtimeSinceStartup;
        currentLevelScript = GameObject.Find("GameController").GetComponent<Level>();
    }

    void Update() {
        currentTime = Time.realtimeSinceStartup - offset;

        if (currentBeat < beats.Count) {
            if (beats[currentBeat].beatTime - delayTime < currentTime) {
                Vector3 spawnLocation;

                if (beats[currentBeat].beat < 2)
                    spawnLocation = spawnZone[0].position;
                else 
                    spawnLocation = spawnZone[1].position;
                
                BeatScript instance = (BeatScript)Instantiate(arrows[beats[currentBeat].beat], spawnLocation, Quaternion.identity);
                instance.offset = offset;
                instance.beatEndTime = beats[currentBeat].beatTime;
                instance.startingTime = currentTime;
                instance.endingPoint = endZone;
                currentBeat++;
            }
        }
        if (beatToCheck < beats.Count) { 
            if (beats[beatToCheck].beatTime < currentTime) {
                if (currentLevelScript != null) {
                    
                    switch (beats[beatToCheck].beat) {
                        case 0:
                            currentLevelScript.PassBeatInfo(0);
                            break;
                        case 1:
                            currentLevelScript.PassBeatInfo(1);
                            break;
                        case 2:
                            currentLevelScript.PassBeatInfo(2);
                            break;
                        case 3:
                            currentLevelScript.PassBeatInfo(3);
                            break;
                    }
                    
                }
                
                beatToCheck++;
            }
            
        }
        //Debug.Log(inst.velocity);
    }
}
