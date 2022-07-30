using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearnScript : MonoBehaviour
{
    private bool hurt, firsthurt;
    private bool fear, firstfear;
    private bool before, firstbefore;
    private int Squirrel;
    private bool SquirrelBool;
    private bool canTalk;
    private bool canTake;
    private bool Nut;
    private int Porcupine;
    private bool PorcupineBool;
    private bool Pumpkin;
    private int PumpkinCounter;
    private bool End;

    private void Start()
    {
        hurt = false;
        firsthurt = true;
        fear = false;
        firstfear = true;
        before = false;
        firstbefore = true;
        canTalk = false;
        canTake = false;
        Squirrel = 0;
        SquirrelBool = false;
        Nut = false;
        Porcupine = 0;
        PorcupineBool = false;
        Pumpkin = false;
        PumpkinCounter = 0;
        End = false;
        
    }
    private void Update()
    {
        if (hurt && firsthurt)
        {
            cutSceneScript.StartDialogue(3);
            firsthurt = false;
        }
        if (fear && firstfear)
        {
            cutSceneScript.StartDialogue(4);
            firstfear = false;
        }
        if (before && firstbefore)
        {
            cutSceneScript.StartDialogue(7);
            firstbefore = false;
        }
        if (canTalk && Input.GetKeyDown(KeyCode.E))
        {
            if (SquirrelBool)
            {
                if (Squirrel == 0)
                {
                    Squirrel = 1;
                    cutSceneScript.StartCutScene(1);
                }
                else if (Squirrel == 3)
                {
                    Squirrel = 2;
                    cutSceneScript.StartDialogue(11);
                    StartCoroutine(StopGo(19));
                }
                else if  (Squirrel == 1)
                {
                    cutSceneScript.StartDialogue(10);
                    StartCoroutine(StopGo(8));
                }
                else if (Squirrel == 2)
                {
                    cutSceneScript.StartDialogue(12);
                    StartCoroutine(StopGo(2));
                }
            }
            if (PorcupineBool)
            {
                if (Porcupine == 0)
                {
                    Porcupine = 1;
                    cutSceneScript.StartCutScene(2);
                }
                else if (Porcupine == 1)
                {
                    cutSceneScript.StartDialogue(15);
                    StartCoroutine(StopGo(2));
                }
                else if (Porcupine == 2)
                {
                    cutSceneScript.StartDialogue(16);
                    StartCoroutine(StopGo(11));
                }
            }
        }
        if (canTake && Input.GetKeyDown(KeyCode.E))
        {
            if (Nut)
            {
                Squirrel = 3;
                Destroy(NutGO);
            }
            if (Pumpkin)
            {
                PumpkinCounter++;
                Destroy(CurrentPumpkin);
                if(PumpkinCounter == 5)
                {
                    Porcupine = 2;
                }
            }
        }

        if (canTalk && !cutSceneScript.isCutScene) cutSceneScript.StartDialogue(5);
        if (canTake && !cutSceneScript.isCutScene) cutSceneScript.StartDialogue(6);

    }
    [SerializeField] private GameObject NutGO;
    [SerializeField] private CutSceneScript cutSceneScript;
    private GameObject CurrentPumpkin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LearnHurt") && !hurt) hurt = true;
        if (collision.CompareTag("LearnFear") && !fear) fear = true;
        if (collision.CompareTag("BeforeSquirrel") && !before) before = true;


        if (collision.CompareTag("CanTalk") && !canTalk)
        {
            canTalk = true;
        }
        if (collision.CompareTag("CanTake") && !canTalk)
        {
            canTake = true;
        }
        if (collision.CompareTag("Nut")) Nut = true;
        if (collision.CompareTag("Pumpkin"))
        {
            Pumpkin = true;
            CurrentPumpkin = collision.gameObject;
        }
        if (collision.CompareTag("Squirrel1")) SquirrelBool = true;
        if (collision.CompareTag("Porcupine")) PorcupineBool = true;
        if (collision.CompareTag("End")) cutSceneScript.StartCutScene(3);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CanTalk"))
        {
            if (cutSceneScript.curText == 5) cutSceneScript.StartDialogue(13);
            canTalk = false;
        }
        if (collision.CompareTag("CanTake"))
        {
            if (cutSceneScript.curText == 6) cutSceneScript.StartDialogue(13);
            canTake = false;
        }
        if (collision.CompareTag("Squirrel1")) SquirrelBool = false;
        if (collision.CompareTag("Porcupine")) PorcupineBool = false;
        if (collision.CompareTag("Nut")) Nut = false;
        if (collision.CompareTag("Pumpkin")) Pumpkin = false;
    }
    IEnumerator StopGo(float sec)
    {
        cutSceneScript.isCutScene = true;
        yield return new WaitForSeconds(sec);
        cutSceneScript.isCutScene = false;
    }
}
