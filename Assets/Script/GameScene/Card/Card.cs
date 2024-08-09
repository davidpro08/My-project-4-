using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    //카드 효과
    public string effect;
    //카드 이름
    public string cardname;
    /*카드 타입
    1. 공격
    2. 방어
    3. 특수
    4. 효과
    5. 미정
    */
    public int type;

    /*캐릭터
    1. 전사
    2. 도적
    3. 마법사
    4. ??
    5. ??
    */
    public int character;
    //카드 비용
    public int cost;
    //카드 위력
    public int amount;
    /*카드 공격 타입
    1. 근거리
    2. 원거리
    3. 마법
    4. 방어
    5. 치료
    */
    public int attackType;
    
    public CardElement[] elements;

    public void ApplyScript(){
        foreach (CardElement element in elements){
            element.ApplyScript(this);
        }
    }

    public RectTransform rectTransform;
    public Vector2 startPosition;
    public Transform startParent;


    public void OnBeginDrag(PointerEventData eventData)
    {
        //시작 위치와 부모 저장해놓기
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.localPosition;
        startParent = transform.parent;
        Debug.Log("BeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {

        rectTransform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.localPosition = startPosition;
    }
}
