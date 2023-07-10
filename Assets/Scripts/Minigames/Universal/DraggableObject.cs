using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DraggableObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    // any minigame object that can be dragged should inherit this class

    protected Minigame minigame;
    protected GameObject boundedArea;

    void Start() {
        minigame = FindObjectOfType<Minigame>();
        boundedArea = minigame.boundedArea;
    }

    public void OnDrag(PointerEventData eventData) {
        // prevent draggable items from exiting minigame play area
        Rect boundedAreaWorldRect = GetWorldRect(boundedArea.GetComponent<RectTransform>());
        Rect worldRect = GetWorldRect(GetComponent<RectTransform>());
        float[] bounds = new float[] { boundedAreaWorldRect.xMin + worldRect.width, boundedAreaWorldRect.xMax - worldRect.width, boundedAreaWorldRect.yMin + worldRect.height / 2, boundedAreaWorldRect.yMax - worldRect.height / 2 };
        transform.position = new Vector2(Mathf.Clamp(eventData.position.x, bounds[0], bounds[1]), Mathf.Clamp(eventData.position.y, bounds[2], bounds[3]));

        OnObjectDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData) {
        OnDragEnd(eventData);
    }

    public void OnBeginDrag(PointerEventData eventData) {
        OnDragStart(eventData);
    }

    public DropArea GetOverlappingArea(DropArea[] dropAreas) {
        for(int i = 0; i < dropAreas.Length; i++) {
            RectTransform rectTransform = dropAreas[i].GetComponent<RectTransform>();
            RectTransform objectRect = GetComponent<RectTransform>();
            Rect worldRectTransform = GetWorldRect(rectTransform);
            Rect worldObjectRect = GetWorldRect(objectRect);
            if(worldRectTransform.Overlaps(worldObjectRect)) return dropAreas[i];
        }
        return null;
    }

    private Rect GetWorldRect(RectTransform rectTransform) {
        Rect localRect = rectTransform.rect;
        return new Rect{
            min = rectTransform.TransformPoint(localRect.min),
            max = rectTransform.TransformPoint(localRect.max)
        };
    }

    protected abstract void OnObjectDrag(PointerEventData eventData);
    protected virtual void OnDragEnd(PointerEventData eventData) {}
    protected virtual void OnDragStart(PointerEventData eventData) {}
}
