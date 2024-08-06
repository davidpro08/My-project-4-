using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class HandArea : MonoBehaviour
{
    public GameObject cardPrefab;

    public GameObject[] cardCreated;

    

    //카드 목록을 읽어와서 영역에 시각화
    public void ViewCard(Queue<Card> hand){

        if(cardPrefab != null){
                    
        //초기화
        Card[] cardlist = hand.ToArray();

        Debug.Log(cardlist.Length);
        for(int index = 0; index < cardlist.Length; index++){
            GameObject createcard = cardPrefab;
            //카드에 적용
            Card card = createcard.transform.GetComponent<Card>();
            card.VariableUpdate(cardlist[index]);
            
            //복사본 만들기
            GameObject temp = Instantiate(createcard, transform);
            //위치 설정

            RectTransform rectTransform = temp.GetComponent<RectTransform>();

            rectTransform.transform.localPosition = new Vector3(-720 + 240*index, 0f, 0f);
        }

        }else{
            Debug.Log("card 프리팹 없음. 카드 프리팹이 삭제되었는지 확인하거나 HandArea에 안 들어갔는지 확인하기");
        }
    }
}
