using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalPaper : MonoBehaviour, IColorable
{
    public SpriteRenderer paperSprite;
    public Image paperImage;

    public void SetObjectColor(Color color)
    {
        paperSprite.color = color;
    }

    public void SetObjectSprite(Sprite sprite)
    {
        paperImage.sprite = sprite;
    }
}
