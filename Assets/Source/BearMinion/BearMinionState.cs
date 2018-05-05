
public class BearMinionState: State<BearMinionScript> {
    public BearMinionState(BearMinionScript bearMinion): base(bearMinion) {
        this.owner = bearMinion;
    }
}