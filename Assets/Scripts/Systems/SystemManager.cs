using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPSBasic;

public class SystemManager : MonoBehaviour
{
    private handsign _ownHandSign;
    private handsign _opponentHandSign;
    private Dictionary<handsign, int> _cardsRemain = new Dictionary<handsign, int>();

    public BasicSubject<Dictionary<handsign, int>> CardsRemainSubject = new BasicSubject<Dictionary<handsign, int>>();

    private void Start()
    {
        GameInitialize();
    }

    public void GameInitialize()
    {
        _cardsRemain[handsign.rock] = 3;
        _cardsRemain[handsign.paper] = 3;
        _cardsRemain[handsign.scissors] = 3;
    }

    public void SignChoosed(int choosedSignID)
    {
        // ゆくゆくは相手の手は、他のプレイヤーの手によって決めたい
        int opponentSignID = Random.Range(0, 3);

        _ownHandSign = (handsign)System.Enum.ToObject(typeof(handsign), choosedSignID);
        _opponentHandSign = (handsign)System.Enum.ToObject(typeof(handsign), opponentSignID);

        _cardsRemain[_ownHandSign]--;
        CardsRemainSubject.SendMessage(_cardsRemain);

        int resultID = JankenJadge(choosedSignID, opponentSignID);

        switch (resultID)
        {
            case (0):
                Debug.Log("result : draw | ChoosedSign : " + _ownHandSign
                    + " | OpponentSign : " + _opponentHandSign);
                break;
            case (1):
                Debug.Log("result : win | ChoosedSign : " + _ownHandSign
                    + " | OpponentSign : " + _opponentHandSign);
                break;
            case (2):
                Debug.Log("result : defeat | ChoosedSign : " + _ownHandSign
                    + " | OpponentSign : " + _opponentHandSign);
                break;
            default:
                Debug.LogWarning("resultID is an invalid value. | value : " + resultID);
                break;
        }
    }
    int JankenJadge(int own, int opponent)
    {
        // ジャンケンのアルゴリズム
        return (own - opponent + 3) % 3;
    }
}
