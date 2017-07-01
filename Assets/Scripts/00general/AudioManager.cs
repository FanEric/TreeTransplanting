using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public Text kDubStr;

    public AudioClip ac201;
    public AudioClip ac202;
    public AudioClip ac203;
    public AudioClip ac304;
    public AudioClip ac305;

    public AudioSource source;
    // Use this for initialization
    void Start () {
        if (GameInfo.gameMode == GameMode.TEST)
        {
            kDubStr.text = "";
            //gameObject.SetActive(false);
        }
    }

    public void PlayAudio(int qid, string dubStr)
    {
        if (GameInfo.gameMode == GameMode.TEST)
        {
            return;
        }
        if (source.isPlaying)
            source.Stop();
        switch (qid)
        {
            case 201:
                source.clip = ac201;
                break;
            case 202:
                source.clip = ac202;
                break;
            case 203:
                source.clip = ac203;
                break;
            case 304:
                source.clip = ac304;
                break;
            case 305:
                source.clip = ac305;
                break;
            default:
                break;
        }
        source.Play();
        kDubStr.text = dubStr;
    }

    public void Clear()
    {
        kDubStr.text = "";
        source.clip = null;
    }
}

