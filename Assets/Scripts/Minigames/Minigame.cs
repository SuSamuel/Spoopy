using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    // when creating new minigames, we need to:
    /**
        - create MinigameCollider - attach this script to an empty game object under Map > Minigame Triggers with a BoxCollider2D and RigidBody2D and move the collider to wherever on the map the minigame can be triggered. 
                            set the minigameID to the index that this minigame will be on the MInigameManager
        - create Minigame prefab - this is the UI element to be instantiated under the Minigame UI object (see Keys Minigame prefab under Prefabs > Minigames for an example)
        - create a new script that inherits Minigame, attach that script to the Minigame prefab
            - this script that inherits Minigame will handle its own individual minigame logic (see KeyMinigame.cs)
        - add the Minigame prefab to the list of minigames under MinigameManager (ensuring that the index matches the id of the minigame (maybe find a better way to do this?))

        - about Universal folder
            - these are all objects that can be used across different minigames
            - DraggableObject -> this is an abstract class that can be inherited by a minigame object (i.e. Keys > KeyObject.cs) and is used if that object can be dragged in the minigame
                                - these objects can only be dragged within the bounds of the boundedArea game object's rect transform
            - DropArea -> areas in the minigame that a DraggableObject can be dropped in
    **/

    // attach all DropAreas in the minigame to this array, DraggableObjects can use GetOverlappingArea to get any DropAreas that object might be inside of
    public DropArea[] dropAreas;
    // usually the background of the minigame, this area is the area where the draggable objects are allowed to move in
    public GameObject boundedArea;

    protected MinigameManager minigameManager;

    private void Start() {
        minigameManager = FindObjectOfType<MinigameManager>();
        OnMinigameStart();
    }

    protected abstract void OnMinigameStart();

    public void endMinigame(bool didWin) {
        minigameManager.closeMinigame();
    }
}
