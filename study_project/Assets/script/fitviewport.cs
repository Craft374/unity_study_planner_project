using UnityEngine;

public class FitViewport : MonoBehaviour
{
    public RectTransform viewport;
    public RectTransform up;

    void Start()
    {
        GameObject viewObj = GameObject.Find("Viewport");
        if (viewObj != null)
        {
            viewport = viewObj.GetComponent<RectTransform>();
        }
        GameObject upObj = GameObject.Find("up");
        if (upObj != null)
        {
            up = upObj.GetComponent<RectTransform>();
        }
        // 시작할 때 한 번 Viewport 크기와 위치 조절
        ResizeViewport();
    }

    // Viewport 크기와 위치 조절
    public void ResizeViewport()
    {
        if (viewport != null)
        {
            // 화면 크기
            float currentScreenWidth = Screen.width;
            float currentScreenHeight = Screen.height;
            Debug.Log($"{currentScreenWidth} x {currentScreenHeight}");

            //n계산
            float n = 9f * currentScreenHeight / currentScreenWidth;
            Debug.Log($"9*현y/현x = {n}");

            // bottom 값
            float bo = 960f - 60f * n;
            Debug.Log($"960 - 60n = {bo}");

            // PosY랑 Top
            float upPosY = 60f * n - 960f;
            Debug.Log($"60n - 960 = {upPosY}");

            // Viewport 크기 설정
            viewport.sizeDelta = new Vector2(currentScreenWidth, currentScreenHeight);

            // bo값이랑 pos_y 입력
            viewport.offsetMin = new Vector2(viewport.offsetMin.x, bo);
            viewport.offsetMax = new Vector2(viewport.offsetMax.x, upPosY);

            

            // up y좌표
            up.localPosition = new Vector3(up.localPosition.x, upPosY, up.localPosition.z);
        }
    }
}
