using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Image _image = null;

    [SerializeField] private Sprite _idleSprite = null;
    [SerializeField] private Sprite _hoverSprite = null;

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
        else
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
    }
}
