using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class TransitionManager : MonoBehaviour {
    private Image kTransition;

    private Button kBegin;

    public GameObject kTarget;

    //IEnumerator Start()
    //{
    //    kTarget.SetActive(false);
    //    kTransition = GetComponent<Image>();
    //    kTransition.DOColor(new Color(1, 1, 1, 1), 0.3f);
    //    yield return new WaitForSeconds(2.3f);
    //    kTransition.DOColor(new Color(1, 1, 1, 0), 0.3f);
    //    yield return new WaitForSeconds(0.3f);

    //    kTarget.SetActive(true);
    //}

    void Start()
    {
        kBegin = GameObject.Find("Button_begin").GetComponent<Button>();
        kBegin.onClick.AddListener(OnBegin);
        if (kTarget != null)
        {
            kTarget.GetComponent<GameControl>().GameInit();
            kTarget.SetActive(false);
        }
    }

    void OnBegin()
    {
        gameObject.SetActive(false);
        if (kTarget != null)
        {
            kTarget.SetActive(true);
            kTarget.GetComponent<GameControl>().GameBegin();
        }
    }
}

