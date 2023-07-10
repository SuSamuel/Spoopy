using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public GameObject minigameUIParent;
    public Minigame[] minigames;
    public GameObject currentMinigame;
    public bool inMinigame;

    // Start is called before the first frame update
    void Start()
    {
        inMinigame = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // just selects from list of minigames given by minigameId, which is pretty much the index of the minigames array
    public void startMinigame(int minigameId) {
        if(inMinigame) return;
        inMinigame = true;
        minigameUIParent.SetActive(true);

        Animator minigameUIAnimator = minigameUIParent.GetComponent<Animator>();
        minigameUIAnimator.SetBool("isMinigameOpen", true);

        GameObject minigameObject = Instantiate(minigames[minigameId].gameObject, minigameUIParent.transform);
        minigameObject.transform.SetSiblingIndex(0);
        currentMinigame = minigameObject;
    }

    public void closeMinigame() {
        Debug.Log("Closing minigame");
        inMinigame = false;
        Animator minigameUIAnimator = minigameUIParent.GetComponent<Animator>();
        minigameUIAnimator.SetBool("isMinigameOpen", false);
        minigameUIParent.SetActive(false);
        Destroy(currentMinigame);
    }
}
