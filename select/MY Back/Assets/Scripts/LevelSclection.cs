using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSclection : MonoBehaviour
{
    [SerializeField] private bool unlocked;//Default value is false；
    public Image unlockImage;
    public GameObject[] starts;

    private void Update()
    {
        UpdateLevelImage();
        UpdateLevelStatus();
        
    }
    private void UpdateLevelStatus()
    {
        //if the current lv is 5, the pre should be 4;
        int previousLevelNum=int.Parse(gameObject.name)-1;
        if(PlayerPrefs.GetInt("Lv"+previousLevelNum)>0)//if the first level star is bigger than 0,second lecel can play;
        {
            unlocked=true;
        }

    }


    private void UpdateLevelImage()
    {
        if (!unlocked)//if unloocked is false ,means it is clocked;
        {
            unlockImage.gameObject.SetActive(true);
            for (int i = 0; i < starts.Length; i++)
            {
                starts[i].gameObject.SetActive(false);
            }
        }
        else//if unlock is ture means the level can play;
        {
            unlockImage.gameObject.SetActive(false);
            for (int i = 0; i < starts.Length; i++)
            {
                starts[i].gameObject.SetActive(true);
            }
        }
    }
    public void PressSelection(string _levelName)//when you press this level ,we can move to this scene;
    {
        if (unlocked)
        SceneManager.LoadScene(_levelName);
    }



}
