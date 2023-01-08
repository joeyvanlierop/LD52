using UnityEngine;

public class MoistCard : Card
{
    public GameObject MoistCrop;
    
    new void Start()
    {
        base.Start();
    }

    public override void ActionPerformed(Vector3Int position)
    {
        CropManager cm = GameObject.FindGameObjectWithTag("CropManager").GetComponent<CropManager>();
        cm.AddCrop(position, MoistCrop);
    }
    
    protected override bool IsValid(CropManager cm, Vector3Int position)
    {
        if (!cm.IsWaterTile(position))
            return false;

        if (cm.GetCrop(position, out var crop))
            return false;

        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (cm.GetOwner(position, out var owner) && owner != gm.currentPlayerIndex)
            return false;

        return true;
    }
}
