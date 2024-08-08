using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//카드의 자식들을 정의하는 추상 클래스. 적용되는 스크립트를 부를 수 있다.
public abstract class CardElement: MonoBehaviour
{
    public abstract void ApplyScript(Card card);
}
