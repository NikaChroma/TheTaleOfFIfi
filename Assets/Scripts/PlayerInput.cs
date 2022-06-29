using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private CutSceneScript cutScene;
    [SerializeField] private bool isMenu;
  
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (!isMenu)
        {
            if (!cutScene.isCutScene)
            {
                float DirectionX = Input.GetAxis("Horizontal");
                bool isJump = Input.GetButtonDown("Jump");
                playerMovement.Move(DirectionX, isJump);
            }
        }
        else
        {
            float DirectionX = Input.GetAxis("Horizontal");
            bool isJump = Input.GetButtonDown("Jump");
            playerMovement.Move(DirectionX, isJump);
        }
    }
}
