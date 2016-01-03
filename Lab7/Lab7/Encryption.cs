using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    static class Encryption
    {
        private static DESCryptoServiceProvider DES = new DESCryptoServiceProvider(); // cryptography provider
        private static ICryptoTransform encryptor, decryptor;

        public static void encrypt(FileStream inputStream, FileStream encryptedStream, byte[] key)
        {
            DES.IV = key;
            DES.Key = key;
            encryptor = DES.CreateEncryptor(DES.Key, DES.IV);
            try
            {
                CryptoStream cryptostream = new CryptoStream(encryptedStream, encryptor, CryptoStreamMode.Write);
                byte[] byteArrayInput = new byte[inputStream.Length];
                inputStream.Read(byteArrayInput, 0, byteArrayInput.Length);
                cryptostream.Write(byteArrayInput, 0, byteArrayInput.Length);
                cryptostream.Close();
                inputStream.Close();
                encryptedStream.Close();
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("Could not open source or destination file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (System.ArgumentException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (System.Security.Cryptography.CryptographicException e)
            {
                MessageBox.Show("Bad key or file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public static void decrypt(FileStream inputStream, FileStream decryptedStream, byte[] key)
        {
            DES.Key = key;
            DES.IV = key;
            decryptor = DES.CreateDecryptor(DES.Key, DES.IV);

            try
            {
                CryptoStream cryptostream = new CryptoStream(decryptedStream, decryptor, CryptoStreamMode.Write);
                byte[] byteArrayInput = new byte[inputStream.Length];

                inputStream.Read(byteArrayInput, 0, byteArrayInput.Length);

                cryptostream.Write(byteArrayInput, 0, byteArrayInput.Length);

                cryptostream.Close();
                inputStream.Close();
                decryptedStream.Close();
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("Could not open source or destination file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (System.ArgumentException e)
            {
                //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Not a .des file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (System.Security.Cryptography.CryptographicException e)
            {
                MessageBox.Show("Bad key or file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
