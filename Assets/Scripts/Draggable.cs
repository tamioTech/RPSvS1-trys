using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{
    [SerializeField] float snapDistance;
    [SerializeField] Transform _slot1;
    [SerializeField] Transform _slot2;
    [SerializeField] BoxCollider2D slot1BoxCol;
    [SerializeField] BoxCollider2D slot2BoxCol;


    SpriteRenderer spriteRenderer;

    private bool _dragging;
    public bool IsDragging()
    {
        print("am i draggin? " + _dragging);
        return _dragging; }

    private Vector2 _offset, _originalPos;

    private void Awake()
    {
        _originalPos = transform.position;
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!_dragging) return;

        var mousePosition = GetMousePos();

        transform.position = mousePosition - _offset;
    }

    private void OnMouseDown()
    {
        _dragging = true;
        _offset = GetMousePos() - (Vector2)transform.position;
        spriteRenderer.sortingOrder = 5;
        slot1BoxCol.enabled = false;
        slot2BoxCol.enabled = false;
    }

    private void OnMouseUp()
    {
        _dragging = false;
        spriteRenderer.sortingOrder = 4;
        slot1BoxCol.enabled = true;
        slot2BoxCol.enabled = true;

        if (Vector2.Distance(transform.position, _slot1.position) < snapDistance)
        {
            transform.position = _slot1.position;
            return;
        }
        if (Vector2.Distance(transform.position, _slot2.position) < snapDistance)
        {
            transform.position = _slot2.position;
            return;
        }
        transform.position = _originalPos;
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
