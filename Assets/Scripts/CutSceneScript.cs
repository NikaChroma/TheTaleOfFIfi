using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CutSceneScript : MonoBehaviour
{
    public bool isCutScene;
    [SerializeField] private GameObject SkipText;
    [SerializeField] private PlayableDirector[] CutScenes;

    [SerializeField] private DialogueTextScript dialogueTextScript;
    void Start()
    {
        isCutScene = false;
        StartCutScene(0);
    }
    [SerializeField] private Text Text1;
    [SerializeField] private Text Text2;
    private string[,] CurDiaText;
    public int curText;
    public void StartDialogue(int currentText)
    {
        curText = currentText;
        CurDiaText = dialogueTextScript.DiaText[currentText];
        StopCoroutine("Dialogue");
        StartCoroutine("Dialogue");
    }
    IEnumerator Dialogue()
    {
        for (int i = 0; i < CurDiaText.Length / 2; i++)
        {
            if (CurDiaText[i, 0] == "1")
            {
                Text1.text = CurDiaText[i, 1];
                Text2.text = "";
            }
            else
            {
                Text2.text = CurDiaText[i, 1];
                Text1.text = "";
            }
            yield return new WaitForSeconds(2);
        }
        Text2.text = "";
        Text1.text = "";
    }
    private int numCutScene;
    public void StartCutScene(int num)
    {
        SkipText.SetActive(true);
        isCutScene = true;
        CutScenes[num].Play();
        numCutScene = num;
    }
    public void StopCutScene()
    {
        isCutScene = false;
        SkipText.SetActive(false);
    }
    public void SkipScene()
    {
        CutScenes[numCutScene].time = CutScenes[numCutScene].playableAsset.duration;
        CutScenes[numCutScene].Evaluate();
        CutScenes[numCutScene].Stop();
        StopCutScene();
        StartDialogue(13);
    }
}
