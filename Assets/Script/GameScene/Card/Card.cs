using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //카드 효과
    public string effect;
    //카드 이름
    public string cardname;
    /*카드 타입
    1. 방어
    2. 공격
    3. 특수
    4. 효과
    5. 미정
    */
    public int type;
    //카드 비용
    public int cost;
    //카드 위력
    public int amount;
    //카드 공격 타입
    public string attackType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VariableUpdate(Card apply){
        this.effect = apply.effect;
        this.cardname = apply.cardname;
        this.type = apply.type;
        this.cost = apply.cost;
        this.amount = apply.amount;
        this.attackType = apply.attackType;
    }
}
