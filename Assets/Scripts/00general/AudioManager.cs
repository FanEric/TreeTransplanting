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
    public AudioClip ac307;
    public AudioClip ac308;
    public AudioClip ac309;
    public AudioClip ac310;
    public AudioClip ac311;
    public AudioClip ac312;
    public AudioClip ac313;
    public AudioClip ac314;
    public AudioClip ac315;
    public AudioClip ac316;
    public AudioClip ac317;
    public AudioClip ac318;
    public AudioClip ac3182;
    public AudioClip ac319;
    public AudioClip ac320;
    public AudioClip ac321;
    public AudioClip ac322;
    public AudioClip ac323;

    public AudioSource source;
    // Use this for initialization
    void Start () {
        if (GameInfo.gameMode == GameMode.TEST)
        {
            kDubStr.text = "";
        }
    }

    public void PlayAudio(int qid, string dubStr)
    {
        if (GameInfo.gameMode == GameMode.TEST)
            return;
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
            case 3007:
                source.clip = ac307;
                break;
            case 3008:
                source.clip = ac308;
                break;
            case 3009:
                source.clip = ac309;
                break;
            case 3010:
                source.clip = ac310;
                break;
            case 3011:
                source.clip = ac311;
                break;
            case 3012:
                source.clip = ac312;
                break;
            case 3013:
                source.clip = ac313;
                break;
            case 3014:
                source.clip = ac314;
                break;
            case 3015:
                source.clip = ac315;
                break;
            case 3016:
                source.clip = ac316;
                break;
            case 3017:
                source.clip = ac317;
                break;
            case 3018:
                source.clip = ac318;
                break;
            case 30182:
                source.clip = ac3182;
                break;
            case 3019:
                source.clip = ac319;
                break;
            case 3020:
                source.clip = ac320;
                break;
            case 3021:
                source.clip = ac321;
                break;
            case 3022:
                source.clip = ac322;
                break;
            case 3023:
                source.clip = ac323;
                break;
            default:
                source.clip = null;
                break;
        }
        if(source.clip != null)
            source.Play();
        kDubStr.text = dubStr;
    }

    public void Clear()
    {
        kDubStr.text = "";
        source.clip = null;
    }
}

