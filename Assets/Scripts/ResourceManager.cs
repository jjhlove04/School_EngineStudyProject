using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    public Action OnResourceAmountChanged;
    private Dictionary<ResourceTypeSO, int> resourceAmountDic;

    private void Awake()
    {
        Instance = this;

        resourceAmountDic = new Dictionary<ResourceTypeSO, int>();

        ResourceTypeListSO resTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
        foreach(ResourceTypeSO resType in resTypeList.resList)
        {
            resourceAmountDic[resType] = 0;
        }

        TestLogResAmountDic();
    }

    private void Update()
    {
        
    }

    public void AddResource(ResourceTypeSO resType, int amount)
    {
        resourceAmountDic[resType] += amount;

        TestLogResAmountDic();
    }

    public int GetResourceAmount(ResourceTypeSO resType)
    {
        return resourceAmountDic[resType];
    }

    void TestLogResAmountDic()
    {
        foreach(ResourceTypeSO resType in resourceAmountDic.Keys)
        {
            print(string.Format("{0}:{1}", resType.nameStr, resourceAmountDic[resType]));
        }
    }
}
