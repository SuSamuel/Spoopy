using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private bool isJane = true;

    private void Start() {
        text.SetActive(false);
        janeDesk.SetActive(false);
        janeAnimation.SetActive(false);
        map.GetComponent<SpriteRenderer>().sprite = janeMap;
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
}
