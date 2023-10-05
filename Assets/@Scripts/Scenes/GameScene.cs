using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    void Start()
    {
        Managers.Resource.LoadAllAsync<Object>("PreLoad", (key, count, totalCount) =>
        {
            Debug.Log($"{key} {count}/{totalCount}");

            if (count == totalCount)
            {
                StartLoaded();
            }
        });
    }

    SpawningPool _spawningPool;

    void StartLoaded()
    {
        //Data Text
        Managers.Data.Init();

        Managers.UI.ShowSceneUI<UI_GameScene>();

        _spawningPool = gameObject.AddComponent<SpawningPool>();

        var player = Managers.Object.Spawn<PlayerController>(Vector3.zero);

        for (int i = 0; i < 10; i++)
        {
            Vector3 randPos = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
            MonsterController mc = Managers.Object.Spawn<MonsterController>(randPos,Random.Range(0, 2));
        }
        var joystick = Managers.Resource.Instantiate("UI_Joystick.prefab");
        joystick.name = "@UI_Joystick";


        var map = Managers.Resource.Instantiate("Map_01.prefab");
        map.name = "@Map";
        Camera.main.GetComponent<CameraController>().Target = player.gameObject;

        foreach (var playerData in Managers.Data.PlayerDic.Values)
        {
            Debug.Log($"Lv : {playerData.level}, Hp : {playerData.maxHp}");
        }

        Managers.Game.OnGemCountChanged -= HandleOnGemCountChanged;
        Managers.Game.OnGemCountChanged += HandleOnGemCountChanged;
        Managers.Game.OnKillCountChanged -= HandleOnKillCountChanged;
        Managers.Game.OnKillCountChanged += HandleOnKillCountChanged;

    }

    int _collectedGemCount = 0;
    int _remainingTotalGemCount = 10;

    public void HandleOnGemCountChanged(int gemCount)
    {
        _collectedGemCount++;

        if (_collectedGemCount == _remainingTotalGemCount)
        {
            Managers.UI.ShowPopup<UI_SkillSelectPopup>();
            _collectedGemCount = 0;
            _remainingTotalGemCount *= 2;
        }

        Managers.UI.GetSceneUI<UI_GameScene>().SetGemCountRatio((float)_collectedGemCount / _remainingTotalGemCount);
    }

    public void HandleOnKillCountChanged(int killCount)
    {
        Managers.UI.GetSceneUI<UI_GameScene>().SetKillCount(killCount);

        if(killCount == 5)
        {
            // Boss
        }
    }

    private void OnDestroy()
    {
        if (Managers.Game != null)
            Managers.Game.OnGemCountChanged -= HandleOnGemCountChanged;
    }
}
