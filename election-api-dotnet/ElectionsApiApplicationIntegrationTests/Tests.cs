using ElectionsApiApplication.Controllers;
using ElectionsApiApplication.Models;
using ElectionsApiApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.IO;
using System.Reflection;
using System.Text.Json;
using Xunit;

namespace ElectionsApiApplicationIntegrationTests
{
    public class Tests
    {
        private ResultsController Controller { get; set; }

        private Mock<IResultService> MockedResultService { get; set; }

        public Tests()
        {
            MockedResultService = new Mock<IResultService>();

            Controller = new ResultsController(MockedResultService.Object);
        }


        [Fact]
        public void First5Test()
        {
            Scoreboard? scoreboard = RunTest(5);


            Assert.NotNull(scoreboard);
            // assert LD == 1
            // assert LAB = 4
            // assert winner = noone

        }

        [Fact]
        public void First100Test()
        {
            Scoreboard? scoreboard = RunTest(100);

            Assert.NotNull(scoreboard);
            // assert LD == 12
            // assert LAB == 56
            // assert CON == 31
            // assert winner = noone
        }

        [Fact]
        public void First554Test()
        {
            Scoreboard? scoreboard = RunTest(554);

            Assert.NotNull(scoreboard);
            // assert LD == 52
            // assert LAB = 325
            // assert CON = 167
            // assert winner = LAB
        }

        [Fact]
        public void AllTest()
        {
            Scoreboard? scoreboard = RunTest(650);

            Assert.NotNull(scoreboard);
            // assert LD == 62
            // assert LAB == 349
            // assert CON == 210
            // assert winner = LAB
            // assert sum = 650
        }

        private Scoreboard? RunTest(int numberOfResults)
        {
            MockedResultService.Object.Reset();

            for (int i = 1; i <= numberOfResults; i++)
            {
                var text = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), string.Format("sample-election-results/result{0}.json", i.ToString("D3"))));

                var constituencyResult = JsonSerializer.Deserialize<ConstituencyResult>(text, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (constituencyResult != null)
                {
                    Controller.NewResult(constituencyResult);
                }
            }

            var scoreboard = ((ObjectResult) Controller.GetScoreboard()).Value;


            return scoreboard as Scoreboard ?? null;
        }
    }
}