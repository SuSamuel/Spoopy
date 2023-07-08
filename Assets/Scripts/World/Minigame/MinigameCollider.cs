using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameCollider : MonoBehaviour
{
    private Collider2D mapCollider;
    public int minigameId;

    // Start is called before the first frame update
    void Start()
    {
        mapCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Triggered");
        if(collider.gameObject.tag == "Player") {
            Player player = collider.gameObject.GetComponent<Player>();
            player.setCurrentMinigame(minigameId);
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player") {
            Player player = collider.gameObject.GetComponent<Player>();
            player.setCurrentMinigame(-1);
        }
    }
}
