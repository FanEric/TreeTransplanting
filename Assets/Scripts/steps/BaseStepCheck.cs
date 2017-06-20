using UnityEngine;
using System.Collections;

public class BaseStepCheck : MonoBehaviour
{
    protected ToolsManager toolsManager;
    protected AudioManager audioManager;

    void Start()
    {
        toolsManager = GameObject.FindObjectOfType<ToolsManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    public virtual void DoStep()
    {

    }
}

