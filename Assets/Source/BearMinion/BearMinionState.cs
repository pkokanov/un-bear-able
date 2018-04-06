
public class BearMinionState: State<BearMinionScript> {
    public BearMinionState(BearMinionScript playerMinion): base(playerMinion) {
        this.owner = playerMinion;
    }
}