using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // << เพิ่มตรงนี้สำหรับ TextMeshPro

public class CodeMangaer : MonoBehaviour
{
    [SerializeField] private TMP_Text codeText;     // TextMeshPro-UGUI
    [SerializeField] private GameObject codePanel;  // Panel ทั้งก้อน
    [SerializeField] private float delaySeconds = 0.5f;

    private string codeTextValue = "";
    private bool isProcessing = false;

    void Start()
    {
        // ซ่อน panel ตอนเริ่มเกม
        if (codePanel != null)
            codePanel.SetActive(false);

        // เคลียร์ค่า text
        codeTextValue = "";
    }

    void Update()
    {
        codeText.text = codeTextValue;

        if (codePanel.activeSelf && !isProcessing && codeTextValue == "1234")
        {
            StartCoroutine(HandleCorrectCode());
        }

        if (codeTextValue.Length >= 4 && !isProcessing)
        {
            codeTextValue = "";
        }
    }

    public void AddDigit(string digit)
    {
        if (!isProcessing && codePanel.activeSelf)
            codeTextValue += digit;
    }

    private IEnumerator HandleCorrectCode()
    {
        isProcessing = true;
        yield return new WaitForSeconds(delaySeconds);

        movement_script.isSafeOpened = true;
        Debug.Log("รหัสถูกต้อง! เปิด safe แล้ว");

        // เมื่อเปิด safe แล้ว ให้ซ่อน panel ทันที
        codePanel.SetActive(false);

        codeTextValue = "";
        isProcessing = false;
    }
}
