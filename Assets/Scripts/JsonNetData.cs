using System;
using System.Collections.Generic;

public class InstantCompleteRequirement {
    public string type;
    public int id;
    public int quantity;
}
public class ActiveSession {
    public int id;
    public double started_at;
    public int speedup_applied;
    public double ends_at;
    public List<InstantCompleteRequirement> instant_complete_requirements;
}

[Serializable]
public class Investment {
    public string type;
    public int id;
    public int quantity;
}

[Serializable]
public class Outcome {
    public string type;
    public int id;
    public int quantity;
}

[Serializable]
public class Session {
    public int id;
    public string title;
    public string description;
    public int level_unlock;
    public int required_time;
    public List<Investment> investment;
    public List<Outcome> outcome;
}

[Serializable]
public class NetData {
    public ActiveSession active_session;
    public List<Session> sessions;
}
