using NUnit.Framework;
using EasySaveProject.LanguageFolder;

namespace Unit_test
{
    [TestFixture]
    public class LanguageTest
    {
        private LanguageManager languageManager;

        [SetUp]
        public void Setup()
        {
            // Initialize your LanguageManager class
            languageManager = new LanguageManager();
        }

        [Test]
        public void SwitchLanguage_ToFrench_ShouldSwitchToFrench()
        {
            // Arrange
            var frenchLanguage = Languages.FRENCH; // Assuming Languages is an enum with FRENCH and ENGLISH

            // Act
            languageManager.SwitchLanguages(frenchLanguage);

        }

        [Test]
        public void SwitchLanguage_ToEnglish_ShouldSwitchToEnglish()
        {
            // Arrange
            var englishLanguage = Languages.ENGLISH; // Assuming Languages is an enum with FRENCH and ENGLISH

            // Act
            languageManager.SwitchLanguages(englishLanguage);

        }
    }
}
