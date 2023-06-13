using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationGame : MonoBehaviour
{
    public static CustomizationGame instance;

    [Header("CatImages")]
    public Image Ears;
    public Image Glasses;
    public Image Collars;
    public Image Hats;
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
        else if (type == "Hat")
        {
            if (!Hats.gameObject.activeInHierarchy)
            {
                Hats.gameObject.SetActive(true);
            }
            Hats.sprite = image;
        }
        else if (type == "Collar")
        {
            if (!Collars.gameObject.activeInHierarchy)
            {
                Collars.gameObject.SetActive(true);
            }
            Collars.sprite = image;
        }
        else if (type == "Glasses")
        {
            if (!Glasses.gameObject.activeInHierarchy)
            {
                Glasses.gameObject.SetActive(true);
            }
            Glasses.sprite = image;
        }
        
    }
    public void TakeOffApperanceItem(string type)
    {
        if (type == "Hat")
        {          
            Hats.gameObject.SetActive(false);           
        }
        else if (type == "Collar")
        {         
            Collars.gameObject.SetActive(false);          
        }
        else if (type == "Glasses")
        {
            Glasses.gameObject.SetActive(false);          
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
