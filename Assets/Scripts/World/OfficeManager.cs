using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OfficeManager : MonoBehaviour
{

    public GameObject omenDesk;
    public GameObject janeDesk;
    public GameObject map;
    public GameObject omenAnimation;
    public GameObject janeAnimation;
    public Sprite janeMap;
    public Sprite omenMap;
    public GameObject text;
    private PlayerMovement playerMovement;

    public GameObject minigameUIParent;

    public GameObject jobBoard;
    public GameObject helpBoard;

    public Sprite[] helpBoardSprites;

    public GameObject helpNextButton;
    public GameObject helpBackButton;

    private int helpNum;
    private bool isJane = true;

    public bool inJobBoard = false;

    private int mapSelected;

    private void Start() {
        text.SetActive(false);
        janeDesk.SetActive(false);
        janeAnimation.SetActive(false);
        map.GetComponent<SpriteRenderer>().sprite = janeMap;
        playerMovement = FindObjectOfType<PlayerMovement>();
        int checkJane = PlayerPrefs.GetInt("IsJane", 0);
        if (checkJane == 0){
            isJane = true;
        }
        else{
            isJane = false;
        }
        SetStart();
    }

    public void changeChar(){
        if (isJane){
            janeDesk.SetActive(true);
            janeAnimation.SetActive(true);
            omenDesk.SetActive(false);
            omenAnimation.SetActive(false);
            map.GetComponent<SpriteRenderer>().sprite = omenMap;
            isJane = false;
            PlayerPrefs.SetInt("IsJane", 1);
        }
        else if (!isJane){
            janeDesk.SetActive(false);
            janeAnimation.SetActive(false);
            omenDesk.SetActive(true);
            omenAnimation.SetActive(true);
            map.GetComponent<SpriteRenderer>().sprite = janeMap;
            isJane = true;
            PlayerPrefs.SetInt("IsJane", 0);
        }
    }

    private void SetStart(){
        if (isJane){
            janeDesk.SetActive(false);
            janeAnimation.SetActive(false);
            omenDesk.SetActive(true);
            omenAnimation.SetActive(true);
            map.GetComponent<SpriteRenderer>().sprite = janeMap;
        }
        else{
            janeDesk.SetActive(true);
            janeAnimation.SetActive(true);
            omenDesk.SetActive(false);
            omenAnimation.SetActive(false);
            map.GetComponent<SpriteRenderer>().sprite = omenMap;
        }
    }

    public void ShowText(){
        text.SetActive(true);
    }

    public void RemoveText(){
        text.SetActive(false);
    }

    public void ShowJobBoard(){
        playerMovement.noMove = true;
        minigameUIParent.SetActive(true);
        inJobBoard = true;
        RemoveText();
        Animator minigameUIAnimator = minigameUIParent.GetComponent<Animator>();
        minigameUIAnimator.SetBool("isMinigameOpen", true);
    }

    public void CloseJobBoard(){
        playerMovement.noMove = false;
        inJobBoard = false;
        Animator minigameUIAnimator = minigameUIParent.GetComponent<Animator>();
        minigameUIAnimator.SetBool("isMinigameOpen", false);
        helpBoard.SetActive(false);
        jobBoard.SetActive(true);
        minigameUIParent.SetActive(false);
        ShowText();
    }

    public void HelpButton(){
        helpNum = 0;
        helpBoard.GetComponent<Image>().sprite = helpBoardSprites[helpNum];
        helpBoard.SetActive(true);
        jobBoard.SetActive(false);
        helpNextButton.SetActive(true);
        helpBackButton.SetActive(false);
    }

    public void BackFromHelp(){
        helpBoard.SetActive(false);
        jobBoard.SetActive(true);
    }

    //Make Do something
    public void mapButton(){
        Debug.Log("Remember which map");
    }

    public void nextHelpPage(){
        helpBackButton.SetActive(true);
        helpNum++;
        if (helpNum <= 4){
            helpBoard.GetComponent<Image>().sprite = helpBoardSprites[helpNum];
        }
        if (helpNum == 4){
            helpNextButton.SetActive(false);
        }
        if (helpNum - 1 == 0){
            helpNextButton.SetActive(true);
        }
    }
    public void backHelpPage(){
        helpNextButton.SetActive(true);
        helpNum--;
        if (helpNum >= 0){
            helpBoard.GetComponent<Image>().sprite = helpBoardSprites[helpNum];
        }
        if (helpNum == 0){
            helpBackButton.SetActive(false);
        }
        if (helpNum + 1 == 4){
            helpBackButton.SetActive(true);
        }
    }

    public void LeaveMap(){
        SceneManager.LoadScene(1);
    }
}
