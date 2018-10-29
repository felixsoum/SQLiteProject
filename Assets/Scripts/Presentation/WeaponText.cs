using UnityEngine;
using UnityEngine.UI;

public class WeaponText : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        WeaponDao.DatabasePath = "URI=file:" + Application.dataPath + "/Databases/Weapons.db";
        text = GetComponent<Text>();
        foreach (var weapon in WeaponDao.GetAll())
        {
            text.text += weapon + "\n";
        }
    }
}
