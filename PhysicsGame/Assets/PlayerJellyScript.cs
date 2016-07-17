using UnityEngine;
using System.Collections;

public class PlayerJellyScript : MonoBehaviour {

    Transform[] hooks;

    Transform selectedHook;
    Ray ray;

    bool playerSelected;
    void Start() {


    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (RaycastCheck().root == transform) {
                playerSelected = true;
            }
        }

        if (Input.GetMouseButton(0)) {
            if (!selectedHook) {
                if (RaycastCheck().parent == transform) {
                    selectedHook = RaycastCheck();
                }
            } else {
                selectedHook.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            if (playerSelected) {
                if (RaycastCheck() != null && RaycastCheck().root != transform) {
                    Transform hooked = RaycastCheck();
                    Debug.Log("Hook can attach to place");
                }
                playerSelected = false;
            }
        }
    }

    public void DetachHooks() {

    }

    Transform RaycastCheck() {
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 20)) {
            return hit.transform;
        }
        return null;
    }
}
