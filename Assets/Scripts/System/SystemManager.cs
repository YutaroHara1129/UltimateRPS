using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPS;

public class SystemManager : MonoBehaviour
{
    public void SignChoosed(handsign choosedSign)
    {
        int choosedSignID = (int)choosedSign;
        // ゆくゆくは相手の手は、他のプレイヤーの手によって決めたい
        int opponentSignID = Random.Range(0, 3);

        int resultID = JankenJadge(choosedSignID, opponentSignID);

        Debug.Log(resultID);
    }
    int JankenJadge(int own, int opponent)
    {
        // ジャンケンのアルゴリズム
        return (own - opponent + 3) % 3;
    }
}
