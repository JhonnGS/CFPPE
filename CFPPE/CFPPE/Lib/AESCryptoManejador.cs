﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;


namespace CFPPE.lib
{
	public class AESCryptoManejador
	{
		// 128bit(16byte)IV and Key
		private string _aesIV = @"TK-090817EFC5RFV";
		private string _aesKey = @"TK-090817ULK(IK<";

		public String AesIV
		{
			get { return _aesIV; }
			set { _aesIV = value; }
		}

		public String AesKey
		{
			get { return _aesKey; }
			set { _aesKey = value; }
		}

		/// <summary>
		/// Encripta el texto especificado como parámetro.
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public string cifrar(object text)
		{
			if (text == null) return null;

			try
			{
				using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
				{
					aes.BlockSize = 128;
					aes.KeySize = 128;
					aes.IV = Encoding.UTF8.GetBytes(AesIV);
					aes.Key = Encoding.UTF8.GetBytes(AesKey);
					aes.Mode = CipherMode.CBC;
					aes.Padding = PaddingMode.PKCS7;

					// Convert string to byte array
					byte[] src = Encoding.Unicode.GetBytes(text.ToString());

					// encryption
					using (ICryptoTransform encrypt = aes.CreateEncryptor())
					{
						byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

						// Convert byte array to Base64 strings
						return Convert.ToBase64String(dest);
					}
				}
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// Desencripta el texto cifrado enviado como parámetro.
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public string descifrar(string text)
		{
			if (text == null) return null;

			try
			{
				using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
				{
					aes.BlockSize = 128;
					aes.KeySize = 128;
					aes.IV = Encoding.UTF8.GetBytes(AesIV);
					aes.Key = Encoding.UTF8.GetBytes(AesKey);
					aes.Mode = CipherMode.CBC;
					aes.Padding = PaddingMode.PKCS7;

					// Convert Base64 strings to byte array
					byte[] src = System.Convert.FromBase64String(text);

					// decryption
					using (ICryptoTransform decrypt = aes.CreateDecryptor())
					{
						byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
						return Encoding.Unicode.GetString(dest);
					}
				}
			}
			catch
			{
				return null;
			}
		}
	}
}