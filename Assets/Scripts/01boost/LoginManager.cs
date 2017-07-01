using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoginManager : MonoBehaviour {

    Transform mTrans;

    private InputField kUsername;
    private InputField kUserclass;
    private GameObject kNameHint;
    private GameObject kClassHint;
    private Button kPractice;
    private Button kTest;
    private Button kQuit;
	// Use this for initialization
	void Start () {
        mTrans = transform.FindChild("Panel");

        kUsername = mTrans.FindChild("InputField_name").GetComponent<InputField>();
        kUserclass = mTrans.FindChild("InputField_class").GetComponent<InputField>();
        kNameHint = mTrans.FindChild("InputField_name/Text_hint").gameObject;
        kClassHint = mTrans.FindChild("InputField_class/Text_hint").gameObject;
        kPractice = mTrans.FindChild("Button_practice").GetComponent<Button>();
        kTest = mTrans.FindChild("Button_test").GetComponent<Button>();
        //kQuit = mTrans.FindChild("Button_quit").GetComponent<Button>();

        kUsername.onValueChanged.AddListener(HideNameHintOnChange);
        kUserclass.onValueChanged.AddListener(HideClassHintOnChange);
        kPractice.onClick.AddListener(OnPractice);
        kTest.onClick.AddListener(OnTest);
        //kQuit.onClick.AddListener(OnQuit);

        kNameHint.SetActive(false);
        kClassHint.SetActive(false);
    }

    void HideNameHintOnChange(string str)
    {
        if (kNameHint.activeSelf)
            kNameHint.SetActive(false);
    }

    void HideClassHintOnChange(string str)
    {
        if (kClassHint.activeSelf)
            kClassHint.SetActive(false);
    }

    bool CheckEmpty()
    {
        if (string.IsNullOrEmpty(kUsername.text))
        {
            kNameHint.SetActive(true);
            return true;
        }
        if (string.IsNullOrEmpty(kUserclass.text))
        {
            kClassHint.SetActive(true);
            return true;
        }
        return false;
    }

    void OnPractice()
    {
        if (!CheckEmpty())
        {
            GameInfo.gameMode = GameMode.PRECTICE;
            SceneManager.LoadScene("02preTransplanting");
        }
    }

    void OnTest()
    {
        if (!CheckEmpty())
        {
            GameInfo.gameMode = GameMode.TEST;
            SceneManager.LoadScene("02preTransplanting");
        }
    }

    void OnQuit()
    {
        Application.Quit();
    }
}

