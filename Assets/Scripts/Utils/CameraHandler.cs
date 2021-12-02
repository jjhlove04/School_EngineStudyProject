using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{
   [SerializeField]
   private CinemachineVirtualCamera cinemachineVirtualCamera;
   private float orthographicSize;
   private float targetOthSize;
   const float minOthoSiz = 2f;
   const float maxOthoSize = 15f;
    private void Start() {
        orthographicSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        orthographicSize = 10f;
    }
   private void Update() {

       HandleMoveMent();

       HandleZoom();

   }

    public void HandleMoveMent()
    {
        //기본 이동
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x,y).normalized;
        float speed = 30;

        transform.position += moveDir * speed *Time.deltaTime;
    }

   public void HandleZoom()
   {
       float zoomAmount = 2f;
       targetOthSize += Input.mouseScrollDelta.y * zoomAmount;
       targetOthSize = Mathf.Clamp(targetOthSize, minOthoSiz, maxOthoSize);

       //부드러운 느낌 주기 위한 코드
       float zoomSpeed = 5f;
       orthographicSize = Mathf.Lerp(orthographicSize, targetOthSize, Time.deltaTime * zoomSpeed);

       cinemachineVirtualCamera.m_Lens.OrthographicSize = orthographicSize;

   }
}
