using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{

    GameObject[] _portions;
    int _currentIndex;

    void Start()
    {
        bool skipFirst = transform.childCount > 4;
        _portions = new GameObject[skipFirst ? transform.childCount-1 : transform.childCount];
        for (int i = 0; i < _portions.Length; i++)
        {
            _portions[i] = transform.GetChild(skipFirst ? i + 1 : i).gameObject;
            if (_portions[i].activeInHierarchy)
                _currentIndex = i;
        }
    }

    public void UpdateState()
    {
        Consume();
    }
    public void SetState(int newIndex){
        newIndex -= 1;
        Start();
        if (newIndex + 1 == _portions.Length){
            return;
        }
        for (int i = 0;  i < _portions.Length - newIndex - 1 ; i++){
            Consume();
        }
            
    }

    void Consume()
    {
//        Debug.Log(currentIndex);
        if (_currentIndex != _portions.Length)
            _portions[_currentIndex].SetActive(false);
        _currentIndex++;
        
        if (_currentIndex > _portions.Length)
            _currentIndex = 0;
        else if (_currentIndex == _portions.Length)
            return;
        _portions[_currentIndex].SetActive(true);
    }

}
