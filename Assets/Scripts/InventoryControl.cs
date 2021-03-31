using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

public class InventoryControl : MonoBehaviour
{
    public static event Action FadeIng;
    public static event Action<bool> CoinAnim;

    [SerializeField] List<BaseItemData> InitItems;
    public static List<PresenterCell> buttons = new List<PresenterCell>();

    [SerializeField] PresenterCell cell;
    [SerializeField] Transform panel;
    [SerializeField] Text Descriptor;
    [SerializeField] Text CoinDump;


    private void Start()
    {
        Viewer();
    }

    public void Viewer()
    {
        foreach (Transform child in panel)
            Destroy(child.gameObject);

        foreach (BaseItemData i in InitItems)
        {
            NewButton(i);
        }
    }

    public void OnCellClick(string desc)
    {
        Descriptor.text = desc;
    }

    public void NewButton(BaseItemData item)
    {
        PresenterCell button = Instantiate(cell, panel);
        button.DecriptorEvent += OnCellClick;
        button.Init(item);


        if (item is Money)
        {
            button.amount--;
            StartCoroutine(CoinRoutine(item as Money, button));
        }

        buttons.Add(button);
    }

    public void Adding(BaseItemData item)
    {
        bool flag = buttons.Count == 0 ? true : false;

        foreach (PresenterCell b in buttons)
        {
            if (item.prefab == b.prefab && b.maxSize > 1 && b.amount < b.maxSize)
            {
                if (item is Money)
                {
                    StartCoroutine(CoinRoutine(item as Money, b));
                }
                else
                {
                    b.amount++;
                    b.ReCount();
                }

                flag = false;
                break;
            }
            else
                flag = true;
        }

        if (flag)
        {
            NewButton(item);
        }
    }

    IEnumerator CoinRoutine(Money item, PresenterCell button)
    {
        FadeIng?.Invoke();

        for (int i = 0; i < item.Quantity; i++)
        {
            button.amount++;
            button.ReCount();
            ReDump(CoinDump, button.amount);

            yield return new WaitForSeconds(item.Quantity / (item.Quantity * 2F));
        }

        
    }

    public void ReDump(Text holdPlace, int value)
    {
        CoinAnim?.Invoke(true);

        holdPlace.text = value.ToString();
    }
    
}