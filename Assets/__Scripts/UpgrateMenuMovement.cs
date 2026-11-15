using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.Mathematics;


public class UpgrateMenuMovement : MonoBehaviour
{
    private event Action<int> TabSelected;

    [SerializeField] private RectTransform _contentContainer;
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private float _snapSpeed = 10;

    public int SelectedTabIndex => _selectedTabIndex;

    private readonly List<float> _itemPositionNormalized = new List<float>();
    private float _targetScrollBarValueNormalized = 0;
    private float _itemSizeNormalized;
    private int _selectedTabIndex = 0;

    private void Start()
    {
        Recalculate();
    }

    public void SelectTab(int tabIndex)
    {
        if (tabIndex < 0 || tabIndex >= _itemPositionNormalized.Count) 
        { 
            return; 
        }

        _selectedTabIndex = tabIndex;
        _targetScrollBarValueNormalized = _itemPositionNormalized[tabIndex];
        
        TabSelected?.Invoke(tabIndex);
    }
    public void Recalculate()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(_contentContainer);

        _itemPositionNormalized.Clear();

        int itemsCount = _contentContainer.childCount;
        _itemSizeNormalized = 1f / (itemsCount - 1f);

        for (int i = 0; i < itemsCount; i++)
        {
            var itemPositionNormalized = _itemSizeNormalized * i;

            _itemPositionNormalized.Add(itemPositionNormalized);
        }
    }

    private void SnapContent()
    {
        if (_itemPositionNormalized.Count < 2) return;

        float targetPosition = _itemPositionNormalized[_selectedTabIndex];
        _scrollbar.value = Mathf.Lerp(_scrollbar.value, targetPosition, Time.deltaTime * _snapSpeed);

        if (Mathf.Abs(_scrollbar.value - targetPosition) <= 0.0001f)
        {
            _scrollbar.value = targetPosition;
        }
    }
}
