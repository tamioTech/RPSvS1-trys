using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{
    [SerializeField] float snapDistance;
    [SerializeField] Transform _slot1;
    [SerializeField] Transform _slot2;

    private bool _dragging;

    private Vector2 _offset, _originalPos;

    private void Awake()
    {
        _originalPos = transform.position;
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
    }

    private void OnMouseUp()
    {
        _dragging = false;

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
