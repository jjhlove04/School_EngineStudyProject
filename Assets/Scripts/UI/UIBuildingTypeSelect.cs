using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIBuildingTypeSelect : MonoBehaviour
{
    private void Awake() {
        Transform btnTmpTrm = transform.Find("BtnTemplate");
        btnTmpTrm.gameObject.SetActive(false);

        BuildingTypeListSO buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);

        int index = 0;

        foreach(BuildingTypeSO buildingType in buildingTypeList.btList)
        {
            Transform btnTrm = Instantiate(btnTmpTrm, transform);
            btnTrm.gameObject.SetActive(true);

            //위치 적용

            float offsetAmount = 130f;
            btnTrm.GetComponent<RectTransform>().anchoredPosition =new Vector2(offsetAmount * index, 0);

            //이미지 적용
            btnTrm.Find("image").GetComponent<Image>().sprite = buildingType.sprite;

            //버튼 기능 함수
            btnTrm.GetComponent<Button>().onClick.AddListener(delegate()
            {
                BuilderManager.Instance.SetActiveBuildingType(buildingType);
            });
            
            
            
            index++;
        }
    }
}
