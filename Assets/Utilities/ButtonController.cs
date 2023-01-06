using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Image _image = null;

    [SerializeField] private Sprite _idleSprite = null;
    [SerializeField] private Sprite _hoverSprite = null;

    public void SpriteChange()
    {

        this.GetComponent<Image>().sprite = _idleSprite;
    }
}
