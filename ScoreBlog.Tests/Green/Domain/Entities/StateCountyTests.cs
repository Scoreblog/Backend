using ScoreBlog.Domain.Entities.Geography;
using ScoreBlog.Domain.Enums;

namespace ScoreBlog.Tests.Green.Domain.Entities;

public class StateCountryTests
{
    [Fact]
    public void Country_And_State_Should_Be_Valid_When_Valid_Properties_Are_Provided()
    {
        // Arrange: Criar um UniqueName válido para o Country
        var countryName = new UniqueName("Brazil");
        var continent = EContinent.America;
            
        // Criar um State válido com nome e um país associado
        var stateName = new UniqueName("São Paulo");
        var state = new State(stateName, new Country(countryName, continent, new List<State>()), new List<City>());

        // Criar um Country válido com nome, continente e uma lista de estados
        var country = new Country(countryName, continent, new List<State> { state });

        // Act & Assert: Verificar que o Country e State são válidos
        Assert.True(country.IsValid); // O objeto Country deve ser válido
        Assert.True(state.IsValid);   // O objeto State deve ser válido
        Assert.Contains(country.States, s => s.Name == stateName); // O país deve conter o estado São Paulo
    }
}