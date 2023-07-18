using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficePlayer : MonoBehaviour
{
    private Collider2D playerCollider;
    private PlayerMovement playerMovement;
    public bool changeChar = false;
    public bool jobBoard = false;
    public bool exit = false;

    public GameObject office;

    private OfficeManager officeManager;


    // Start is called before the first frame update
    void Start()
    {
        officeManager = FindObjectOfType<OfficeManager>();
        playerCollider = GetComponent<Collider2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        handleInputs();
    }

    private void handleInputs() {
        if(Input.GetKeyDown("e")) {
            enterSelection();
        }
        if(Input.GetKeyDown("escape")) {
            if(officeManager.inJobBoard) officeManager.CloseJobBoard();
        }
    }

    private void enterSelection(){
        if(changeChar){
            playerMovement.ChangeChar();
            officeManager.changeChar();
        }
        else if(jobBoard){
            officeManager.ShowJobBoard();
        }

        else if (exit){
            officeManager.LeaveMap();
        }
    }

}
