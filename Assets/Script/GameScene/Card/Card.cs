using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //카드 이름
    public string cardName;
    //카드 타입
    public string type;
    //카드 코스트
    public int cost;
    //카드 위력
    public int amount;
    //카드 공격 유형
    public string attackType;

    /*
    자식들을 명명함
    1. 카드 배경
    2. 카드 효과
    3. 카드 이미지
    4. 카드 이미지 배경
    5. 카드 이름
    6. 카드 타입
    7. 카드 코스트
    8. 카드 위력
    9. 카드 공격 타입
    */
    public GameObject cardBackground;
    public GameObject cardEffect;
    public GameObject cardImage;
    public GameObject cardImageBackground;
    public GameObject cardNameObject;
    public GameObject cardType;
    public GameObject cardCost;
    public GameObject cardAmount;
    public GameObject cardAttackType;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
