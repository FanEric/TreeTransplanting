using UnityEngine;
using System.Collections.Generic;

public class QuestionEntity {

    public int questionId { get; set; }

    public string questionName { get; set; }

    public List<OptionEntity> options { get; set; }

    public List<int> answers { get; set; }

    public int point { get; set; }

    public string dubStr { get; set; }
}

