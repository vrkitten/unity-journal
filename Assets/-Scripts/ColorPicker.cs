using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IColorable
{
    void SetObjectColor(Color color);
}

[System.Serializable]
public struct ColorSprite
{
    public Color color;
    public Sprite sprite;
}

public class ColorPicker : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform buttonGrid;
    public ColorSprite[] colorSprites;

    private void Start()
    {
        // Loop through the colorSprites array and create a button for each one
        for (int i = 0; i < colorSprites.Length; i++)
        {
            ColorSprite colorSprite = colorSprites[i];
            GameObject buttonGO = Instantiate(buttonPrefab, buttonGrid);
            Button button = buttonGO.GetComponent<Button>();
            Image image = buttonGO.GetComponent<Image>();

            // Set the button's color and sprite and add a listener to change the color or sprite of any object that implements IColorable
            image.color = colorSprite.color;
            image.sprite = colorSprite.sprite;
            button.onClick.AddListener(() =>
            {
                IColorable[] colorableObjects = (IColorable[])FindObjectsOfType(typeof(IColorable));
                foreach (IColorable colorableObject in colorableObjects)
                {
                    colorableObject.SetObjectColor(colorSprite.color);
                }
            });
        }
    }
}
