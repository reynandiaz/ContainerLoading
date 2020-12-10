using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HTIPackageAllocation.NetCfLibrary
{
    /// <summary>
    /// データアクセス層で使える便利メソッドを提供するクラス。
    /// 主に、DB から取得したデータの DBNull を処理する。
    /// OracleCommand.ExecuteScalar, OracleDataAdapter.Fill には対応している。
    /// OracleCommand.ExecuteOracleScalar には対応していない。DBNull ではなく独自の型が返ってくるから。
    /// </summary>
    public static class DataUtility
    {
        /// <summary>
        /// 指定した Object の値を Int32 に変換します。
        /// value が null または DBNull.Value の場合は 0。
        /// </summary>
        /// <param name="value">ExecuteScalar や Fill で取得した値。</param>
        [Obsolete("DBNull.Value を既定値に変換するため注意が必要です。通常は Convert.ToInt32 を使いましょう。")]
        public static Int32 ToInt32(object value)
        {
            return Convert.ToInt32(value == DBNull.Value ? null : value);
        }

        /// <summary>
        /// 指定した Object の値を Nullable&lt;Int32&gt; に変換します。
        /// value が null または DBNull.Value の場合は null。
        /// </summary>
        /// <param name="value">ExecuteScalar や Fill で取得した値。</param>
        public static Int32? ToNInt32(object value)
        {
            if (value == null || value == DBNull.Value)
                return null;
            else
                return Convert.ToInt32(value);
        }

        /// <summary>
        /// 指定した Object の値を Int64 に変換します。
        /// value が null または DBNull.Value の場合は 0。
        /// </summary>
        /// <param name="value">ExecuteScalar や Fill で取得した値。</param>
        [Obsolete("DBNull.Value を既定値に変換するため注意が必要です。通常は Convert.ToInt64 を使いましょう。")]
        public static Int64 ToInt64(object value)
        {
            return Convert.ToInt64(value == DBNull.Value ? null : value);
        }

        /// <summary>
        /// 指定した Object の値を Nullable&lt;Int64&gt; に変換します。
        /// value が null または DBNull.Value の場合は null。
        /// </summary>
        /// <param name="value">ExecuteScalar や Fill で取得した値。</param>
        public static Int64? ToNInt64(object value)
        {
            if (value == null || value == DBNull.Value)
                return null;
            else
                return Convert.ToInt64(value);
        }

        /// <summary>
        /// 指定した Object の値を Single に変換します。
        /// value が null または DBNull.Value の場合は 0。
        /// </summary>
        /// <param name="value">ExecuteScalar や Fill で取得した値。</param>
        [Obsolete("DBNull.Value を既定値に変換するため注意が必要です。通常は Convert.ToSingle を使いましょう。")]
        public static Single ToSingle(object value)
        {
            return Convert.ToSingle(value == DBNull.Value ? null : value);
        }

        /// <summary>
        /// 指定した Object の値を Nullable&lt;Single&gt; に変換します。
        /// value が null または DBNull.Value の場合は null。
        /// </summary>
        /// <param name="value">ExecuteScalar や Fill で取得した値。</param>
        public static Single? ToNSingle(object value)
        {
            if (value == null || value == DBNull.Value)
                return null;
            else
                return Convert.ToSingle(value);
        }

        /// <summary>
        /// 指定した Object の値を Nullable&lt;decimal&gt; に変換します。
        /// value が null または DBNull.Value の場合は null。
        /// </summary>
        public static decimal? ToNDecimal(object value)
        {
            if (value == null || value == DBNull.Value)
                return null;
            else
                return Convert.ToDecimal(value);
        }

        /// <summary>
        /// 指定した Object の値を DateTime に変換します。
        /// value が null または DBNull.Value の場合は {0001/01/01 0:00:00}。
        /// </summary>
        /// <param name="value">ExecuteScalar や Fill で取得した値。</param>
        [Obsolete("DBNull.Value を既定値に変換するため注意が必要です。通常は Convert.ToDateTime を使いましょう。")]
        public static DateTime ToDateTime(object value)
        {
            return Convert.ToDateTime(value == DBNull.Value ? null : value);
        }

        /// <summary>
        /// 指定した Object の値を Nullable&lt;DateTime&gt; に変換します。
        /// value が null または DBNull.Value の場合は null。
        /// </summary>
        /// <param name="value">ExecuteScalar や Fill で取得した値。</param>
        public static DateTime? ToNDateTime(object value)
        {
            if (value == null || value == DBNull.Value)
                return null;
            else
                return Convert.ToDateTime(value);
        }

        /// <summary>
        /// 指定した Object の値を bool に変換します。
        /// value が null または DBNull.Value の場合は false
        /// </summary>
        /// <param name="value">ExecuteScalar や Fill で取得した値。</param>
        [Obsolete("DBNull.Value を既定値に変換するため注意が必要です。通常は Convert.ToBoolean を使いましょう。")]
        public static bool ToBoolean(object value)
        {
            return Convert.ToBoolean(value == DBNull.Value ? null : value);
        }

        /// <summary>
        /// 指定した Object の値を Nullable&lt;bool&gt; に変換します。
        /// value が null または DBNull.Value の場合は null。
        /// </summary>
        /// <param name="value">ExecuteScalar や Fill で取得した値。</param>
        public static bool? ToNBoolean(object value)
        {
            if (value == null || value == DBNull.Value)
                return null;
            else
                return Convert.ToBoolean(value);
        }

        /// <summary>
        /// 指定した Object の値を DateTime に変換します。
        /// value は YYYYMMDD 形式の Int32 または String を想定しています。
        /// value が null または DBNull.Value の場合は例外。
        /// </summary>
        /// <param name="value">ExecuteScalar や Fill で取得した値。</param>
        public static DateTime ToDateTimeFromYYYYMMDD(object value)
        {
            if (value == null || value == DBNull.Value)
                throw new ArgumentNullException("引き数が null または DBNull です。");

            string date = value.ToString();
            return DateTime.ParseExact(date, "yyyyMMdd", null);
        }

        /// <summary>
        /// 指定した Object の値を Nullable&lt;DateTime&gt; に変換します。
        /// value は YYYYMMDD 形式の Int32 または String を想定しています。
        /// value が null、DBNull.Value、空文字、または "0" の場合は null。
        /// </summary>
        /// <param name="value">ExecuteScalar や Fill で取得した値。</param>
        public static DateTime? ToNDateTimeFromYYYYMMDD(object value)
        {
            if (value == null || value == DBNull.Value)
                return null;

            string date = value.ToString();
            if (date == string.Empty || date == "0")
                return null;

            return DateTime.ParseExact(date, "yyyyMMdd", null);
        }

        /// <summary>
        /// 指定した Object の値を Nullable&lt;Guid&gt; に変換します。
        /// value が null または DBNull.Value の場合は null。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid? ToNGuid(object value)
        {
            if (value == null || value == DBNull.Value)
                return null;
            else
                return new Guid(value.ToString());
        }

        /// <summary>
        /// 指定した Object の値を String に変換し、単独の "\r" や "\n" を "\r\n" に置換します。
        /// </summary>
        /// <param name="value">ExecuteScalar や Fill で取得した値。</param>
        public static string ToStringCrLf(object value)
        {
            return Regex.Replace(value.ToString(), "\r(?!\n)|(?<!\r)\n", "\r\n");
        }

        /// <summary>
        /// 指定したコードの配列をカンマ区切りの文字列に変換します。
        /// クエリのIN句の生成用です。
        /// codes は Int32 または String の配列を想定しています。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="codes"></param>
        /// <returns></returns>
        public static string JoinCodes<T>(T[] codes)
        {
            List<string> codeList = new List<string>();
            foreach (T code in codes)
            {
                if (code is string)
                    codeList.Add("'" + code.ToString() + "'");
                else if (code is int)
                    codeList.Add(code.ToString());
            }

            return string.Join(",", codeList.ToArray());
        }
    }
}
