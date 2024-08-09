using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandArea : MonoBehaviour
{
    public static CardManager Instance { get; private set;}

    
    //복사할 카드 오브젝트
    public GameObject cardPrefab;
    //복사된 카드 오브젝트
    public static GameObject[] createdCards;
    [SerializeField]private int currenthandindex = 0;

    public void Init(int handMax){
        createdCards = new GameObject[handMax];
    }

    //덱을 읽어서 하나씩 보여주기
    public void ViewHand(Card card){
        //복사본 만들기
        GameObject createcard = Instantiate(cardPrefab, transform);
        //영역에 넣기
        createcard.transform.SetParent(transform);

        //카드에 적용
        Card applycard = createcard.transform.GetComponent<Card>();
        CopyCard(applycard, card);
        applycard.ApplyScript();

        //위치 설정
        RectTransform rectTransform = createcard.GetComponent<RectTransform>();
        rectTransform.transform.localPosition = new Vector3(-720 + 150*currenthandindex, -100, 0f);

        //생성된 카드 배열에 저장(Destroy를 하기 위해서)
        createdCards[currenthandindex] = createcard;
        currenthandindex++;
    }

    public void DestroyHand(){
        currenthandindex--;
        //핸드에 카드가 있을때만 보내면 됨
        Destroy(createdCards[currenthandindex]);
    }

    //카드 두개를 받아서 하나의 정보를 다른쪽에 옮김
    public void CopyCard(Card apply, Card copy){
        apply.effect = copy.effect;
        apply.cardname = copy.cardname;
        apply.type = copy.type;
        apply.character = copy.character;
        apply.cost = copy.cost;
        apply.amount = copy.amount;
        apply.attackType = copy.attackType;
    }
}
