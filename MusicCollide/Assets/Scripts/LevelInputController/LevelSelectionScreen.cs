using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionScreen : MonoBehaviour {

    [System.Serializable]
    public struct LevelDisplay {
        public Sprite sprite;
        public string name;
        public BeatData beatMap;
    }

    public LevelDisplay[] songs;
    public LevelDisplay[] physicsLevels;

    public Image songImage;
    public Image physicsImage;

    int currentMusic;
    int currentPhysicsGame;

    public void NavigateMusicLevels(int value) {
        if (currentMusic+value > -1 && currentMusic+value <songs.Length)
        currentMusic += value;

        songImage.sprite = songs[currentMusic].sprite;
        DataBetweenLevels.beatmapToLoad = songs[currentMusic].beatMap;
        Debug.Log(DataBetweenLevels.beatmapToLoad);
    }

    public void NavigatePhysicsLevels(int value) {
        if (currentPhysicsGame + value > -1 && currentPhysicsGame + value < physicsLevels.Length)
            currentPhysicsGame += value;
        Debug.Log(DataBetweenLevels.beatmapToLoad);
        physicsImage.sprite = physicsLevels[currentPhysicsGame].sprite;        
    }

    public void LoadLevel() {
        SceneManager.LoadScene(physicsLevels[currentPhysicsGame].name);
    }
}
