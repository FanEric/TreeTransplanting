using UnityEngine;
using System.Collections;

public class FDebug : MonoBehaviour {
    public bool isDebug = false;
    public GameObject[] kTarget1;
    public GameObject[] kTarget2;

    private void Awake()
    {
        for (int i = 0; i < kTarget1.Length; i++)
            kTarget1[i].SetActive(!isDebug);

        for (int i = 0; i < kTarget2.Length; i++)
            kTarget2[i].SetActive(isDebug);
    }
}
