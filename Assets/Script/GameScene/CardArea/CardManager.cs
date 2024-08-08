using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set;}
    //덱을 가져오기
    public Deck deck;

    //복사할 카드 오브젝트
    public GameObject cardPrefab;
    //복사된 카드 오브젝트
    [SerializeField]public GameObject[] createdCards;
    
    /******************************************************************************
    덱과 손, 쓰레기통을 자료구조 Queue를 이용하여 나타낸 이유는
    카드는 어딘가로 이동할 때 하나만 있어야 하며, 다른 곳으로 이동하는 즉시 원래 있던곳에서 나와야함
    그러므로 선입선출 가능 + 카드가 이동할 시 원래 있던곳에서 알아서 지워주는 Queue 자료구조를 사용함
    */
    //덱
    private Queue<Card> readyCard;
    [SerializeField]private int readyMax = 99;
    //손
    private Queue<Card> handCard;
    [SerializeField]private int handMax = 5;
    //쓰레기통
    private Queue<Card> discardCard;
    [SerializeField]private int discardMax = 99;

    //턴이 시작될 때 뽑는 카드 개수
    [SerializeField]private int startTurnDrawCount = 3;

    [SerializeField]private GameObject readyArea;
    
    [SerializeField]private GameObject handArea;
    
    [SerializeField]private GameObject discardArea;




    void Awake()
    {
        Init();
        ReadDeck();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartTurn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Init(){
        readyCard = new Queue<Card>();
        handCard = new Queue<Card>();
        discardCard = new Queue<Card>();
        createdCards = new GameObject[handMax];
    }

    //덱을 읽어서 준비영역에 넣기
    public void ReadDeck(){
        for(int i=0; i<deck.deckList.Length; i++){
            readyCard.Enqueue(deck.deckList[i]);
        }
    }

    public void EndTurn(){
        EndTurnDiscard(readyCard, handCard, discardCard);
    }

    public void StartTurn(){
        StartTurnDraw(readyCard, handCard, discardCard, startTurnDrawCount);
        ViewCard(cardPrefab, handCard, createdCards, handArea);
    }

    //턴 시작할 때 덱에서 카드 뽑기
    public void StartTurnDraw(Queue<Card> ready, Queue<Card> hand, Queue<Card> discard, int drawcount){
        for(int i=0; i<drawcount; i++){
            if(ready.Count<=0 && discard.Count >=0){
                DiscardCardReturn(readyCard, handCard, discardCard);
            }
            hand.Enqueue(ready.Dequeue());
        }
    }

    //턴 끝날 때 손에서 카드 버리기
    public void EndTurnDiscard(Queue<Card> ready, Queue<Card> hand, Queue<Card> discard){
        while(hand.TryPeek(out Card result)){
            discard.Enqueue(hand.Dequeue());
        }
    }

    //버린 카드를 덱에 다시 넣기
    public void DiscardCardReturn(Queue<Card> ready, Queue<Card> hand, Queue<Card> discard){
        while(discard.TryPeek(out Card result)){
            ready.Enqueue(discard.Dequeue());
        }
    }

    //카드 목록을 읽어와서 영역에 시각화
    public void ViewCard(GameObject copyobject, Queue<Card> hand, GameObject[] copyed, GameObject area){

        if(copyobject != null){
        
        //초기화
        Card[] cardlist = hand.ToArray();

        //프리팹 복사하기. 그냥 하면 아래 내용들이 원본에 복사되기 때문에 내용을 받아서 사용함.
        GameObject createcard = copyobject;

        for(int index = 0; index < cardlist.Length; index++){
            //복사본 만들기
            copyed[index] = Instantiate(createcard, transform);

            //영역에 넣기
            copyed[index].transform.SetParent(area.transform);

            //카드에 적용
            Card card = copyed[index].transform.GetComponent<Card>();
            CopyCard(card, cardlist[index]);
            card.ApplyScript();

            //위치 설정
            RectTransform rectTransform = copyed[index].GetComponent<RectTransform>();
            rectTransform.transform.localPosition = new Vector3(-720 + 240*index, 0f, 0f);
        }

        }else{
            Debug.Log("card 프리팹 없음. 카드 프리팹이 삭제되었는지 확인하거나 HandArea에 안 들어갔는지 확인하기");
        }
    }

    //카드 두개를 받아서 하나의 정보를 다른쪽에 옮김
    public void CopyCard(Card copy, Card apply){
        copy.effect = apply.effect;
        copy.cardname = apply.cardname;
        copy.type = apply.type;
        copy.character = apply.character;
        copy.cost = apply.cost;
        copy.amount = apply.amount;
        copy.attackType = apply.attackType;
    }

}