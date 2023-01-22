using RPSBasic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<ButtonController> _buttonList = new List<ButtonController>();
    public void UpdateUI(Dictionary<handsign, int> _cardRemain)
    {
        foreach (KeyValuePair<handsign,int> kvp in _cardRemain)
        {
            _buttonList[(int)kvp.Key].TextMeshPro.text = kvp.Value.ToString();
            if(kvp.Value == 0)
            {
                _buttonList[(int)kvp.Key].Button.interactable = false;
            }
        }
    }
}
