using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPS;

public class SystemManager : MonoBehaviour
{
    private handsign ownHandSign;
    private handsign opponentHandSign;

    public void SignChoosed(int choosedSignID)
    {
        // ゆくゆくは相手の手は、他のプレイヤーの手によって決めたい
        int opponentSignID = Random.Range(0, 3);

        ownHandSign = (handsign)System.Enum.ToObject(typeof(handsign), choosedSignID);
        opponentHandSign = (handsign)System.Enum.ToObject(typeof(handsign), opponentSignID);

        int resultID = JankenJadge(choosedSignID, opponentSignID);

        switch (resultID)
        {
            case (0):
                Debug.Log("result : draw | ChoosedSign : " + ownHandSign
                    + " | OpponentSign : " + opponentHandSign);
                break;
            case (1):
                Debug.Log("result : win | ChoosedSign : " + ownHandSign
                    + " | OpponentSign : " + opponentHandSign);
                break;
            case (2):
                Debug.Log("result : defeat | ChoosedSign : " + ownHandSign
                    + " | OpponentSign : " + opponentHandSign);
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
