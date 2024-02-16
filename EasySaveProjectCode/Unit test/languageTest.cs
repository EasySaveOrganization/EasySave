using NUnit.Framework;
using EasySaveProject.LanguageFolder;
using EasySaveProject; 

namespace Unit_test
{
    [TestFixture]
    public class LanguageTest
    {
        private LanguageManager languageManager;

        [SetUp]
        public void Setup()
        {
            // Initialize LanguageManager class
            languageManager = new LanguageManager();
        }

        [Test]
        public void SwitchLanguage_ToFrench_ShouldSwitchToFrench()
        {
            // Arrange
            var frenchLanguage = Languages.FRENCH; 

            // Act
            languageManager.SwitchLanguages(frenchLanguage);

        }

        [Test]
        public void SwitchLanguage_ToEnglish_ShouldSwitchToEnglish()
        {
            // Arrange
            var englishLanguage = Languages.ENGLISH; 

            // Act
            languageManager.SwitchLanguages(englishLanguage);

        }
    }
}
