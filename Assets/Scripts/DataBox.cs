using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DataBox : MonoBehaviour
{
    [System.NonSerialized] public Unit[] playerUnits = new Unit[5];
    [System.NonSerialized] public Unit[] enemyUnits = new Unit[5];

    [SerializeField] List<Card> defaultDeck = new List<Card>();//�f�b�L���X�g�BAwake�Ńf�b�L���e�������ɓ���Ƃ��B�w���Instanciete����Getcomponent�������̂�

    [System.NonSerialized] public List<Card> deckCards = new List<Card>();//�R�D
    [System.NonSerialized] public List<Card> handCards = new List<Card>();//��D
    [System.NonSerialized] public List<Card> usingCards = new List<Card>();//���̃^�[���g�p����J�[�h
    [System.NonSerialized] public List<Card> trushCards = new List<Card>();//�̂ĎD�B��n�B

    int turnCount = 0;

    void Start()
    {
        //�f�b�L�����m�F(�����͌�ŕς���)
        if(defaultDeck.Count != 30)
        {
            Debug.Log("Error!");
        }
        else
        {
            for(int i = 0; i < defaultDeck.Count; i++)
            {
                defaultDeck[i] = Instantiate(defaultDeck[i], new Vector2(30, 0), Quaternion.identity);
            }

            //�f�b�L�V���b�t��
            int deck_length = defaultDeck.Count;
            for(int i = 0; i < deck_length; i++)
            {
                int randomNum = Random.Range(0, deck_length);
                if (defaultDeck[randomNum] != null)
                {
                    deckCards.Add(defaultDeck[randomNum]);
                    defaultDeck[randomNum] = null;
                }
                else
                {
                    i--;
                }
            }
        }

        //��D��z��(���薇���͌�ŕύX)
        for(int i = 0; i < 5; i++)
        {
            StateChange(deckCards[0], state.hand);
            deckCards.RemoveAt(0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetEnd(InputAction.CallbackContext context)
    { 
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("SetEnd");
            MatchStart();
        }
    }

    void MatchStart()
    {
        Debug.Log("MatchStart");
        for (int i = 0; i < usingCards.Count; i++)
        {
            if (usingCards[i] == null)
            {
                continue;
            }
            usingCards[i].OnTurnStart();
        }
        Match();
    }

    void Match()
    {

        Debug.Log("Match");
        for (int i = 0; i < usingCards.Count; i++)
        {
            if (usingCards[i] == null)
            {
                continue;
            }
            usingCards[i].Use();
        }
        MatchEnd();
    }

    public void MatchEnd()
    {
        Debug.Log("MatchEnd");

        for (int i = 0; i < playerUnits.Length; i++)
        {
            if (playerUnits[i] != null)
            {
                playerUnits[i].EndTrigger();          
            }
        }

        for (int i = 0; i < enemyUnits.Length; i++)
        {
            if (enemyUnits[i] != null)
            {
                enemyUnits[i].EndTrigger();
            }
        }

        //�J�[�h�̎g�p�㏈��(Trush�ւ̈ړ�)
        for (int i = 0; i < usingCards.Count; i++)
        {
            if (usingCards[i] == null)
            {

            }
            else
            {
                trushCards.Add(usingCards[i]);
                usingCards[i].OnTurnEnd();
                i--;
            }
        }
        NextTurn();
    }

    public void NextTurn()
    {
        turnCount++;
        Debug.Log("NextTurn:" + turnCount);
        //�^�[���J�n���h���[(�����͌��)
        for (int i = 0; i < 3; i++)
        {
            StateChange(deckCards[0], state.hand);
            deckCards.RemoveAt(0);
        }
    }

    public void addUsingCards(Card card)
    {
        usingCards.Add(card);
    }

    public void StateChange(Card card, state mode)
    {
        Vector2 pivotVector;
        switch (mode)
        {
            case state.deck:
                card.rb.simulated = false;
                card.bc.enabled = false;
                transform.position = new Vector3(30, 0, 0);

                break;

            case state.hand:
                handCards.Add(card);
                card.rb.simulated = true;
                card.bc.enabled = true;

                break;

            case state.trush:
                card.rb.simulated = false;
                card.bc.enabled = false;
                transform.position = new Vector3(-30, 0, 0);

                break;

            case state.use:
                for (int i = 0; i < usingCards.Count; i++)
                {
                    if(usingCards[i].gameObject == card.gameObject)
                    {
                        usingCards.RemoveAt(i);
                        handCards.RemoveAt(i);
                        Debug.Log("Remove:" + usingCards.Count);
                        break;
                    }
                }
                card.rb.simulated = false;
                card.bc.enabled = false;
                card.transform.position = new Vector3(-30, 0, 0);

                break;

            case state.reset:

                break;
        }

        //2 = �J�[�h�̉���
        pivotVector = new Vector2(handCards.Count * -0.5f * 2, -3.4f);
        for (int i = 0; i < handCards.Count; i++)
        {
            handCards[i].transform.position = pivotVector + new Vector2(2 * i, 0);
        }

    }
}
