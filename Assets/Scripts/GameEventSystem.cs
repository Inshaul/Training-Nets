public class GameEventSystem {
	public delegate void EventRaised(EVENT_TYPE type, System.Object data);
	public static event EventRaised GameEventHandler;
	public static void RaiseGameEvent(EVENT_TYPE type, System.Object data = null) {
		if (GameEventHandler != null) {
			GameEventHandler(type, data);
		}
	}
}

public enum EVENT_TYPE {
	NETS_UPDATE,    // nets in busy state
	NETS_COMPLETE,  // ready to collect
	NETS_INSTANT,   // nets in idle state
	NETS_COLLECT,   // to collect the tp
	START_TIMER,	// too start the timer script
}