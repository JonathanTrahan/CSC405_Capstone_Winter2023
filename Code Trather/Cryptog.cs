using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
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
        /// inputFile is the path to the file to be decrypted.
        /// outputFile is the path to where the decrypted file is written to.
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
        /// Uses a hardcoded public key to encrypt a byte array and write it to the filepath.
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        static public void RsaEncryption(byte[] Data, string filePath)
        {
            string rsaPubKey = "<RSAKeyValue><Modulus>2hdKHmqbwgm1x6ugtliJs7ImbbI/rYhsq1aKpjG8QKdUKqr7vVKUP+k6eLZeHcrAcAQ08B6gWn4CVAUezkhnAV07oWi7VCjnh5MsZvKSYytsewnbuBdoocjo+4eXVMjt4Jq0RRKqAoCgIwC8RK6CtZV6ENGmkK+ite9Y2s8Zoq0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            bool DoOAEPPadding = true;

            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.FromXmlString(rsaPubKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                //return encryptedData;
                File.WriteAllBytes(filePath, encryptedData);
            }
            catch (CryptographicException e)
            {
                MessageBox.Show(e.Message);
                //return null;
            }
        }

        /// <summary>
        /// Uses a hardcoded private key to decrypt a byte array and write it to the filepath.
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="filePath"></param>
        static public void RsaDecryption(byte[] Data, string filePath)
        {
            string rsaPrivKey = "<RSAKeyValue><Modulus>2hdKHmqbwgm1x6ugtliJs7ImbbI/rYhsq1aKpjG8QKdUKqr7vVKUP+k6eLZeHcrAcAQ08B6gWn4CVAUezkhnAV07oWi7VCjnh5MsZvKSYytsewnbuBdoocjo+4eXVMjt4Jq0RRKqAoCgIwC8RK6CtZV6ENGmkK+ite9Y2s8Zoq0=</Modulus><Exponent>AQAB</Exponent><P>5QN1nMWA+hVflwJY5+h4sK2KoVNsfUi/fLrtNi0S4WBTmNE3nOmsM9oKsOWJD4x2119ChAYLzfJIQNxNWLt2Zw==</P><Q>88pVyw8+kH5bEatyIocezzCWXUE2qSv/LZX3RrmsCvuBaGtJGDrKes8kegjQkmt4JbaWS9vNtF3QRo4dG3npyw==</Q><DP>f4y2s7MYy7Cdxchr5fYHSjfNr158XSboZ7rgpTzjeB0jUkisVbubymFVdQLSnJNaGUgYDtojNvgLH/zTI2l9Xw==</DP><DQ>sTCBlLn6viioZjpXFVNiCDMHRrZMVT7eFDLoa+YtbjoIf21izhKE8ie2GmBnv9QOmlKQAIi8hPielXlbHIpKaw==</DQ><InverseQ>npTpOi55D4qg8smqUV+KIOYyUXTjHmTAyRRyGdhiry+fcSx5sA1+rT78U3G64kYX1yVsoLSMjYqX8OIBsJDfSw==</InverseQ><D>lAIsRho53OT0Hi9HIZlS0sY7uES5XI7ymRFhhUrJpOMqhs6FjEYH4JvrF9NEalmYYi0otDFEyEUuVVEoR/zxEcYROKRh2EjfPHmENVDElI64TDnNItQn4GJ5+2FA2GPaJc8gbf6+TFbRj0fxuOxJHmB721qv41T59WN8eXnl4Y0=</D></RSAKeyValue>";
            bool DoOAEPPadding = true;

            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.FromXmlString(rsaPrivKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                //return decryptedData;
                File.WriteAllBytes(filePath, decryptedData);
            }
            catch (CryptographicException e)
            {
                MessageBox.Show(e.Message);
                //return null;
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

            // Create a new instance of the Aes class.
            // This generates a new key and initialization vector (IV).
            using (Aes myAes = Aes.Create())
            {
                //EncryptFile(new FileInfo(Globals.filePathZip));
                EncryptFile(Globals.filePathZip, Globals.encryptedZip, myAes.Key, myAes.IV);


                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                string key1 = ByteConverter.GetString(myAes.Key);
                string IV1 = ByteConverter.GetString(myAes.IV);

                File.WriteAllBytes(Globals.aesKeyFile, myAes.Key);
                File.WriteAllBytes(Globals.aesIVFile, myAes.IV);
                MessageBox.Show(key1, "aes key in string form");
                MessageBox.Show(IV1, "aes IV in string form");
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

    }
}
