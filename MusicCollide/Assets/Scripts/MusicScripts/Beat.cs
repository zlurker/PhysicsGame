using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Beat {
    public int beat;
    public float beatTime;
    public float beatDuration;

    public Beat(int b, float bt, float lb) {
        beat = b;
        beatTime = bt;
        beatDuration = lb;
    }
}
