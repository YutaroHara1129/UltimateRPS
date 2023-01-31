using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPSBasic;
using Cinemachine;
using UnityEngine.Playables;

public class SystemManager : MonoBehaviour
{
    private phase _phase;
    private handsign _ownHandSign;
    private handsign _opponentHandSign;
    private Dictionary<handsign, int> _cardsRemain = new Dictionary<handsign, int>();
    private Dictionary<handsign, int> _opponentCardsRemain = new Dictionary<handsign, int>();
    private List<handsign> _opponentCardsList = new List<handsign>();
    // An error will occur if you don't assign it in the inspector
    [SerializeField] private List<CinemachineVirtualCamera> _vCamList;
    [SerializeField] private HandController _opponentHandController;
    [SerializeField] private PlayableDirector _playableDirector;

    // Subjects
    public BasicSubject<phase> PhaseSubject = new BasicSubject<phase>();
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

        _opponentCardsRemain[handsign.rock] = 3;
        _opponentCardsRemain[handsign.paper] = 3;
        _opponentCardsRemain[handsign.scissors] = 3;

        _opponentCardsList.Clear();
        _opponentCardsList.Add(handsign.rock);
        _opponentCardsList.Add(handsign.paper);
        _opponentCardsList.Add(handsign.scissors);
    }

    void BattlePhase()
    {
        PhaseSubject.SendMessage(phase.battle);
        _playableDirector.Play();

        switch (_opponentHandSign)
        {
            case handsign.rock:
                _opponentHandController.SetAnimParametor(0);
                break;
            case handsign.paper:
                _opponentHandController.SetAnimParametor(1);
                break;
            case handsign.scissors:
                _opponentHandController.SetAnimParametor(2);
                break;
        }
    }
    void SelectPhase()
    {
        PhaseSubject.SendMessage(phase.select);
    }

    public void SignChoosed(int choosedSignID)
    {
        _ownHandSign = (handsign)System.Enum.ToObject(typeof(handsign), choosedSignID);
        _opponentHandSign = ChooseOpponentSign();

        _cardsRemain[_ownHandSign]--;
        CardsRemainSubject.SendMessage(_cardsRemain);
        int resultID = JankenJadge(choosedSignID, (int)_opponentHandSign);

        BattlePhase();

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
    handsign ChooseOpponentSign()
    {
        System.Random random = new System.Random();
        var i = random.Next(_opponentCardsList.Count);
        var sign = _opponentCardsList[i];

        _opponentCardsRemain[sign]--;
        if (_opponentCardsRemain[sign] == 0) _opponentCardsList.Remove(sign);
        
        foreach(KeyValuePair<handsign, int> kvp in _opponentCardsRemain)
        {
            Debug.Log(kvp.Key + ":" + kvp.Value);
        }

        return sign;
    }
    int JankenJadge(int own, int opponent)
    {
        // ジャンケンのアルゴリズム
        return (own - opponent + 3) % 3;
    }
}
