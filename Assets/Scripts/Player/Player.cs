using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Collider2D playerCollider;
    public int currentMinigameId = -1;
    public MinigameManager minigameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e")) {
            enterMinigame();
        }
    }

    // a -1 minigameID indicates no minigame in proximity
    public void setCurrentMinigame(int minigameID) {
        currentMinigameId = minigameID;
    }

    public void enterMinigame() {
        if(currentMinigameId == -1) return;
        minigameManager.startMinigame(currentMinigameId);
    }
}
