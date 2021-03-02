using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public List<CombatCharacter> members;
    public List<Entity> onStart;
    [SerializeField] Transform objectContainer;

    private void Awake()
    {
        members = new List<CombatCharacter>();
        for(int i = 0; i < onStart.Count; i++)
        {
            AddCharacter(onStart[i]);
        }
    }

    public void AddCharacter(Entity entity)
    {
        GameObject go = Instantiate(entity.model);
        go.transform.parent = objectContainer;
        go.GetComponent<Character>().Init(entity);
        members.Add(go.GetComponent<CombatCharacter>());
    }
}
