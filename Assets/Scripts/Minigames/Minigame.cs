using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    private MinigameManager minigameManager;

    // Start is called before the first frame update
    void Start()
    {
        minigameManager = FindObjectOfType<MinigameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endMinigame() {
        minigameManager.closeMinigame();
    }
}
