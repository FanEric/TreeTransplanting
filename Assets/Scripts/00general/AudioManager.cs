using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public Text kDubStr;

    public AudioClip ac201;
    public AudioClip ac202;
    public AudioClip ac203;
    public AudioClip ac301;
    public AudioClip ac302;
    public AudioClip ac303;
    public AudioClip ac304;
    public AudioClip ac305;
    public AudioClip ac306;

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
            case 3001:
                source.clip = ac301;
                break;
            case 3002:
                source.clip = ac302;
                break;
            case 3003:
                source.clip = ac303;
                break;
            case 3004:
                source.clip = ac304;
                break;
            case 3005:
                source.clip = ac305;
                break;
            case 3006:
                source.clip = ac306;
                break;
            default:
                source.clip = null;
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

