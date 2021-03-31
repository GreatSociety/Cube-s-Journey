using System;
using UnityEngine;
using UnityEngine.UI;

public class PresenterCell : MonoBehaviour
{
    [SerializeField] Text _name;

    [SerializeField] Image _icon;

    [SerializeField] public GameObject prefab;  // ����� ����� �� ���� ����� ������, ������ �������� ��� �������������

    [SerializeField] Text amounter;

    public int maxSize;

    public event Action<string> DecriptorEvent;

    public int amount = 1; // ���������� �������

    public string temp;


    public void Init(BaseItemData item) // ������ ��������� View, ������������, �.�. ��� ���������������� � ������, �.�. ��� �� ������ View ������������
    {
        _name.text = item.Title;
        temp = item.Decription;
        _icon.sprite = item.Icon;
        prefab = item.prefab;
        maxSize = (item is StackItem) ? (item as StackItem).maxSize : 1;
        ReCount();
    }

    // �����, ������� ���������� �� ������� �� Drop
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