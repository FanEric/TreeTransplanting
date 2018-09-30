using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public delegate void QuestionOverHandle();

public class QuestionModule : MonoBehaviour
{
	public Sprite kSmile;
	public Sprite kCry;
	public AudioClip kRight;
	public AudioClip kWrong;
    public ScoreManager scoreManager;
    public AudioManager audioManager;

    private Transform mTrans;
    private Text kQuestionName;
    private Toggle[] kOptions = new Toggle[6];
    private Button kSubmit;
    private Image kMotion;
	private AudioSource kSource;

    private List<int> correctAnswer = new List<int>();
    private int cPoint = 0;

    public event QuestionOverHandle questionOverEvent;

    public void Init()
    {
        mTrans = transform;
        
        kQuestionName = mTrans.Find("Text_questionName").GetComponent<Text>();
        kOptions = mTrans.Find("Options").GetComponentsInChildren<Toggle>();
        kSubmit = mTrans.Find("Button_ok").GetComponent<Button>();
        kSubmit.onClick.AddListener(OnSubmit);
        kMotion = mTrans.Find("Image_motion").GetComponent<Image>();
		kSource = GetComponent<AudioSource> ();

        ResetToggles();
        kMotion.gameObject.SetActive(false);
    }

    public void Show(bool toShow)
    {
        gameObject.SetActive(toShow);
    }

    public void RequestQuestion(int id)
    {
        QuestionEntity qe = Utils.GetQuestionById(id);
        if (qe == null)
        {
            Debug.LogError("问题id不存在！");
            return;
        }
        kQuestionName.text = qe.questionName;
        //Debug.Log("qe.dubStr: " + qe.dubStr);
        audioManager.PlayAudio(id, qe.dubStr);
        List<OptionEntity> randomOptions = GetRandomOptions(qe.options);
        int optionsCount = randomOptions.Count;
        for (int i = 0; i < kOptions.Length; i++)
        {
            if (i >= optionsCount)
            {
                kOptions[i].gameObject.SetActive(false);
                continue;
            }
            kOptions[i].transform.Find("Label_option").GetComponent<Text>().text = randomOptions[i].optionName;
            kOptions[i].transform.GetComponent<OptionState>().optionId = randomOptions[i].optionId;
        }
        correctAnswer = qe.answers;
        cPoint = qe.point;
    }

    void ResetToggles()
    {
        for (int i = 0; i < kOptions.Length; i++)
        {
            kOptions[i].gameObject.SetActive(true);
            kOptions[i].isOn = false;
        }
    }

    void OnSubmit()
    {
        //获取用户提交的选项
        List<int> userAnswer = new List<int>();
        for (int i = 0; i < kOptions.Length; i++)
        {
            Toggle tog = kOptions[i];
            if (tog.IsActive() && tog.isOn)
                userAnswer.Add(tog.transform.GetComponent<OptionState>().optionId);
        }

        //跟正确答案对比，判断对错
        if (CheckUserAnswer(userAnswer))
            StartCoroutine(DoAnswerRight());
        else
            DoAnswerWrong();
    }

    IEnumerator DoAnswerRight()
    {
		Debug.Log("正确");
        kSubmit.interactable = false;
        kSource.clip = kRight;
        kSource.Play();
        kMotion.gameObject.SetActive(true);
        kMotion.sprite = kSmile;
        kMotion.GetComponent<AutoHide>().Show();
        yield return new WaitForSeconds(0.5f);
        kMotion.gameObject.SetActive(false);
        kSubmit.interactable = true;

        ResetToggles();
        audioManager.Clear();

        if (questionOverEvent != null)
            questionOverEvent();
    }

    void DoAnswerWrong()
    {
        Debug.Log("错误");
        kSource.clip = kWrong;
		kSource.Play ();
		scoreManager.UpdateScore(cPoint);
        kMotion.gameObject.SetActive(true);
        kMotion.sprite = kCry;
        kMotion.GetComponent<AutoHide>().Show();
    }

    bool CheckUserAnswer(List<int> userAnswer)
    {
        userAnswer.Sort();
        if (correctAnswer.Count == userAnswer.Count)
        {
            for (int i = 0; i < correctAnswer.Count; i++)
            {
                if (correctAnswer[i] != userAnswer[i])
                    return false;
            }
            return true;
        }
        return false;
    }

    List<OptionEntity> GetRandomOptions(List<OptionEntity> input)
    {
        List<OptionEntity> output = new List<OptionEntity>();
        int end = input.Count;
        System.Random ran = new System.Random();
        for (int i = 0; i < input.Count; i++)
        {
            int index = ran.Next(end);
            output.Add(input[index]);
            input[index] = input[end - 1];
            end--;
        }
        return output;
    }

	
}

