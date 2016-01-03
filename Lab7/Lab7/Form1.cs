using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class Form1 : Form
    {
        //8 byte key
        byte[] keyArray = new byte[8]; 
        //File names
        string myFileIn, myFileOut; 

        public Form1()
        {
            resetKey();
            InitializeComponent();
        }

        //Method to set all values to 0, called at the beginning to avoid garbage init
        public void resetKey()
        {
            for(int x = 0; x < 8; x++)
            {
                keyArray[x] = 0;
            }
        }

        //Method to make sure entered key is not empty
        public bool checkKeyLength()
        {
            if(textBox2.Text == "")
            {
                MessageBox.Show("Please enter a key.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        //Method to make sure entered filename is not empty
        public bool checkFileLength()
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Cannot! open source or destination file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        //Check if there is already a file named, and then prompt the user if they would like to overwrite it or not
        public bool approveOverwrite(string file)
        {
            if (File.Exists(file))
            {
                //From https://msdn.microsoft.com/en-us/library/system.windows.forms.messagebox(v=vs.110).aspx
                var result = MessageBox.Show("Output file exists. Overwrite?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                    return true;
                else
                    return false;
            }

            return true;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        //Open the dialog box and make sure the user hit OK and set the text box to the selected file
        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        //Using the MSDN example with exception handling
        public static void encrypt(FileStream inputStream, FileStream encryptedOut, byte[] key)
        {
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            ICryptoTransform encryptor;

            //Create the vectors and keys inside
            DES.IV = key;
            DES.Key = key;
            //Create the encryption obj using key and vector
            encryptor = DES.CreateEncryptor(DES.Key, DES.IV);

            try
            {
                CryptoStream cryptostream = new CryptoStream(encryptedOut, encryptor, CryptoStreamMode.Write);
                byte[] byteArrayInput = new byte[inputStream.Length];

                inputStream.Read(byteArrayInput, 0, byteArrayInput.Length);

                cryptostream.Write(byteArrayInput, 0, byteArrayInput.Length);

                cryptostream.Close();
                inputStream.Close();
                encryptedOut.Close();
            }
            //If there is an error reading
            catch (System.IO.IOException e)
            {
                MessageBox.Show("Could not open source or destination file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Crypto exceptions
            catch (System.Security.Cryptography.CryptographicException e)
            {
                MessageBox.Show("Bad key or file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //When the user hits the EncryptButton
        private void EncryptButton_Click(object sender, EventArgs e)
        {
            //If the key length and file entered aren't empty
            if(checkKeyLength() && checkFileLength())
            {
                try
                {
                    //Take the file in the entrybox
                    myFileIn = textBox1.Text.ToString();
                    //Create a Filestream object using that filename
                    FileStream input = new FileStream(myFileIn, FileMode.Open, FileAccess.Read);
                    //Add .des because the output file will be a .des file
                    myFileOut = myFileIn + ".des";
                    //Check if filealready exists and how user wants to handle
                    if(!approveOverwrite(myFileOut))
                    {
                        return;
                    }
                    //Create file object for output of encryption
                    FileStream encryptedOut = new FileStream(myFileOut, FileMode.OpenOrCreate, FileAccess.Write);
                    //Reset key to 0s
                    resetKey();
                    //Cast the key to an array so we an manipulate it better
                    char[] charArray = textBox2.Text.ToCharArray();
                    //Calculate the length of the key once
                    int len = charArray.Count();
                    //Loop through and add the lower 8 bits of the UTF-8 key into the actual key (wrap around enabled with %)
                    for(int x = 0; x < len; x++)
                    {
                        keyArray[x % 8] += (byte)charArray[x];
                    }
                    //Call the encryption function with the inputs
                    encrypt(input, encryptedOut, keyArray);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Essentially the same, but with decryption being called instead
        private void DecryptButton_Click(object sender, EventArgs e)
        {
            if(checkKeyLength() && checkFileLength())
            {
                try
                {
                    myFileIn = textBox1.Text.ToString();
                    FileStream input = new FileStream(myFileIn, FileMode.Open, FileAccess.Read);
                    //Checking to make sure that the file specified is a .des file
                    if(!myFileIn.EndsWith(".des"))
                    {
                        MessageBox.Show("Not a .des file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //".des" is 4 characters long, so we truncate it from the decrypted version
                    myFileOut = myFileIn.Substring(0, myFileIn.Length - 4);

                    if (!approveOverwrite(myFileOut))
                    {
                        return;
                    }
                    //Use the truncated filename in the decrypted output name
                    FileStream decryptedOut = new FileStream(myFileOut, FileMode.Create, FileAccess.Write);

                    resetKey();

                    char[] charArray = textBox2.Text.ToCharArray();

                    int len = charArray.Count();

                    for (int x = 0; x < len; x++)
                    {
                        keyArray[x % 8] += (byte)charArray[x];
                    }
                    //Call the decrypt function
                    decrypt(input, decryptedOut, keyArray);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Decrytping instead of encrypting
        public static void decrypt(FileStream inputStream, FileStream decryptedStream, byte[] key)
        {
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider(); 
            ICryptoTransform decryptor;

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
            catch (System.Security.Cryptography.CryptographicException e)
            {
                MessageBox.Show("Bad key or file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
