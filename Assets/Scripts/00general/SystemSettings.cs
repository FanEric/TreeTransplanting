using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SystemSettings : MonoBehaviour{
    Transform mTrans;

    private Button kSound;
    private Button kSoundMute;
    private Button kQuit;
    private Button kBack;

    private AudioSource kSource;

    // Use this for initialization
    public void Start () {
        DontDestroyOnLoad(this);

        mTrans = GameObject.Find("TopRightCanvas").transform;

        kSound = mTrans.FindChild("Button_music").GetComponent<Button>();
        kSoundMute = mTrans.FindChild("Button_music_mute").GetComponent<Button>();
        kQuit = mTrans.FindChild("Button_quit").GetComponent<Button>();
        kBack = mTrans.FindChild("Button_back").GetComponent<Button>();
		kSource = mTrans.FindChild("BgMusic").GetComponent<AudioSource>();

        kSound.onClick.AddListener(OnMuteOn);
        kSoundMute.onClick.AddListener(OnMuteOff);
        kQuit.onClick.AddListener(OnQuit);
        kBack.onClick.AddListener(OnBack);

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

