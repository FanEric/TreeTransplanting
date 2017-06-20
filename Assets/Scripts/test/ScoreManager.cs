using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    private static ScoreManager instance;

    private Text kScore;
	private Button kSubmit;

    void Start()
    {
		kScore = transform.FindChild("Image/Text_score").GetComponent<Text>();
		kSubmit = transform.FindChild("Image/Button_submit").GetComponent<Button>();
		kScore.text = GameInfo.gameScore.ToString();
		kSubmit.onClick.AddListener (OnSubmit);

		kSubmit.interactable = false;

		if (GameInfo.gameMode == GameMode.PRECTICE)
			kScore.transform.root.gameObject.SetActive(false);
    }

    public void UpdateScore(int point)
    {
        if (GameInfo.gameMode == GameMode.PRECTICE)
            kScore.transform.root.gameObject.SetActive(false);

		GameInfo.gameScore -= point;
		kScore.text = GameInfo.gameScore.ToString();
    }

	void OnSubmit()
	{
		
	}
}

