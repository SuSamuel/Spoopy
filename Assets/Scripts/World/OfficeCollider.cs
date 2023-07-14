using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeCollider : MonoBehaviour
{
    private Collider2D mapCollider;
    public bool changeChar = false;

    public GameObject officeManager;

    // Start is called before the first frame update
    void Start()
    {   
        mapCollider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Triggered");
        if(collider.gameObject.tag == "Player") {
            OfficePlayer player = collider.gameObject.GetComponent<OfficePlayer>();
            if(changeChar){
                player.changeChar = true;
            }
            else{
                player.jobBoard = true;
            }
            officeManager.GetComponent<OfficeManager>().ShowText();
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        Debug.Log("test");
        if(collider.gameObject.tag == "Player") {
            OfficePlayer player = collider.gameObject.GetComponent<OfficePlayer>();
            player.changeChar = false;
            player.jobBoard = false;
            officeManager.GetComponent<OfficeManager>().RemoveText();
        }
    }
}
