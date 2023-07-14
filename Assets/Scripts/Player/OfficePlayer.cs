using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficePlayer : MonoBehaviour
{
    private Collider2D playerCollider;
    private PlayerMovement playerMovement;
    public bool changeChar = false;
    public bool jobBoard = false;

    public GameObject officeManager;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    private void enterSelection(){
        if(changeChar){
            playerMovement.ChangeChar();
            officeManager.GetComponent<OfficeManager>().changeChar();
        }
        if(jobBoard){
            playerMovement.noMove = true;
        }
    }

}
