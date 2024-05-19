using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

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

    private void inactive_bg(string target)
    {
        GameObject bg = GameObject.Find(target);
        if (bg == null)
        {
            UnityEngine.Debug.Log("Can't find the target!");
        }
        else bg.SetActive(false);
    }

    private void change_scene(string target)
    {
        SceneManager.LoadScene(target);
    }

    private void show(string target)
    {
        GameObject speaker = FindInActiveObjectByName(target);
        if (speaker != null) speaker.gameObject.SetActive(true);
    }

    private void unshow(string target)
    {
        GameObject speaker = GameObject.Find(target);
        if (speaker != null) speaker.gameObject.SetActive(false);
    }

    public void Awake()
    {
        dialogueRunner.AddCommandHandler<string>(
            "change_bg",     // the name of the command
            change_bg // the method to run
        );

        dialogueRunner.AddCommandHandler<string>(
            "inactive_bg",     // the name of the command
            inactive_bg // the method to run
        );

        dialogueRunner.AddCommandHandler<string>(
            "change_scene",     // the name of the command
            change_scene // the method to run
        );

        dialogueRunner.AddCommandHandler<string>(
            "show",     // the name of the command
            show // the method to run
        );

        dialogueRunner.AddCommandHandler<string>(
            "unshow",     // the name of the command
            unshow // the method to run
        );
    }

}
