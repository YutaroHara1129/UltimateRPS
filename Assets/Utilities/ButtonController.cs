using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Image _image = null;

    [SerializeField] private Sprite _idleSprite = null;
    [SerializeField] private Sprite _hoverSprite = null;

    [SerializeField] private Button _button;
    public Button Button
    {
        get { return _button; }
        private set { _button = value; }
    }
    public TextMeshProUGUI TextMeshPro;

    // Null check approved or not
    private bool hasApproved = false;

    private void Start()
    {
        if(_image != null && _idleSprite != null && _hoverSprite)
        {
            hasApproved = true;
        }
        else
        {
            Debug.Log("Null check not approved. | Location Å® " + this);
        }
    }

    public void SpriteChange()
    {
        if (!hasApproved)
        {
            Debug.Log("Null check not approved. | Location Å® " + this);
        }
        else if(_button.interactable == true)
        {
            if(_image.sprite == _idleSprite)
            {
                _image.sprite = _hoverSprite;
            }
            else if (_image.sprite == _hoverSprite)
            {
                _image.sprite = _idleSprite;
            }
        }
        else if (_image.sprite == _hoverSprite)
        {
            _image.sprite = _idleSprite;
        }
    }
}
