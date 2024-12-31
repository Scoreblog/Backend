using ScoreBlog.Domain.Entities.Geography;
using ScoreBlog.Domain.Enums;

namespace ScoreBlog.Tests.Red.Domain.Entities;

public class StateCountryTests
{
    [Fact]
    public void Country_And_State_Should_Be_Invalid_When_Properties_Are_Invalid()
    {
        // Arrange: Criar um UniqueName inválido para o Country (nome vazio)
        var countryName = new UniqueName(""); // Nome vazio é inválido
        var continent = EContinent.America;
            
        // Criar um State inválido com nome vazio e sem um país válido
        var stateName = new UniqueName(""); // Nome vazio é inválido
        var state = new State(stateName, new Country(countryName, continent, new List<State>()), new List<City>());
            
        // Criar um Country inválido com nome vazio
        var country = new Country(countryName, continent, new List<State> { state });

        // Act & Assert: Verificar que o Country e State são inválidos
        Assert.False(country.IsValid); // O objeto Country deve ser inválido
        Assert.False(state.IsValid);   // O objeto State deve ser inválido
        Assert.Contains(country.Notifications, n => n.Message == "Name cannot be null or empty"); // Mensagem de erro para o nome do país
        Assert.Contains(state.Notifications, n => n.Message == "Name cannot be null or empty"); // Mensagem de erro para o nome do estado
    }
}