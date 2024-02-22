using System;
using System.IO;
using System.Text;

namespace cryptosoft
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Utilisation: cryptosoft <fichier_source> <fichier_destination>");
                return;
            }

            string sourceFile = args[0];
            string destinationFile = args[1];
            string logFile = "CryptosoftLogs.txt";

            LogMessage(logFile, "Fichier source : " + sourceFile);
            LogMessage(logFile, "Fichier destination : " + destinationFile);

            string keyFilePath = $"Key.txt";

            byte[] key = ReadEncryptionKey(keyFilePath);

            if (key == null || key.Length < 8)
            {
                LogMessage(logFile, "La clé de chiffrement n'est pas valide ou est trop courte.");
                return;
            }
            try
            {
                EncryptFile(sourceFile, destinationFile, key, logFile);
            }
            catch (Exception ex)
            {
                LogMessage(logFile, $"Une erreur s'est produite pendant le chiffrement/déchiffrement: {ex.Message}");
                LogMessage(logFile, $"Stack Trace: {ex.StackTrace}");
                return;
            }

        }

        static void LogMessage(string logFile, string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFile, true))
                {
                    writer.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'écriture dans le fichier de journal : {ex.Message}");
            }
        }

        static byte[] ReadEncryptionKey(string filePath)
        {
            try
            {
                string keyString = File.ReadAllText(filePath);
                if (Encoding.UTF8.GetByteCount(keyString) < 8)
                {
                    return null;
                }
                return Encoding.UTF8.GetBytes(keyString);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        static void EncryptFile(string inputFile, string outputFile, byte[] key, string logFile)
        {
            try
            {
                using (StreamReader reader = new StreamReader(inputFile))
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    int keyIndex = 0;

                    // Lecture ligne par ligne du fichier d'entrée
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Chiffrement ligne par ligne avec XOR et écriture dans le fichier de sortie
                        for (int i = 0; i < line.Length; i++)
                        {
                            char encryptedChar = (char)(line[i] ^ key[keyIndex]);
                            writer.Write(encryptedChar);
                            keyIndex = (keyIndex + 1) % key.Length;
                        }
                        writer.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage(logFile, $"Erreur lors du chiffrement du fichier : {ex.Message}");
            }
        }
    }
}
