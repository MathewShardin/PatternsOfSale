/**
 * Interface ensures subscribers can recieve updates (game ticks). Part of observer pattern
 */
public interface TimeListener {
    void updateTick(int unixStamp);
}

