using UnityEngine;
using System.Collections;

public class LevelSelectionScreen : MonoBehaviour {

    [System.Serializable]
    public struct LevelDisplay {
        public Sprite sprite;
        public string name;
    }

    public LevelDisplay[] songs;
    public LevelDisplay[] physicsLevels;

	void Start () {

	}
	
	void Update () {
	
	}
}
