using UnityEngine;

public class SetInitialRotationTowardsTarget : MonoBehaviour
{

    [SerializeField] private string _targetName;
    [SerializeField] private Vector3 _randomOffset;
    
    void Start()
    {
        GameObject targetObject = GameObject.Find(_targetName);
        if (targetObject == null)
        {
            Debug.Log($"Target not found");
            return;
        }
        Vector3 direction = targetObject.transform.position - transform.position;
        direction += new Vector3(Random.Range(-_randomOffset.x, _randomOffset.x),
            Random.Range(-_randomOffset.y, _randomOffset.y),
            Random.Range(-_randomOffset.z, _randomOffset.z));
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }
    
}
