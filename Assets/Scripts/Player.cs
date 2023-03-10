using UnityEngine;

public class Player : MonoBehaviour
{
    public Hand handPrefab;

    public float actionPoints;

    public float turnTime;

    public Hand hand;

    public string playerName;

    public float points;
    public int drawActionPoints = 1;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    public void MakeHand() {
        hand = Instantiate(handPrefab);
    }

    // Update is called once per frame
    private void Update()
    {
    }


    public void HideHand()
    {
        hand.Hide();
    }

    public void ShowHand()
    {
        hand.Show();
    }


    public bool PlayCard(Card card)
    {
        var new_points = actionPoints - card.actionPoints;
        if (new_points < 0) return false;
        actionPoints = new_points;
        NotifyActionPointsChanged();
        return true;
    }


    public bool DrawCard(Card card, bool usePoints = true)
    {   
        if (!usePoints) {
            Debug.Log($"Points {card.actionPoints}");
            hand.AddCard(card, this);
            return true;
        }
        var new_points = actionPoints - drawActionPoints;
        if (new_points < 0) return false;
        actionPoints = new_points;
        NotifyActionPointsChanged();
        hand.AddCard(card, this);
        return true;
    }


    public void NotifyActionPointsChanged() {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().NotifyActionPointsChanged();
    }
}