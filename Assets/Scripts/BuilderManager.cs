using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuilderManager : MonoBehaviour
{
    public static BuilderManager Instance {get; private set;}
    private Camera mainCam;

    [SerializeField]
    private Transform mouseVisualTrm;
    [SerializeField]
    private Transform woodPrefabTrm;

    // ���� ���ҽ� �ε�
    private BuildingTypeSO activeBuildingType;
    private BuildingTypeListSO buildingTypeList;

    private void Awake()
    {
        Instance = this;

        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        activeBuildingType = buildingTypeList.btList[0];
    }

    void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        // ���콺 ���ʹ�ư Ŭ���ϸ� ��Ȯ�� ����
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            /// mouseVisualTrm.position = GetMouseWorldPos();
            Instantiate(activeBuildingType.prefab, GetMouseWorldPos(), Quaternion.identity);
        }

        // �ӽ�Ű �������� ��Ȯ�⸦ �ٲ㺸��
        if (Input.GetKeyDown(KeyCode.Q))
        {
            activeBuildingType = buildingTypeList.btList[0];
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            activeBuildingType = buildingTypeList.btList[1];
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            activeBuildingType = buildingTypeList.btList[2];
        }
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingType)
    {
        activeBuildingType = buildingType;
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        return mouseWorldPos;
    }
}
