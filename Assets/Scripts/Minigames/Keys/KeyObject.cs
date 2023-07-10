using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyObject : DraggableObject
{
    public int keyId;

    protected override void OnObjectDrag(PointerEventData eventData) {
        Debug.Log("Object is dragging");
    }

    protected override void OnDragStart(PointerEventData eventData)
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        KeyMinigame keyMinigame = minigame as KeyMinigame;
        transform.SetParent(keyMinigame.interactedKeys.transform);
    }

    protected override void OnDragEnd(PointerEventData eventData)
    {
        Debug.Log("End Dragging");
        DropArea dropArea = GetOverlappingArea(minigame.dropAreas);
        string id = dropArea ? dropArea.dropAreaId : null;
        if(id == "SHADOW") {
            KeyMinigame keyMinigame = minigame as KeyMinigame;
            if(keyMinigame.shadowId == keyId) {
                keyMinigame.endMinigame(true);
            }
        }
    }

    public void setKeyId(int keyId) {
        this.keyId = keyId;
    }
}
