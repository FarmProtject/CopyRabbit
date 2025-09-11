using UnityEngine;

public class StringKey_UI : StringKey
{
    string stringId;
    private void OnEnable()
    {
        AddingKeys();
        Set_MyText();
        Set_MyTMP();
    }
    private void Awake()
    {
        Name_ToKey();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Name_ToKey()
    {
        myKey = this.gameObject.name;
    }
}
