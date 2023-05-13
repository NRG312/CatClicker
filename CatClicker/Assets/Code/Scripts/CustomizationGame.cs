using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationGame : MonoBehaviour
{
    public static CustomizationGame instance;

    [Header("CatImages")]
    public Image Ears;
   // public Image Mouth;

    [Header("LivingRoom")]
    public Image WallLiving;
    public Image FloorLiving;

    [Header("Toilet")]
    public Image WallToilet;
    public Image FloorToilet;

    [Header("Kitchen")]
    public Image WallKitchen;
    public Image FloorKitchen;
    public Image Bedding;
    public Image Bowl;

    private void Start()
    {
        instance = this;
    }
    //CatApperance
    public void ChangeApperanceCat(Sprite image,string type)
    {
        if (type == "Ears")
        {
            Ears.sprite = image;
        }
    }

    //Rooms
    public void CheckingTypeOfProduct(Sprite image, string Type)
    {
        if (Type == "WallKitchen" || Type == "FloorKitchen")
        {
            ChangeKitchen(image, Type);
        }
        else if (Type == "WallLivingRoom" || Type == "FloorLivingRoom")
        {
            ChangeLivingRoom(image, Type);
        }
        else if (Type == "WallToilet" || Type == "FloorToilet")
        {
            ChangeToilet(image, Type);
        }
    }
    public void ChangeLivingRoom(Sprite image, string Type)
    {
        if (Type == "WallLivingRoom")
        {
            WallLiving.sprite = image;
        }
        else if (Type == "FloorLivingRoom")
        {
            FloorLiving.sprite = image;
        }

    }
    public void ChangeKitchen(Sprite image, string Type)
    {
        if (Type == "WallKitchen")
        {
            WallKitchen.sprite = image;
        }
        else if (Type == "FloorKitchen")
        {
            FloorKitchen.sprite = image;
        }
    }
    public void ChangeToilet(Sprite image, string Type)
    {
        if (Type == "WallToilet")
        {
            WallToilet.sprite = image;
        }
        else if (Type == "FloorToilet")
        {
            FloorToilet.sprite = image;
        }
    }
}
