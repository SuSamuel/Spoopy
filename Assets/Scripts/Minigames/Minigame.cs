using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    // when creating new minigames, we need to:
    /**
        - create MinigameCollider - attach this script to an empty game object under Map > Minigame Triggers with a BoxCollider2D and RigidBody2D and move the collider to wherever on the map the minigame can be triggered. 
                            set the minigameID to the index that this minigame will be on the MInigameManager
        - create Minigame prefab - this is the UI element to be instantiated under the Minigame UI object (see Keys Minigame prefab under Prefabs > Minigames for an example), attach this Minigame script to the parent
        - add the Minigame prefab to the list of minigames under MinigameManager
    **/

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
