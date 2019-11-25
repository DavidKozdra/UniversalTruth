using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour {

    public void T(GameObject GO) {
        GO.SetActive(!GO.activeSelf);
    }
}
