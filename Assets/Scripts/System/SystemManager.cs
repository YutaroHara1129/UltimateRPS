using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPS;

public class SystemManager : MonoBehaviour
{
    public void SignChoosed(handsign choosedSign)
    {
        // ゆくゆくは相手の手は、他のプレイヤーの手によって決めたい
        int opponentSign = Random.Range(0, 3);
    }
}
