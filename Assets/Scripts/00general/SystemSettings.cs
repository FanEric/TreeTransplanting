using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class SystemSettings : MonoBehaviour{
    Transform mTrans;

    public GameObject kMovieContainer;
    public VideoPlayer kMovie;

    private Button kSound;
    private Button kSoundMute;
    private Button kQuit;
    private Button kBack;
    private Button kVideo;

    private AudioSource kSource;

    // Use this for initialization
    public void Start () {
        DontDestroyOnLoad(this);

        mTrans = GameObject.Find("TopRightCanvas").transform;

        kSound = mTrans.Find("Button_music").GetComponent<Button>();
        kSoundMute = mTrans.Find("Button_music_mute").GetComponent<Button>();
        kQuit = mTrans.Find("Button_quit").GetComponent<Button>();
        kBack = mTrans.Find("Button_back").GetComponent<Button>();
        kVideo = mTrans.Find("Button_video").GetComponent<Button>();
        kSource = mTrans.Find("BgMusic").GetComponent<AudioSource>();

        kSound.onClick.AddListener(OnMuteOn);
        kSoundMute.onClick.AddListener(OnMuteOff);
        kQuit.onClick.AddListener(OnQuit);
        kBack.onClick.AddListener(OnBack);
        kVideo.onClick.AddListener(OnPlayVideo);

        kBack.gameObject.SetActive(false);
        OnMuteOff();
    }

    void OnMuteOn()
    {
        kSound.gameObject.SetActive(false);
        kSoundMute.gameObject.SetActive(true);
        kSource.mute = true;
    }

    void OnMuteOff()
    {
        kSoundMute.gameObject.SetActive(false);
        kSound.gameObject.SetActive(true);
        kSource.mute = false;
    }

    void OnPlayVideo()
    {
        if (kMovie.isPlaying)
        {
            kMovie.Stop();
            kMovieContainer.SetActive(false);

            OnMuteOff();
        }
        else
        {
            kMovieContainer.SetActive(true);
            kMovie.Play();

            OnMuteOn();
        }
    }


    void OnQuit()
    {
        Application.Quit();
    }

    void OnBack()
    {
        GameInfo.Reset ();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void ShowBackBtn()
    {
        kBack.gameObject.SetActive(true);
    }
}

