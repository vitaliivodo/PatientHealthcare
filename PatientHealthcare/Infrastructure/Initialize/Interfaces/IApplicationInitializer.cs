namespace PatientHealthcare.Infrastructure.Initialize.Interfaces
{
    public interface IApplicationInitializer
    {
        Task<int> Initialize();
    }
}
