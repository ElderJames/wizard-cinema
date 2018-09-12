using Infrastructures.Encrypt.Shared;

namespace Infrastructures.Encrypt.Extensions
{
    public static class EncryptExtensions
    {
        /// <summary>
        /// String MD5 extension
        /// </summary>
        /// <param name="srcString"></param>
        /// <returns></returns>
        public static string ToMd5(this string srcString)
        {
            Check.Argument.IsNotEmpty(srcString, nameof(srcString));
            return EncryptProvider.Md5(srcString);
        }

        /// <summary>
        /// String SHA1 extensions
        /// </summary>
        /// <param name="srcString"></param>
        /// <returns></returns>
        public static string ToSha1(this string srcString)
        {
            Check.Argument.IsNotEmpty(srcString, nameof(srcString));
            return EncryptProvider.Sha1(srcString);
        }

        /// <summary>
        /// String SHA256 extensions
        /// </summary>
        /// <param name="srcString"></param>
        /// <returns></returns>
        public static string ToSha256(this string srcString)
        {
            Check.Argument.IsNotEmpty(srcString, nameof(srcString));
            return EncryptProvider.Sha256(srcString);
        }

        /// <summary>
        /// String SHA384 extensions
        /// </summary>
        /// <param name="srcString"></param>
        /// <returns></returns>
        public static string ToSha384(this string srcString)
        {
            Check.Argument.IsNotEmpty(srcString, nameof(srcString));
            return EncryptProvider.Sha384(srcString);
        }

        /// <summary>
        /// String SHA512 extensions
        /// </summary>
        /// <param name="srcString"></param>
        /// <returns></returns>
        public static string ToSha512(this string srcString)
        {
            Check.Argument.IsNotEmpty(srcString, nameof(srcString));
            return EncryptProvider.Sha512(srcString);
        }

        /// <summary>
        /// String HMACMD5 extensions
        /// </summary>
        /// <param name="srcString"></param>
        /// <returns></returns>
        public static string ToHmacmd5(this string srcString, string key)
        {
            Check.Argument.IsNotEmpty(srcString, nameof(srcString));
            return EncryptProvider.HMACMD5(srcString, key);
        }

        /// <summary>
        /// String HMACSHA1 extensions
        /// </summary>
        /// <param name="srcString"></param>
        /// <returns></returns>
        public static string ToHmacsha1(this string srcString, string key)
        {
            Check.Argument.IsNotEmpty(srcString, nameof(srcString));
            return EncryptProvider.HMACSHA1(srcString, key);
        }

        /// <summary>
        /// String HMACSHA1 extensions
        /// </summary>
        /// <param name="srcString"></param>
        /// <returns></returns>
        public static string ToHmacsha256(this string srcString, string key)
        {
            Check.Argument.IsNotEmpty(srcString, nameof(srcString));
            return EncryptProvider.HMACSHA256(srcString, key);
        }

        /// <summary>
        /// String HMACSHA384 extensions
        /// </summary>
        /// <param name="srcString"></param>
        /// <returns></returns>
        public static string ToHmacsha384(this string srcString, string key)
        {
            Check.Argument.IsNotEmpty(srcString, nameof(srcString));
            return EncryptProvider.HMACSHA384(srcString, key);
        }

        /// <summary>
        /// String HMACSHA512 extensions
        /// </summary>
        /// <param name="srcString"></param>
        /// <returns></returns>
        public static string ToHmacsha512(this string srcString, string key)
        {
            Check.Argument.IsNotEmpty(srcString, nameof(srcString));
            return EncryptProvider.HMACSHA512(srcString, key);
        }

        public static string ToBase64String(this string srcString)
        {
            return EncryptProvider.Base64Encrypt(srcString);
        }

        public static string FromBase64String(this string base64String)
        {
            return EncryptProvider.Base64Decrypt(base64String);
        }
    }
}
