// <summary>
/// Singleton Implemented with Eager loading
/// </summary>
public class EagerLoadingSingleton
{
    private static readonly EagerLoadingSingleton instance = new EagerLoadingSingleton();

    private EagerLoadingSingleton() { }

    public static EagerLoadingSingleton Instance => instance;
}

/// <summary>
/// SIngleton Implemented with Lazy loading
/// </summary>
public class LazyLoadingSingleton
{
    private static readonly Lazy<LazyLoadingSingleton> lazyInstance = new Lazy<LazyLoadingSingleton>(() => new LazyLoadingSingleton());

    private LazyLoadingSingleton() { }

    public static LazyLoadingSingleton Instance => lazyInstance.Value;
}

/// <summary>
/// SIngleton Implemented with double check locking
/// </summary>
public sealed class DoubleLockingSingleton
{
    private static DoubleLockingSingleton instance;
    private static readonly object lockObject = new object();

    private DoubleLockingSingleton() { }

    public static DoubleLockingSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new DoubleLockingSingleton();
                    }
                }
            }
            return instance;
        }
    }
}

/// <summary>
/// Singleton Implemented with the most basic knowledge of pattern
/// </summary>
public sealed class BasicSingleton
{
    private static BasicSingleton instance;

    private BasicSingleton() { }

    public static BasicSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BasicSingleton();
            }
            return instance;
        }
    }
}
