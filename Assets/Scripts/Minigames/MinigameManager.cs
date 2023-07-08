using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public GameObject minigameUIParent;
    public GameObject[] minigames;
    public GameObject currentMinigame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startMinigame(int minigameId) {
        minigameUIParent.SetActive(true);

        Animator minigameUIAnimator = minigameUIParent.GetComponent<Animator>();
        minigameUIAnimator.SetBool("isMinigameOpen", true);

        GameObject minigameObject = Instantiate(minigames[minigameId], minigameUIParent.transform);
        minigameObject.transform.SetSiblingIndex(0);
        currentMinigame = minigameObject;
    }

    public void closeMinigame() {
        Debug.Log("Closing minigame");
        Animator minigameUIAnimator = minigameUIParent.GetComponent<Animator>();
        minigameUIAnimator.SetBool("isMinigameOpen", false);
        minigameUIParent.SetActive(false);
        Destroy(currentMinigame);
    }
}
