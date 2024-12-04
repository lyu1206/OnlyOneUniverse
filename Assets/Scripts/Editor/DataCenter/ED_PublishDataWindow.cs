using System;
using UnityEditor;
using UnityEngine;

public class ED_PublishDataWindow : EditorWindow
{
    private string inputText = "Hello, Unity!";
    private Color selectedColor = Color.white;

    [MenuItem("Window/My Custom Editor Window")]
    public static void ShowWindow()
    {
        // EditorWindow 생성 및 표시
        var window = GetWindow<ED_PublishDataWindow>("My Editor");
        window.minSize = new Vector2(300, 200); // 창 크기 설정
    }

    private void OnEnable()
    {
        Debug.Log("Initialized Editor Window");
    }

    private void OnGUI()
    {
        // 사용자 인터페이스 요소 추가
        GUILayout.Label("This is my custom editor window!", EditorStyles.boldLabel);

        // 문자열 입력 필드
        inputText = EditorGUILayout.TextField("Input Text:", inputText);

        // 색상 선택기
        selectedColor = EditorGUILayout.ColorField("Select Color:", selectedColor);

        // 버튼
        if (GUILayout.Button("Print Message"))
        {
            Debug.Log($"Message: {inputText}, Color: {selectedColor}");
        }

        // 공간 추가
        GUILayout.Space(10);

        // 색상 박스
        EditorGUI.DrawRect(new Rect(10, 100, position.width - 20, 50), selectedColor);
    }
}
