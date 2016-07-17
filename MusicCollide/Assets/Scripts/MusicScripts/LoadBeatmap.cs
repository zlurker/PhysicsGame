using UnityEngine;
using System.Collections;

public class LoadBeatmap : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Instantiate(DataBetweenLevels.beatmapToLoad,Vector3.zero,Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
