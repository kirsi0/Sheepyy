﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class ItemUI : MonoBehaviour
{

    #region Data
    public Item Item { get; private set; }
    public int Amount { get; private set; }
    public  char TAG { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    #endregion

    #region UI Component
    private Image itemImage;
    private Text amountText;
    private Text nameText;
    //private Text description;

    private Image ItemImage
    {
        get
        {
            if (itemImage == null)
            {
                itemImage = GetComponent<Image>();
            }
            return itemImage;
        }
    }
    private Text AmountText
    {
        get
        {
            if (amountText == null)
            {
                amountText = transform.Find("Amount").GetComponent<Text>();
            }
            return amountText;
        }
    }
    private Text NameText
    {
        get
        {
            if(nameText == null)
            {
                nameText = transform.Find("Name").GetComponent<Text>();
            }
            return nameText;
        }
    }
    #endregion

    private float targetScale = 1f;

    private Vector3 animationScale = new Vector3(1.4f, 1.4f, 1.4f);

    private float smoothing = 4;

    void Update()
    {
        if (transform.localScale.x != targetScale)
        {
            //动画
            float scale = Mathf.Lerp(transform.localScale.x, targetScale, smoothing * Time.deltaTime);
            transform.localScale = new Vector3(scale, scale, scale);
            if (Mathf.Abs(transform.localScale.x - targetScale) < .02f)
            {
                transform.localScale = new Vector3(targetScale, targetScale, targetScale);
            }
        }

    }

    public void SetItem(Item item, int amount = 1)
    {
       // Debug.Log("111");
        transform.localScale = animationScale;
        this.Item = item;
        this.Amount = amount;
        NameText.text = item.Name;
        this.Description = item.Description;
        ItemImage.sprite = Resources.Load<Sprite>(item.Sprite);
        if (Item.Capacity > 1)
            AmountText.text = Amount.ToString();
        else
            AmountText.text = "";
    }

    public void AddAmount(int amount = 1)
    {
        transform.localScale = animationScale;
        this.Amount += amount;
        //update ui 
        if (Item.Capacity > 1)
            AmountText.text = Amount.ToString();
        else
            AmountText.text = "";
    }
    public void ReduceAmount(int amount = 1)
    {
        transform.localScale = animationScale;
        this.Amount -= amount;
        //update ui 
        if (Item.Capacity > 1)
            AmountText.text = Amount.ToString();
        else
            AmountText.text = "";
    }
    public void SetAmount(int amount)
    {
        transform.localScale = animationScale;
        this.Amount = amount;
        //update ui 
        if (Item.Capacity > 1)
            AmountText.text = Amount.ToString();
        else
            AmountText.text = "";
    }

    //当前物品 跟 另一个物品 交换显示
    public void Exchange(ItemUI itemUI)
    {
        Item itemTemp = itemUI.Item;
        int amountTemp = itemUI.Amount;
        itemUI.SetItem(this.Item, this.Amount);
        this.SetItem(itemTemp, amountTemp);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetLocalPosition(Vector3 position)
    {
        transform.localPosition = position;
    }


}

