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

    public HandArea handArea;


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
        handArea.Init(handMax);
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
            discardCard.Enqueue(handCard.Dequeue());
            handArea.DestroyHand();
        }
    }

    //카드 뽑기
    public void Draw(){
        if(handMax-1 >= handCard.Count){
            //카드 덱이 비었고 쓰레기통에 카드가 있으면 쓰레기통에서 다시 덱으로 가게 하기
            if(readyCard.Count<=0 && discardCard.Count > 0){
                DiscardCardReturn();
            }

            ReadyMix();

            Card drawcard = readyCard.Dequeue();

            handCard.Enqueue(drawcard);
            handArea.ViewHand(drawcard);

        }else{
            Debug.Log("최대 카드 개수 초과");
        }
    }

    //랜덤 시스템인데 너무 어렵다
    public void ReadyMix(){
        int rand = Random.Range(0, readyCard.Count);
        for(int i = 0; i<rand; i++){
            readyCard.Enqueue(readyCard.Dequeue());
        }
    }

}