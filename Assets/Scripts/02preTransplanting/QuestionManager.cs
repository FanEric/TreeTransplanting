using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour {

    public QuestionModule questionModule;

    private GameObject kBeginObj;
    private int cQuestionId = 201;

    // Use this for initialization
    void Start () {
        if (GameInfo.gameMode == GameMode.PRACTICE)
        {
            SystemSettings ss = FindObjectOfType<SystemSettings>();
            if(ss) ss.ShowBackBtn();
        }
            
        kBeginObj = GameObject.Find("Image_begin");
        kBeginObj.GetComponentInChildren<Button>().onClick.AddListener(OnBegin);

        questionModule.Show(false);
        Utils.ParseQuestions();

    }
    void OnBegin()
    {
        questionModule.Init();
        questionModule.questionOverEvent += DoQuestionOver;
        kBeginObj.SetActive(false);
        questionModule.Show(true);
        questionModule.RequestQuestion(cQuestionId);
    }

    private void DoQuestionOver()
    {
        cQuestionId++;
        if (cQuestionId > 203)
        {
            SceneManager.LoadScene("03midTransplanting");
            return;
        }
        questionModule.RequestQuestion(cQuestionId);
    }

    void OnDestroy()
    {
        questionModule.questionOverEvent -= DoQuestionOver;
    }
}

