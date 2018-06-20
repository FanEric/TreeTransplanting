using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private static ScoreManager instance;

    public GameObject kFinalTipTest;
    public GameObject kFinalTipExam;
    public Text kFinalScore;
    public Text kScore;
    public Button kSubmit;

    void Start()
    {
		kScore.text = GameInfo.gameScore.ToString();
		kSubmit.onClick.AddListener (OnExamModeOver);

		kSubmit.interactable = false;

        if (GameInfo.gameMode == GameMode.PRACTICE)
            kSubmit.gameObject.SetActive(false);
    }

    public void UpdateScore(int point)
    {
		GameInfo.gameScore -= point;
		kScore.text = GameInfo.gameScore.ToString();
    }

    void OnTestModeOver()
    {
        kFinalTipTest.SetActive(true);
    }

    void OnExamModeOver()
    {
        kFinalScore.text = GameInfo.gameScore.ToString();
        kFinalTipExam.SetActive(true);
    }

    public void OnOK()
    {
        GameInfo.gameScore = 0;
        SceneManager.LoadScene(0);
        GameObject obj = GameObject.Find("TopRightCanvas");
        if (obj != null)
            Destroy(obj);
    }

    public void OnGameOver()
    {
        if (GameInfo.gameMode == GameMode.PRACTICE)
            OnTestModeOver();
        else
            kSubmit.interactable = true;
    }


}

