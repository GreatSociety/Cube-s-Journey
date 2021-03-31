using System;
using UnityEngine;
using UnityEngine.UI;

public class PresenterCell : MonoBehaviour
{
    [SerializeField] Text _name;

    [SerializeField] Image _icon;

    [SerializeField] public GameObject prefab;  // Сразу здесь же даем знать ячейке, какому предмету она соответствует

    [SerializeField] Text amounter;

    public int maxSize;

    public event Action<string> DecriptorEvent;

    public int amount = 1; // Количество добавил

    public string temp;


    public void Init(BaseItemData item) // Раньше назывался View, переименовал, т.к. уже инициализируется и префаб, т.е. уже не только View определяется
    {
        _name.text = item.Title;
        temp = item.Decription;
        _icon.sprite = item.Icon;
        prefab = item.prefab;
        maxSize = (item is StackItem) ? (item as StackItem).maxSize : 1;
        ReCount();
    }

    // Метод, который вызывается по нажатию на Drop
    public void OnDropButtonClick()
    {
        Instantiate(prefab, PlayerController.DropPosition, Quaternion.identity);

        amount--;
        ReCount();

        if (amount <= 0)
        {
            InventoryControl.buttons.Remove(gameObject.GetComponent<PresenterCell>());
            Destroy(gameObject);
        }
    }

    public void OnClick()
    {
        DecriptorEvent?.Invoke(temp);
    }

    public void ReCount()
    {
        amounter.text = amount.ToString();
    }
}