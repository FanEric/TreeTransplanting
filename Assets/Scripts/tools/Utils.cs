using UnityEngine;
using System.Collections.Generic;
using SimpleJSON;

public class Utils : MonoBehaviour
{

    /// <summary>
    /// 从json中解析问题
    /// </summary>
    /// <returns></returns>
    public static List<QuestionEntity> ParseQuestions()
    {
        List<QuestionEntity> qes = new List<QuestionEntity>();
        TextAsset file = Resources.Load("QuestionCollections") as TextAsset;
        if (file == null)
        {
            Debug.LogError("QuestionCollections" + "资源不存在");
            return null;
        }

        JSONNode node = JSON.Parse(file.text);
        //Debug.Log("node.Count: " + node.Count);
        for (int i = 0; i < node.Count; i++)
        {
            QuestionEntity qe = new QuestionEntity();
            qe.questionId = node[i]["questionId"].AsInt;
            qe.questionName = node[i]["questionName"].AsString;
            qe.point = node[i]["point"].AsInt;
            qe.dubStr = node[i]["dubStr"].AsString;
            //Debug.Log("--qe: " + qe.questionId + " " + qe.questionName);

            JSONArray options = node[i]["options"].AsArray;
            qe.options = new List<OptionEntity>();
            for (int j = 0; j < options.Count; j++)
            {
                OptionEntity oe = new OptionEntity();
                oe.optionId = options[j]["optionId"].AsInt;
                oe.optionName = options[j]["optionName"].AsString;
                //Debug.Log("----oe: " + oe.optionId + " " + oe.optionName);
                qe.options.Add(oe);
            }

            JSONArray answers = node[i]["answers"].AsArray;
            qe.answers = new List<int>();
            for (int k = 0; k < answers.Count; k++)
            {
                //Debug.Log("----answer: " + answers[k]);
                qe.answers.Add(answers[k].AsInt);
            }
            qes.Add(qe);
        }
        return qes;
    }

}

