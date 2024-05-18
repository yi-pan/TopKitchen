using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Yarn.Unity;

public class CustomCommand : MonoBehaviour
{
    public DialogueRunner dialogueRunner;

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    private void change_bg(string target)
    {
        GameObject bg = FindInActiveObjectByName(target);
        if (bg == null)
        {
            UnityEngine.Debug.Log("Can't find the target!");
        }
        else bg.SetActive(true);
    }

    public void Awake()
    {
        dialogueRunner.AddCommandHandler<string>(
            "change_bg",     // the name of the command
            change_bg // the method to run
        );
    }

}
