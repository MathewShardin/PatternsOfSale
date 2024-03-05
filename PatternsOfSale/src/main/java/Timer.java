import java.util.ArrayList;

/**
 * Keeps track of the game time. Send game tick updates to subscribers. Ensures proper game state.
 */
public class Timer {
    /**
     * Keeps track of all objects that must receive updates about the in-game timer
     */
    private ArrayList<TimeListener> subscribers;

    public Timer() {
        this.subscribers = new ArrayList<>();
    }

    public ArrayList<TimeListener> getSubscribers() {
        return subscribers;
    }

    public void setSubscribers(ArrayList<TimeListener> subscribers) {
        this.subscribers = subscribers;
    }

    public void addSubscriber(TimeListener sub) {
        this.subscribers.add(sub);
    }

    public void removeSubscriber(TimeListener sub) {
        this.subscribers.remove(sub);
    }

    /**
     * Sends in-game tier information (in UnixStamp format) to all subscribers
     */
    public void sendTickUpdate() {
        for (TimeListener sub: this.subscribers) {
            //Iterate over each subscriber and activate method
            sub.updateTick(1); //TO DO SEND IN ACTUAL UNIX STAMP!!
        }
    }


}
