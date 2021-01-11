using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Move4Player : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public GameObject umb;
    private float angle;

    public GameObject obstacleBall;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void touchDrag()
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(touchPosition.y - this.transform.position.y, touchPosition.x - this.transform.position.x) * Mathf.Rad2Deg;

        if (angle >= 0f)
        {
            umb.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        touchDrag();
    }

    public void OnDrag(PointerEventData eventData)
    {
        touchDrag();
    }

    // 드래그가 끝났을 경우 변수 초기화
    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
}
