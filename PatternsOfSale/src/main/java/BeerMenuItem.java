/**
 * An item that can be ordered in an Assignment or can be picked by Player Kitchen
 */
public class BeerMenuItem implements MenuItemInterface {
    private double price = 10;

    public BeerMenuItem() {}

    @Override
    public double getPrice() {
        return this.price;
    }
}
