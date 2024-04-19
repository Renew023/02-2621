using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SlotAdd : MonoBehaviour
{
    [SerializeField]
    private GameObject _SlotPrefab;

    public IObjectPool<Slot> _Pool;

    private void Awake(){
        _Pool = new ObjectPool<Slot>(CreateSlot, OnGetSlot, OnReleaseSlot, OnDestroySlot, maxSize:20);
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

    private Slot CreateSlot(){
        Slot slot = Instantiate(_SlotPrefab, gameObject.transform.GetChild(0).gameObject.transform).GetComponent<Slot>();
        slot.SetManagedPool(_Pool);
        return slot;
    }

    private void OnGetSlot(Slot slot)
    {
        slot.gameObject.SetActive(true);
    }

    private void OnReleaseSlot(Slot slot)
    {
        slot.gameObject.SetActive(false);
    }
    private void OnDestroySlot(Slot slot)
    {
        Destroy(slot.gameObject);
    }
}
