using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject[] objects;
    public int[] numbers;
    //��� ����� ����������� ���� �������� �� ����� ������� 

    public List<GameObject>[] pool;
    //������� ���� List ������
    void Start()
    {
        Instantiate();
    }

    void Instantiate()
    {
        GameObject temp;
        pool = new List<GameObject>[objects.Length];
        //��������� List (array) ����� ��������
        for (int count = 0; count < objects.Length; count++)
        {
            pool[count] = new List<GameObject>();
            //��������� ���� (��������� ��) ������ ���
            for (int num = 0; num < numbers[count]; num++)
            {
                temp = Instantiate(objects[count]);
                temp.transform.parent = this.transform;
                //� �������� ��� ��������� ������� ������ ��������� ��� GameObject � ���� �������� Pool

                pool[count].Add(temp);
                //��������� ���� instantiating objects � ���� ���������� -> � �� ������ ��� ��������������
            }
        }
    }

    public GameObject activate(int id)
    {
        for (int count = 0; count < pool[id].Count; count++)
        {
            if (!pool[id][count].activeSelf)
            {
                pool[id][count].SetActive(true);
                return pool[id][count];
            }
        }
        pool[id].Add((GameObject)Instantiate(objects[id]));
        pool[id][pool[id].Count - 1].transform.parent = this.transform;
        return null;
    }
    public GameObject activate(int id, Vector3 position, Quaternion rotation)
    {
        for(int count = 0; count < pool[id].Count; count++)
        {
            if (!pool[id][count].activeSelf)
            {
            pool[id][count].SetActive(true);
            pool[id][count].transform.position = position;
            pool[id][count].transform.rotation = rotation;
            return pool[id][count];
            }
        }

        pool[id].Add((GameObject)Instantiate(objects[id]));
        pool[id][pool[id].Count -1].transform.position = position;
        //(pool[id].Count -1) - ������� ��������� ������ (������) (��� FindLast()
        //�������� �������� ��������� ������ �� ������ (������ ����� �������)
        pool[id][pool[id].Count - 1].transform.rotation = rotation;

        pool[id][pool[id].Count - 1].transform.parent = this.transform;

        return pool[id][pool[id].Count - 1];
        //��������� ����� ������, ���� ��� numbers �� ������� (���� ��� ���-�� ����������� �� �������)
    }

    public void deActivate(GameObject deActivateObject)
    {
        deActivateObject.SetActive(false);
    }
}
