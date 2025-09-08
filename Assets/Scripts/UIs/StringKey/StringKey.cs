using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class StringKey : MonoBehaviour
{
    protected UI_StringManager stringKey_Manager;
    protected TextMeshProUGUI myTmp;
    string myKey;
    string myText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_MyKey(string key)
    {
        myKey = key;
    }

    public void UpdateText()
    {
        Set_MyText();
        Set_MyTMP();
    }

    public void Set_MyText()
    {
        if (stringKey_Manager == null)
        {
            stringKey_Manager = GameManager._instance.Get_StringKeyManager();
        }
        if (myKey == null)
        {
            Debug.Log($"MyKey Null {this.gameObject.name}");
            return;
        }
        myText = stringKey_Manager.Get_StringData(myKey);
    }
    public void Set_MyTMP()
    {
        if(myTmp == null)
        {
            myTmp = Utils.GetOrAddComponent<TextMeshProUGUI>(this.gameObject);
        }
        myTmp.text = myText;
    }
}
