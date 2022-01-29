using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaverData : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SaveUsersData);
    }

    public void SaveUsersData()
    {
        UserPreferences.Save();
    }
}
