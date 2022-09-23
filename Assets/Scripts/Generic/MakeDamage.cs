using UnityEngine;
using UnityEngine.Events;

// Makes damage to a GameObject containing a Health script
public class MakeDamage : MonoBehaviour
{
    [SerializeField] private int _damagePower = 10;
    [SerializeField] private string _tagToCompare = "Player";
    [SerializeField] private UnityEvent OnTrigger;
    [SerializeField] private bool _logTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagToCompare))
        {
            if (other.TryGetComponent(out Health health))
            {
                if(_logTrigger)
                    Messenger.Instance.EnqueueMessage($"Trigger with {other.name}", 3);
                if (health.enabled)
                {
                    health.ReceiveDamage(_damagePower);
                    OnTrigger?.Invoke();    
                }
            }
            else
            {
                Debug.LogWarning($"Health Component not found");
            }
        }
    }
}
