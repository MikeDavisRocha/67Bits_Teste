using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _backpackTransform;
    [SerializeField] private GameObject _initialDeadEnemyPrefab;
    [SerializeField] private GameObject _deadEnemyPrefab;

    private static float _increment = 0f;

    public void StackEnemy()
    {
        StartCoroutine(StackEnemyCoroutine());
    }

    private IEnumerator StackEnemyCoroutine()
    {
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
        GameObject deadEnemy = Instantiate(_deadEnemyPrefab, _backpackTransform);        
        if (_backpackTransform.childCount == 1)
        {
            deadEnemy.GetComponent<ConfigurableJoint>().connectedBody = _initialDeadEnemyPrefab.GetComponent<Rigidbody>();
        }
        else
        {
            int index = _backpackTransform.childCount - 2;
            deadEnemy.GetComponent<ConfigurableJoint>().connectedBody = _backpackTransform.GetChild(index).GetComponent<Rigidbody>();
        }
        deadEnemy.transform.SetParent(_backpackTransform);
        deadEnemy.transform.position = SetDeadEnemyPosition(deadEnemy.transform.position);
        _increment += 0.5f;
    }

    private Vector3 SetDeadEnemyPosition(Vector3 enemyPosition)
    {
        return new Vector3(enemyPosition.x, enemyPosition.y + _increment, enemyPosition.z);
    }
}