namespace WinFormsApp1
{
    using System;
    using System.Text;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Crypto CreateCrypto()
        {
            txtKey.Text = "E037624AB97576042FCB68CB10D6B5EC";
            string keyHex = txtKey.Text.Trim();
            Crypto crypto = new Crypto(new byte[0]);

            byte[] keyBytes = crypto.ConvertHexStringToByteArray(keyHex);
            return new Crypto(keyBytes);
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                Crypto crypto = CreateCrypto();

                byte[] inputBytes = Encoding.UTF8.GetBytes(txtInput.Text);
                byte[] encrypted = crypto.Encrypt(inputBytes);

                txtOutput.Text = crypto.ConvertByteArrayToHexString(encrypted);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                Crypto crypto = CreateCrypto();

                byte[] inputBytes = crypto.ConvertHexStringToByteArray(txtInput.Text);
                byte[] decrypted = crypto.Decrypt(inputBytes);

                txtOutput.Text = Encoding.UTF8.GetString(decrypted).TrimEnd('\0');
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            try
            {
                Crypto crypto = CreateCrypto();
                string password = txtInput.Text;

                string hash = crypto.HashPassword(password);

                txtOutput.Text = hash;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
