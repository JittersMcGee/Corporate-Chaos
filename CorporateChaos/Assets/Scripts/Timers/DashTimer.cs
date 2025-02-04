using UnityEngine;

public class DashTimer : MonoBehaviour
{
    #region Fields

    //timer duration
    float totalSeconds = 0;

    //timer execution
    float elapsedSeconds = 0;
    bool running = false;

    //support for finished property
    bool started = false;

    #endregion

    #region Properties

    /// <summary>
    /// sets duration of the timer
    /// duration can only be set if timer isn't running
    /// </summary>
    /// <value>duration</value>

    public float Duration
    {
        set
        {
            if (!running)
            {
                totalSeconds = value;
            }
        }
    }

    /// <summary>
	/// Gets whether or not the timer has finished running
	/// This property returns false if the timer has never been started
	/// </summary>
	/// <value>true if finished; otherwise, false.</value>
	public bool Finished
    {
        get { return started && !running; }
    }

    /// <summary>
	/// Gets whether or not the timer is currently running
	/// </summary>
	/// <value>true if running; otherwise, false.</value>
	public bool Running
    {
        get { return running; }
    }

    #endregion

    #region Methods

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= totalSeconds)
            {
                running = false;
            }
        }
    }

    // runs timer, because a timer of 0 duration doesn't make sense the timer only runs if total seconds is larger than 0
    // this also makes sure consumer of class has actually set timer higher than 0

    public void Run()
    {
        if (totalSeconds > 0)
        {
            started = true;
            running = true;
            elapsedSeconds = 0;
        }
    }
    #endregion
}
