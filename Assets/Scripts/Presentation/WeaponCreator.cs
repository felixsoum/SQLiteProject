using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WeaponCreator : MonoBehaviour
{
    [SerializeField] InputField nameInput;
    [SerializeField] InputField costInput;

    private void Awake()
    {
        WeaponDao.DatabasePath = "URI=file:" + Application.dataPath + "/Databases/Weapons.db";
    }

    public void Create()
    {
        WeaponDao.Insert(nameInput.text, int.Parse(costInput.text));
        SceneManager.LoadScene("Read");
    }
}
