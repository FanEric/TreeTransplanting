using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        mTrans = transform.Find("Panel");

        kUsername = mTrans.Find("InputField_name").GetComponent<InputField>();
        kUserclass = mTrans.Find("InputField_class").GetComponent<InputField>();
        kNameHint = mTrans.Find("InputField_name/Text_hint").gameObject;
        kClassHint = mTrans.Find("InputField_class/Text_hint").gameObject;
        kPractice = mTrans.Find("Button_practice").GetComponent<Button>();
        kTest = mTrans.Find("Button_test").GetComponent<Button>();

        kUsername.onValueChanged.AddListener(HideNameHintOnChange);
        kUserclass.onValueChanged.AddListener(HideClassHintOnChange);
        kPractice.onClick.AddListener(OnPractice);
        kTest.onClick.AddListener(OnTest);

        kNameHint.SetActive(false);
        kClassHint.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        Utils.ClearQes();
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
            GameInfo.gameMode = GameMode.PRACTICE;
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

