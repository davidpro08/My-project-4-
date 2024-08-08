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
    [SerializeField]private GameObject[] createdCards;
    
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

    //지금 몇 장 있는지
    [SerializeField]private int currenthandindex = 0;
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

    public void StartTurn(){
        StartTurnDraw();
    }

    public void EndTurn(){
        EndTurnDiscard();
    }

    //턴 시작할 때 덱에서 카드 뽑기
    public void StartTurnDraw(){
        for(int i=0; i<startTurnDrawCount; i++){
            Draw();
        }
    }

    //턴 끝날 때 손에서 카드 버리기
    public void EndTurnDiscard(){
        while(handCard.TryPeek(out Card result)){
            DiscardHand();
        }
    }

    //버린 카드를 덱에 다시 넣기
    public void DiscardCardReturn(){
        while(discardCard.TryPeek(out Card result)){
            readyCard.Enqueue(discardCard.Dequeue());
        }
    }

    //손에서 카드 목록을 읽어와서 없애기(쓰레기통으로 보냄)
    public void DiscardHand(){
        //핸드에 카드가 있을때만 보내면 됨
        if(handCard != null){
            currenthandindex--;
            Destroy(createdCards[currenthandindex]);
            discardCard.Enqueue(handCard.Dequeue());
        }
    }

    //카드 뽑기
    public void Draw(){

        if(cardPrefab != null){
            if(handMax-1 >= currenthandindex){

            //카드 덱이 비었고 쓰레기통에 카드가 있으면 쓰레기통에서 다시 덱으로 가게 하기
            if(readyCard.Count<=0 && discardCard.Count >=0){
                DiscardCardReturn();
            }
            //뽑은 카드
            Card drawcard = readyCard.Dequeue();
            handCard.Enqueue(drawcard);

            //복사본 만들기
            GameObject createcard = Instantiate(cardPrefab, transform);

            //영역에 넣기
            createcard.transform.SetParent(handArea.transform);

            //카드에 적용
            Card card = createcard.transform.GetComponent<Card>();
            CopyCard(card, drawcard);
            card.ApplyScript();

            //위치 설정
            RectTransform rectTransform = createcard.GetComponent<RectTransform>();
            rectTransform.transform.localPosition = new Vector3(-720 + 240*currenthandindex, 0f, 0f);

            //생성된 카드 배열에 저장(Destroy를 하기 위해서)
            createdCards[currenthandindex] = createcard;
            currenthandindex++;
            }else{
                Debug.Log("최대 카드 개수 초과");
            }
        }else{
            Debug.Log("card 프리팹 없음. 카드 프리팹이 삭제되었는지 확인하거나 HandArea에 안 들어갔는지 확인하기");
        }
    }

    public void ReadyMix(){
        IEnumerator it = readyCard.GetEnumerator();
        int rand = Random.Range(0, readyCard.Count);
        for(int i = 0; i<rand; i++){
            it.MoveNext();
        }
        handCard.Enqueue((Card)it.Current);
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