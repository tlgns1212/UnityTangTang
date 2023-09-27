using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectManager
{
    public PlayerController Player { get; private set; }
    public HashSet<MonsterController> Monsters { get; } = new HashSet<MonsterController>();
    public HashSet<ProjectileController> Projectiles{ get; } = new HashSet<ProjectileController>();
    public HashSet<GemController> Gems{ get; } = new HashSet<GemController>();
    
    public T Spawn<T>(Vector3 position, int templateID = 0) where T : BaseController
    {
        System.Type type = typeof(T);

        if(type == typeof(PlayerController))
        {
            // TODO : Data
            GameObject go = Managers.Resource.Instantiate("Slime_01.prefab",pooling:true);
            go.name = "Player";
            go.transform.position = position;

            PlayerController pc= go.GetOrAddComponent<PlayerController>();
            Player = pc;
            pc.Init();

            return pc as T;
        }
        else if(type == typeof(MonsterController))
        {
            string name = (templateID == 0 ? "Goblin_01" : "Snake_01");
            GameObject go = Managers.Resource.Instantiate(name + ".prefab", pooling: true);
            go.transform.position = position;

            MonsterController mc = go.GetOrAddComponent<MonsterController>();
            Monsters.Add(mc);
            mc.Init();

            return mc as T;
        }
        else if(type == typeof(GemController))
        {
            GameObject go = Managers.Resource.Instantiate(Define.EXP_GEM_PREFAB, pooling: true);
            go.transform.position = position;

            GemController gc = go.GetOrAddComponent<GemController>();
            Gems.Add(gc);
            gc.Init();

            string key = Random.Range(0, 2) == 0 ? "EXPGem_01.sprite" : "EXPGem_02.sprite";
            Sprite sprite = Managers.Resource.Load<Sprite>(key);
            go.GetComponent<SpriteRenderer>().sprite = sprite;

            //TEMP
            GameObject.Find("@Grid").GetComponent<GridController>().Add(go);

            return gc as T;
        }
        else if(typeof(T).IsSubclassOf(typeof(ProjectileController)))
        {
            GameObject go = Managers.Resource.Instantiate("FireProjectile.prefab", pooling: true);
            go.transform.position = position;

            ProjectileController pc = go.GetOrAddComponent<ProjectileController>();
            Projectiles.Add(pc);
            pc.Init();

            return pc as T;
        }

        return null;
    }

    public void Despawn<T>(T obj) where T : BaseController
    {
        if(obj.IsValid() == false)
        {
            int a = 3;
        }

        System.Type type = typeof(T);

        if(type == typeof(PlayerController))
        {
            // ?
        }
        else if(type == typeof(MonsterController))
        {
            Monsters.Remove(obj as MonsterController);
            Managers.Resource.Destroy(obj.gameObject);
        }
        else if(type == typeof(GemController))
        {
            Gems.Remove(obj as GemController);
            Managers.Resource.Destroy(obj.gameObject);

            //TEMP
            GameObject.Find("@Grid").GetComponent<GridController>().Remove(obj.gameObject);
        }
        else if (typeof(T).IsSubclassOf(typeof(ProjectileController)))
        {
            Projectiles.Remove(obj as ProjectileController);
            Managers.Resource.Destroy(obj.gameObject);
        }
    }
}
