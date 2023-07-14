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
    }

    public void changeChar(){
        if (isJane){
            janeDesk.SetActive(true);
            janeAnimation.SetActive(true);
            omenDesk.SetActive(false);
            omenAnimation.SetActive(false);
            map.GetComponent<SpriteRenderer>().sprite = omenMap;
            isJane = false;
        }
        else if (!isJane){
            janeDesk.SetActive(false);
            janeAnimation.SetActive(false);
            omenDesk.SetActive(true);
            omenAnimation.SetActive(true);
            map.GetComponent<SpriteRenderer>().sprite = janeMap;
            isJane = true;
        }
    }

    public void ShowText(){
        text.SetActive(true);
    }

    public void RemoveText(){
        text.SetActive(false);
    }
}
