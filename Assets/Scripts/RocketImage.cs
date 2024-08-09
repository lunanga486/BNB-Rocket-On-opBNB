using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketImage : MonoBehaviour
{
    public SpriteRenderer rocketImage;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;

    private void Start()
    {
        if (RocketChosen.Instance.GetChosenRocket() == 1)
        {
            rocketImage.sprite = sprite1;
        }
        else if (RocketChosen.Instance.GetChosenRocket() == 2)
        {
            rocketImage.sprite = sprite2;
        }
        else if (RocketChosen.Instance.GetChosenRocket() == 3)
        {
            rocketImage.sprite = sprite3;
        }
    }
}
