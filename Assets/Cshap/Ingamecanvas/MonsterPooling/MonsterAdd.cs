using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class MonsterAdd : MonoBehaviour
{
    [SerializeField]
    private GameObject _SlotPrefab;

    public IObjectPool<Monster> _Pool;

    private void Awake(){
        _Pool = new ObjectPool<Monster>(CreateSlot, OnGetSlot, OnReleaseSlot, OnDestroySlot, maxSize:20);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void InputInfo(){
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var slot = _Pool.Get();
        }
        
    }

    private Monster CreateSlot(){
        Monster slot = Instantiate(_SlotPrefab, gameObject.transform.GetChild(0).gameObject.transform).GetComponent<Monster>();
        slot.SetManagedPool(_Pool);
        return slot;
    }

    private void OnGetSlot(Monster slot)
    {
        slot.gameObject.SetActive(true);
    }

    private void OnReleaseSlot(Monster slot)
    {
        slot.gameObject.SetActive(false);
    }
    private void OnDestroySlot(Monster slot)
    {
        Destroy(slot.gameObject);
    }
}
