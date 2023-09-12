using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject[] objects;
    public int[] numbers;
    //как много экземпл€ров этих объектов мы хотим создать 

    public List<GameObject>[] pool;
    //создаем типа List список
    void Start()
    {
        Instantiate();
    }

    void Instantiate()
    {
        GameObject temp;
        pool = new List<GameObject>[objects.Length];
        //создаетс€ List (array) наших объектов
        for (int count = 0; count < objects.Length; count++)
        {
            pool[count] = new List<GameObject>();
            //создаетс€ лист (множество их) внутри них
            for (int num = 0; num < numbers[count]; num++)
            {
                temp = Instantiate(objects[count]);
                temp.transform.parent = this.transform;
                //в иерархии все созданные объекты станут дочерними дл€ GameObject с этим скриптом Pool

                pool[count].Add(temp);
                //добавл€ем наши instantiating objects в нашу переменную -> и мы сможем это контролировать
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
        //(pool[id].Count -1) - находит последний индекс (объект) (как FindLast()
        //пытаемс€ получить последний объект из списка (списка сферы напрмер)
        pool[id][pool[id].Count - 1].transform.rotation = rotation;

        pool[id][pool[id].Count - 1].transform.parent = this.transform;

        return pool[id][pool[id].Count - 1];
        //добавл€ет новый объект, если его numbers не хватает (если его кол-во загруженных не хватает)
    }

    public void deActivate(GameObject deActivateObject)
    {
        deActivateObject.SetActive(false);
    }
}
