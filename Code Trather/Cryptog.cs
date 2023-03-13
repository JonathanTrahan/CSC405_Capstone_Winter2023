using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Trather
{
    internal class Cryptog
    {
        ///<summary>
        /// Encrypts a file using C# AES class.
        /// inputFile is the path to the file to be encrypted.
        /// outputFile is the path to where the encrypted file is written to.
        /// Key and IV are the AES parameters.
        ///</summary>
        ///<param name="inputFile"></param>
        ///<param name="outputFile"></param>
        ///<param name="Key"></param>
        ///<param name="IV"></param>
        public static void EncryptFile(string inputFile, string outputFile, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (inputFile == null || inputFile.Length <= 0)
                throw new ArgumentNullException("inputFile");
            if (outputFile == null || outputFile.Length <= 0)
                throw new ArgumentNullException("outputFile");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                try 
                {
                FileStream fsCrypt = new FileStream(outputFile, FileMode.Create);

                CryptoStream cs = new CryptoStream(fsCrypt, encryptor, CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);
                
                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
                }
                catch
                {
                    MessageBox.Show("Encryption failed!", "Error");
                }
            }
        }

        ///<summary>
        /// Decrypts a file using C# AES class.
        /// inputFile is the path to the file to be encrypted.
        /// outputFile is the path to where the encrypted file is written to.
        /// Key and IV are the AES parameters.
        ///</summary>
        ///<param name="inputFile"></param>
        ///<param name="outputFile"></param>
        ///<param name="Key"></param>
        ///<param name="IV"></param>
        public static void DecryptFile(string inputFile, string outputFile, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (inputFile == null || inputFile.Length <= 0)
                throw new ArgumentNullException("inputFile");
            if (outputFile == null || outputFile.Length <= 0)
                throw new ArgumentNullException("outputFile");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                try
                {
                    FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                    CryptoStream cs = new CryptoStream(fsCrypt, decryptor, CryptoStreamMode.Read);

                    FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                    int data;
                    while ((data = cs.ReadByte()) != -1)
                        fsOut.WriteByte((byte)data);

                    fsOut.Close();
                    cs.Close();
                    fsCrypt.Close();
                }
                catch
                {
                    MessageBox.Show("Decryption failed!", "Error");
                }
            }
        }

        /// <summary>
        /// Creates a zip file from the TratherLogs folder, creates encrypted file in Cryptog folder from zip file, 
        /// then deletes TratherLogs and TratherLogs.zip
        /// </summary>
        public static void encryptSubmit()
        {
            System.IO.File.Delete(Globals.filePathZip);
            System.IO.Compression.ZipFile.CreateFromDirectory(Globals.filePath, Globals.filePathZip);

            // Create a new instance of the Aes
            // class.  This generates a new key and initialization
            // vector (IV).
            using (Aes myAes = Aes.Create())
            {
                //EncryptFile(new FileInfo(Globals.filePathZip));
                EncryptFile(Globals.filePathZip, Globals.encryptedZip, myAes.Key, myAes.IV);
                File.WriteAllBytes(Globals.aesKeyFile, myAes.Key);
                File.WriteAllBytes(Globals.aesIVFile, myAes.IV);
            }

            System.IO.Directory.Delete(Globals.filePath, true);
            System.IO.File.Delete(Globals.filePathZip);
        }

        /// <summary>
        /// gets the aes key and IV from crytog folder and decrypts the encrypted file. Needs to have required files in cryptog folder
        /// </summary>
        public static void decryptSubmit()
        {
            if (File.Exists(Globals.encryptedZip) && File.Exists(Globals.aesKeyFile) && File.Exists(Globals.aesIVFile))
            {
                byte[] key = File.ReadAllBytes(Globals.aesKeyFile);
                byte[] iv = File.ReadAllBytes(Globals.aesIVFile);

                DecryptFile(Globals.encryptedZip, Globals.decryptedZip, key, iv);

                if (File.Exists(Globals.decryptedZip))
                {
                    MessageBox.Show("Decryption Succesful!");
                }
            }
            else 
            {
                MessageBox.Show("No file to decrypt.", "Error!");
            }
        }

        ///<summary>
        /// Steve Lydford - 12/05/2008.
        ///
        /// Encrypts a file using Rijndael algorithm.
        ///</summary>
        ///<param name="inputFile"></param>
        ///<param name="outputFile"></param>
        public static void RSAEncryptFile(string inputFile, string outputFile)
        {

            try
            {
                string password = @"myKey123"; // Your Key Here
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                #pragma warning disable SYSLIB0022 // Type or member is obsolete
                RijndaelManaged RMCrypto = new RijndaelManaged();
                #pragma warning restore SYSLIB0022 // Type or member is obsolete

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch
            {
                MessageBox.Show("Encryption failed!", "Error");
            }
        }
        ///<summary>
        /// Steve Lydford - 12/05/2008.
        ///
        /// Decrypts a file using Rijndael algorithm.
        ///</summary>
        ///<param name="inputFile"></param>
        ///<param name="outputFile"></param>
        public static void RSADecryptFile(string inputFile, string outputFile)
        {
            string pass = @"myKey123"; // Your Key Here
            string password = @$"{Interaction.InputBox("Password", "Decrypt File", "")}";

            if (pass == password)
            {
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                #pragma warning disable SYSLIB0022 // Type or member is obsolete
                RijndaelManaged RMCrypto = new RijndaelManaged();
                #pragma warning restore SYSLIB0022 // Type or member is obsolete

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();
            }
            else
            {
                MessageBox.Show("Wrong Password");
            }
        }
    }
}
