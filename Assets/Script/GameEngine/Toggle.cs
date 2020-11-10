using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour {
    public GameObject TargetGameObject;
    

    public void toggle() {
        TargetGameObject.SetActive(!TargetGameObject.activeSelf);
    }

    public void toggle(GameObject GO) {
        gameObject.GetComponent<AudioSource>().Play();
        GO.SetActive(!GO.activeSelf);
    }
}
