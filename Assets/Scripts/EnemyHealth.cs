using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Texture2D border;
    public Rect borderPosition;

    public Texture2D bar;
    public Rect barPosition;

    public float horizontalDistance;
    //�������, �� ������� ����� ������� ������ Bar (��������� ��� ������ ������� Border)
    public float verticalDistance;
    //�������, �� ������� ����� ������� ���� Bar (��������� ��� ������ ������� Border)

    public float wigthBar;
    public float heightBar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        drawFrame();
        drawBar();
    } 

    void drawFrame()
    {
        borderPosition.x = (Screen.width - borderPosition.width) / 2;
        float width = 0.26f;
        borderPosition.width = Screen.width * width;
        borderPosition.height = Screen.height * 0.04f;
        GUI.DrawTexture(borderPosition, border); // ���� ����� ������������ �������� �� ������
    }

    void drawBar()
    {
        //� Bar ������ �� �� �������, ��� � � Frame (border)
        barPosition.x = borderPosition.x + borderPosition.width * horizontalDistance;
        barPosition.y = borderPosition.y + borderPosition.height * verticalDistance;
        barPosition.width = borderPosition.width * wigthBar;
        barPosition.height = borderPosition.height * heightBar;
        GUI.DrawTexture(barPosition, bar);

    }
}
