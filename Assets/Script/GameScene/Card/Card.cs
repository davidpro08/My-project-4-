using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Card : MonoBehaviour
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
    

}
