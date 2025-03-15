using System;

namespace YaEmuera.ViewModels.Services.Configuration;

public interface IConfigurationLocatorService
{
    public T RetrieveConfiguration<T>() where T : IConfigurationSettingsInstance
    {
        throw new NotImplementedException();
    }
}