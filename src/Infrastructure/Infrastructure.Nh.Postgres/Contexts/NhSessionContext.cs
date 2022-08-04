namespace Infrastructure.Nh.Postgres.Contexts;

public abstract class NhSessionContext
{
    public abstract NhSession CurrentSession { get; set; }

    public abstract NhSession ClearCurrentSession();
}