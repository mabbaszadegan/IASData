using DAL;
using IASData.Enumerable;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace IASData.Utility
{
    public static class Common
    {
        static DAL.UnitOfWork _db = new DAL.UnitOfWork();
        #region encrypt-Decrypt-AES
        //encryptAES
        public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
        //encrypString
        public static string EncryptTextAES(string input, string password)
        {
            string result = input;
            if (input != null)
            {
                // Get the bytes of the string
                byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Hash the password with SHA256
                passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

                byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

                result = Convert.ToBase64String(bytesEncrypted);
            }
            return result;
        }

        //DecryptAES
        public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
        //DecryptString
        public static string DecryptTextAES(string input, string password)
        {
            string result = input;
            if (input != null)
            {
                if (input.Trim() != string.Empty)
                {


                    // Get the bytes of the string
                    byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                    passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

                    byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

                    result = Encoding.UTF8.GetString(bytesDecrypted);
                }
            }
            return result;
        }

        #endregion

        #region Date Functions
        public static string ToDateSolar(this DateTime date)
        {
            //DateTimeFunc1.shDate shDate = new DateTimeFunc1.shDate ();
            //shDate.makeDate (date.Year,date.Month,date.Day);
            string output = "";
            PersianCalendar p = new PersianCalendar();
            output = p.GetYear(date) + "/";
            output += p.GetMonth(date).ToString("D2") + "/";
            output += p.GetDayOfMonth(date).ToString("D2");
            return output;
        }

        public static string ToTimeSolarbySecond(this DateTime date)
        {
            //DateTimeFunc1.shDate shDate = new DateTimeFunc1.shDate ();
            //shDate.makeDate (date.Year,date.Month,date.Day);
            //string h = date.Hour.ToString ("D2");
            //string m = date.Minute.ToString ("D2");
            //string s = date.Second.ToString ("D2");
            //output = shDate.sDateString + " " + h + ":" + m;
            string output = "";
            PersianCalendar p = new PersianCalendar();
            output = p.GetYear(date) + "/";
            output += p.GetMonth(date).ToString("D2") + "/";
            output += p.GetDayOfMonth(date).ToString("D2") + " ";
            output += p.GetHour(date).ToString("D2") + ":";
            output += p.GetMinute(date).ToString("D2");
            output += p.GetSecond(date).ToString("D2");
            return output;
        }

        public static string ToTimeSolar(this DateTime date)
        {
            //DateTimeFunc1.shDate shDate = new DateTimeFunc1.shDate ();
            //shDate.makeDate (date.Year,date.Month,date.Day);
            //string h = date.Hour.ToString ("D2");
            //string m = date.Minute.ToString ("D2");
            //string s = date.Second.ToString ("D2");
            //output = shDate.sDateString + " " + h + ":" + m;
            string output = "";
            PersianCalendar p = new PersianCalendar();
            output = p.GetYear(date) + "/";
            output += p.GetMonth(date).ToString("D2") + "/";
            output += p.GetDayOfMonth(date).ToString("D2") + " ";
            output += p.GetHour(date).ToString("D2") + ":";
            output += p.GetMinute(date).ToString("D2");
            return output;
        }
        //public static string ToDateSolarWebString(this DateTime date)
        //{
        //    DateTimeFunc1.shDate shDate = new DateTimeFunc1.shDate();
        //    shDate.makeDate(date.Year, date.Month, date.Day);

        //    string output = shDate.sDateWebString;
        //    return output;
        //}
        //public static string ToTimeSolarWebString(this DateTime date)
        //{
        //    DateTimeFunc1.shDate shDate = new DateTimeFunc1.shDate();
        //    shDate.makeDate(date.Year, date.Month, date.Day);

        //    string h = date.Hour.ToString();
        //    string M = date.Minute.ToString();
        //    string S = date.Second.ToString();

        //    string output = h.ToTwoDigit() + ":" + M.ToTwoDigit() + ":" + S.ToTwoDigit() + " " + shDate.sDateWebString;
        //    return output;
        //}

        public static string ToDateSolarWebString(this string date)
        {
            string output = string.Empty;
            try
            {
                if (date.Length == 19)
                    output = date.Substring(11, 8) + " " + date.Substring(8, 2) + "/" + date.Substring(5, 2) + "/" + date.Substring(0, 4);
                if (date.Length == 10)
                    output = date.Substring(8, 2) + "/" + date.Substring(5, 2) + "/" + date.Substring(0, 4);
            }
            catch
            {
            }

            return output;
        }


        public static DateTime? ToDate(this string date)
        {
            DateTime output;
            output = DateTime.MinValue;
            try
            {
                if (date.Trim().IsDateFormat())
                {
                    PersianCalendar p = new PersianCalendar();
                    int YearSolar = Convert.ToInt32(date.Substring(0, 4));
                    int MonthSolar = Convert.ToInt32(date.Substring(5, 2));
                    int DaySolar = Convert.ToInt32(date.Substring(8, 2));
                    output = p.ToDateTime(YearSolar, MonthSolar, DaySolar, 0, 0, 0, 0);
                    //DateTimeFunc1.mdDate mdDate = new DateTimeFunc1.mdDate ();
                    //if (date == "1345/12/10")
                    //    output = mdDate.makeDateDT ("1345/12/11");
                    //else
                    //    output = mdDate.makeDateDT (date);
                }
            }
            catch
            {
            }
            return output;

        }
        public static bool IsDateFormat(this string text)
        {
            bool output = false;
            if (text.Length == 10 && text.Substring(4, 1) == "/" && text.Substring(7, 1) == "/")
                output = true;
            return output;
        }
        #endregion

        #region String Functions
        public static bool IsNumeric(this string value)
        {
            long cell = 0;
            return long.TryParse(value.ToZipedTextOnly(), out cell);
        }

        public static bool IsNationalCode(this string NationalCode)
        {
            NationalCode = NationalCode.ToZipedTextOnly();
            bool Result = false;
            if (NationalCode.Length == 10)
            {
                if (NationalCode[0].ToString() == "0" && NationalCode[1].ToString() == "0" && NationalCode[2].ToString() == "0" && NationalCode[3].ToString() == "0" && NationalCode[4].ToString() == "0" && NationalCode[5].ToString() == "0" && NationalCode[6].ToString() == "0")
                    Result = true;
                else
                {
                    int c = int.Parse(NationalCode[9].ToString());
                    int n = (int.Parse(NationalCode[0].ToString()) * 10) + (int.Parse(NationalCode[1].ToString()) * 9) + (int.Parse(NationalCode[2].ToString()) * 8) + (int.Parse(NationalCode[3].ToString()) * 7) + (int.Parse(NationalCode[4].ToString()) * 6) + (int.Parse(NationalCode[5].ToString()) * 5) + (int.Parse(NationalCode[6].ToString()) * 4) + (int.Parse(NationalCode[7].ToString()) * 3) + (int.Parse(NationalCode[8].ToString()) * 2);
                    int r = n - (n / 11) * 11;
                    if ((r == 0 && r == c) || (r == 1 && c == 1) || (r > 1 && c == 11 - r))
                        Result = true;
                    else
                        Result = false;
                }
            }
            else
                Result = false;
            return Result;
        }

        public static bool IsEmailAddress(this string emailAddress, int Mode)
        {
            bool functionReturnValue = false;
            if (Mode == 1)
            {
                //string pattern = "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
                string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

                Match emailAddressMatch = Regex.Match(emailAddress, pattern);
                if (emailAddressMatch.Success)
                {
                    functionReturnValue = true;
                }
                else
                {
                    functionReturnValue = false;
                }
            }
            return functionReturnValue;

        }
        public static bool IsMobileNumber(this string mobileNumber)
        {
            bool result = false;
            if (mobileNumber != null)
            {
                mobileNumber = mobileNumber.ToZipedMobileNumber();
                if (mobileNumber.Length == 13)
                    if (mobileNumber.Substring(0, 4) == "+989")
                        result = true;
            }
            return result;
        }
        public static bool IsPhoneNumber(this string phoneNumber)
        {
            bool result = false;
            if (phoneNumber != null)
                if (phoneNumber.Length == 11)
                    result = true;
            return result;
        }
        public static string ToZipedSpaces(this string text)
        {
            text = text.Replace("   ", " ");//tab
            text = text.Replace("‌", " ");//hideen space
            text = text.Replace(" و ", " ");
            text = text.Replace(" + ", " ");
            text = text.Replace(" - ", " ");
            text = text.Replace(" . ", " ");
            text = text.Replace(" : ", " ");
            text = text.Replace("         ", " ");
            text = text.Replace("        ", " ");
            text = text.Replace("       ", " ");
            text = text.Replace("      ", " ");
            text = text.Replace("     ", " ");
            text = text.Replace("    ", " ");
            text = text.Replace("   ", " ");
            text = text.Replace("  ", " ");
            text = text.Replace("  ", " ");
            text = text.Replace("  ", " ");
            text = text.Trim();
            return text;
        }
        public static string ToZipedLetters(this string text)
        {
            text = text.Replace("ء", "");
            text = text.Replace("ـ", "");
            text = text.Replace("&#1740;", "ي");
            text = text.Replace("ی", "ي");
            text = text.Replace("ئ", "ي");
            text = text.Replace("يي", "ي");
            text = text.Replace("ة", "");
            text = text.Replace("ۀ", "ت");
            text = text.Replace("ؤ", "و");
            text = text.Replace("وو", "و");
            text = text.Replace("ك", "ک");
            text = text.Replace("الله", "اله");
            text = text.Replace("ا...", "اله");
            text = text.Replace("آ", "ا");
            text = text.Replace("أ", "ا");
            text = text.Replace("إ", "ا");

            text = text.Replace("٠", "0");
            text = text.Replace("١", "1");
            text = text.Replace("٢", "2");
            text = text.Replace("٣", "3");
            text = text.Replace("٤", "4");
            text = text.Replace("٥", "5");
            text = text.Replace("٦", "6");
            text = text.Replace("٧", "7");
            text = text.Replace("٨", "8");
            text = text.Replace("٩", "9");

            text = text.Replace("۰", "0");
            text = text.Replace("۱", "1");
            text = text.Replace("۲", "2");
            text = text.Replace("۳", "3");
            text = text.Replace("۴", "4");
            text = text.Replace("۵", "5");
            text = text.Replace("۶", "6");
            text = text.Replace("۷", "7");
            text = text.Replace("۸", "8");
            text = text.Replace("۹", "9");


            return text;
        }
        public static string ToZipedTextOnly(this string text)
        {
            if (text != null)
            {
                text = text.Replace(" ", string.Empty);//space
                text = text.Replace("   ", string.Empty);//tab
                text = text.Replace("‌", string.Empty);//hidden space
                text = text.ToZipedLetters();
            }
            return text;
        }

        public static string ToZipedText(this string text)
        {
            text = text.ToZipedTextOnly();
            text = text.ToRepairedNumbers();

            return text;
        }
        public static string ToZipedAddress(this string text)
        {
            text = text.ToRepairedAddress();
            text = text.Replace(" ", ".");
            return text;
        }
        public static string ToRepairedNumbers(this string text)
        {
            text = " " + text + " ";
            text = text.Replace("0", "");
            text = text.Replace("هزار", "");
            text = text.Replace("ميليون", "");
            text = text.Replace("مليون", "");
            text = text.Replace("مليارد", "");
            text = text.Replace("ميليارد", "");
            text = text.Replace("ترليون", "");
            text = text.Replace("تريليون", "");

            text = text.Replace(" يک ", " (يک) ");
            text = text.Replace(" دو ", " (دو) ");
            text = text.Replace(" سه ", " (سه) ");
            text = text.Replace(" چهار ", " (چهار) ");
            text = text.Replace(" پنج ", " (پنج) ");
            text = text.Replace(" شش ", " (شش) ");
            text = text.Replace(" هفت ", " (هفت) ");
            text = text.Replace(" هشت ", " (هشت) ");
            text = text.Replace(" نه ", " (نه) ");

            text = text.Replace(".يک.", " (يک) ");
            text = text.Replace(".دو.", " (دو) ");
            text = text.Replace(".سه.", " (سه) ");
            text = text.Replace(".چهار.", " (چهار) ");
            text = text.Replace(".پنج.", " (پنج) ");
            text = text.Replace(".شش.", " (شش) ");
            text = text.Replace(".هفت.", " (هفت) ");
            text = text.Replace(".هشت.", " (هشت) ");
            text = text.Replace(".نه.", " (نه) ");

            text = text.Replace("1", "(يک)");
            text = text.Replace("2", "(دو)");
            text = text.Replace("3", "(سه)");
            text = text.Replace("4", "(چهار)");
            text = text.Replace("5", "(پنج)");
            text = text.Replace("6", "(شش)");
            text = text.Replace("7", "(هفت)");
            text = text.Replace("8", "(هشت)");
            text = text.Replace("9", "(نه)");

            text = text.Replace(" ده ", " (يک)(صفر) ");
            text = text.Replace("يازده", "(يک)(يک)");
            text = text.Replace("دوازده", "(يک)(دو)");
            text = text.Replace("سيزده", "(يک)(سه)");
            text = text.Replace("چهارده", "(يک)(چهار)");
            text = text.Replace("پانزده", "(يک)(پنج)");
            text = text.Replace("شانزده", "(يک)(شش)");
            text = text.Replace("هفده", "(يک)(هفت)");
            text = text.Replace("هجده", "(يک)(هشت)");
            text = text.Replace("هيجده", "(يک)(هشت)");
            text = text.Replace("نوزده", "(يک)(نه)");

            text = text.Replace(" بيست ", " (دو) ");
            text = text.Replace(" سي ", " (سه) ");
            text = text.Replace(" چهل", " (چهار)");
            text = text.Replace(" پنجاه", " (پنچ)");
            text = text.Replace(" شصت", " (شش)");
            text = text.Replace(" هفتادو", " (هفت)");
            text = text.Replace(" هفتاد", " (هفت)");
            text = text.Replace(" هشتادو", " (هشت)");
            text = text.Replace(" هشتاد", " (هشت)");
            text = text.Replace(" نودو", " (نه)");
            text = text.Replace(" نود", " (نه)");

            text = text.Replace(" دويست", " (دو)");
            text = text.Replace(" سيصدو", " (سه)");
            text = text.Replace(" سيصد", " (سه)");
            text = text.Replace(" چهارصدو", " (چهار)");
            text = text.Replace(" چهارصد", " (چهار)");
            text = text.Replace(" پانصدو", " (پنچ)");
            text = text.Replace(" پانصد", " (پنچ)");
            text = text.Replace(" ششصدو", " (شش)");
            text = text.Replace(" ششصد", " (شش)");
            text = text.Replace(" هفتصدو", " (هفت)");
            text = text.Replace(" هفتصد", " (هفت)");
            text = text.Replace(" هشتصدو", " (هشت)");
            text = text.Replace(" هشتصد", " (هشت)");
            text = text.Replace(" نهصدو", " (نه)");
            text = text.Replace(" نهصد", " (نه)");

            text = text.ToZipedSpaces();
            text = text.Replace(") (", ")(");
            text = text.Trim();
            return text;


        }
        public static string ToRepairedAddress(this string text)
        {
            text = text.ToZipedSpaces();
            text = text.ToZipedLetters();
            text = text.ToRepairedNumbers();
            text = " " + text + " ";

            text = text.Replace("ضلع ", "ضلع#");
            text = text.Replace("شمال ", "شمال#");
            text = text.Replace("جنوب ", "جنوب#");
            text = text.Replace("شرق ", "شرق#");
            text = text.Replace("غرب ", "غرب#");
            text = text.Replace("شمال غربي ", "شمالغربي#");
            text = text.Replace("شمال شرقي ", "شمالشرقي#");
            text = text.Replace("جنوب غربي ", "جنوب غربي#");
            text = text.Replace("جنوب شرقي ", "جنوب شرقي#");
            text = text.Replace("شمالغربي ", "شمالغربي#");
            text = text.Replace("شمالشرقي ", "شمالشرقي#");
            text = text.Replace("جنوبغربي ", "جنوب غربي#");
            text = text.Replace("جنوبشرقي ", "جنوب شرقي#");
            text = text.Replace("استان ", "استان#");
            text = text.Replace("شهرستان", "شهر");
            text = text.Replace("شهر ", "شهر#");
            text = text.Replace("شهرک ", "شهرک#");
            text = text.Replace("روستاي", "روستا");
            text = text.Replace("روستا ", "روستا#");
            text = text.Replace("دهات ", "دهات#");
            text = text.Replace("منطقه پستي", "منطقهپستي#");
            text = text.Replace("منطقه پستي# ", "منطقهپستي#");
            text = text.Replace("منطقه ي", "منطقه");
            text = text.Replace("منطقه", "منطقه#");
            text = text.Replace("منطقه# ", "منطقه#");
            text = text.Replace("ناحيه ي", "ناحيه");
            text = text.Replace("ناحيه", "ناحيه#");
            text = text.Replace("ناحيه# ", "ناحيه#");
            text = text.Replace("محله", "محله#");
            text = text.Replace("محله# ", "محله#");
            text = text.Replace("فاز", "فاز#");
            text = text.Replace("فاز# ", "فاز#");
            text = text.Replace("جاده ", "جاده#");
            text = text.Replace("بزرگراه ", "بزرگراه#");
            text = text.Replace("بزرگ راه ", "بزرگراه#");
            text = text.Replace("اتوبان ", "اتوبان#");
            text = text.Replace("خيابان اصلي ", "خ#");
            text = text.Replace("خيابان فرعي ", "خ#");
            text = text.Replace("خيابان ", "خ#");
            text = text.Replace(" خ ", " خ#");
            text = text.Replace("کوچه ", "ک#");
            text = text.Replace("کوي ", "ک#");
            text = text.Replace(" ک ", " ک#");
            text = text.Replace("بن بست", "بنبست#");
            text = text.Replace("بنبست# ", "بنبست#");

            text = text.Replace("چهار راه", "چهارراه");
            text = text.Replace("چهار راه", "چهارراه#");
            text = text.Replace("چهارراه# ", "چهارراه#");

            text = text.Replace("سراهي", "سراه");
            text = text.Replace("سه راهي", "سراه");
            text = text.Replace("سه راه", "سراه");
            text = text.Replace("سراه", "سراه#");
            text = text.Replace("سراه# ", "سراه#");

            text = text.Replace("دو راهي", "دوراه");
            text = text.Replace("دوراهي", "دوراه");
            text = text.Replace("دوراه", "دوراه#");
            text = text.Replace("دوراه# ", "دوراه#");


            text = text.Replace("تقاطع", "تقاطع#");
            text = text.Replace("تقاطع# ", "تقاطع#");

            text = text.Replace("بريدگي", "بريدگي#");
            text = text.Replace("بريدگي# ", "بريدگي#");

            text = text.Replace("پل ", "پل#");

            text = text.Replace("ميدان ", "م#");
            text = text.Replace(" م ", " م#");

            text = text.Replace("فلکه ي", "فلکه");
            text = text.Replace("فلکه", "فلکه#");
            text = text.Replace("فلکه# ", "فلکه#");

            text = text.Replace("بسمت", "بسمت#");
            text = text.Replace("به سمت", "بسمت#");
            text = text.Replace("بسمت# ", "بسمت#");

            text = text.Replace("سمت چپ", "سمتچپ");
            text = text.Replace("سمتچپ", "سمتچپ#");
            text = text.Replace("سمتچپ# ", "سمتچپ#");

            text = text.Replace("سمت راست ", "سمتراست");
            text = text.Replace("سمتراست", "سمتراست#");
            text = text.Replace("سمتراست# ", "سمتراست#");

            text = text.Replace("بعد از", "بعداز");
            text = text.Replace("بعداز", "بعداز#");
            text = text.Replace("بعداز# ", "بعداز#");

            text = text.Replace("نرسيده به ", "نرسيدهبه#");

            text = text.Replace("انتهاي ", "انتها#");

            text = text.Replace("روبروي", "روبرو");
            text = text.Replace("روبرو", "روبرو#");
            text = text.Replace("روبرو# ", "روبرو#");

            text = text.Replace("نبش ", "نبش#");
            text = text.Replace("جنب ", "جنب#");
            text = text.Replace("مقابل ", "مقابل#");

            text = text.Replace("تجاري اداري", "تجاري.اداري");
            text = text.Replace("تجاري واداري", "تجاري.اداري");
            text = text.Replace("تجاري و اداري", "تجاري.اداري");
            text = text.Replace("اداري تجاري", "تجاري.اداري");
            text = text.Replace("اداري وتجاري", "تجاري.اداري");
            text = text.Replace("اداري و تجاري", "تجاري.اداري");
            text = text.Replace(" تجاري ", " تجاري.اداري ");
            text = text.Replace(" اداري ", " تجاري.اداري ");

            text = text.Replace("مجتمع تجاري.اداري", "مجتمع.تجاري.اداري");
            text = text.Replace("ساختمان تجاري.اداري", "مجتمع.تجاري.اداري");
            text = text.Replace("پاساژ تجاري.اداري", "مجتمع.تجاري.اداري");
            text = text.Replace("مرکز تجاري.اداري", "مجتمع.تجاري.اداري");
            text = text.Replace("برج تجاري.اداري", "مجتمع.تجاري.اداري");
            text = text.Replace("مجموعه تجاري.اداري", "مجتمع.تجاري.اداري");

            text = text.Replace("مرکز خريد", "مجتمع.تجاري.اداري");
            text = text.Replace("مرکزخريد", "مجتمع.تجاري.اداري");
            text = text.Replace("پاساژ", "مجتمع.تجاري.اداري");

            //text = text.Replace("مجتمع.تجاري.اداري ", "مجتمع.تجاري.اداري");//space to nospace

            text = text.Replace("مجتمع ", "مجتمع#");
            text = text.Replace("ساختمان شماره ي", "س#");
            text = text.Replace("ساختمان شماره", "س#");
            text = text.Replace("ساختمان ", "س#");
            text = text.Replace(" س ", " س#");

            text = text.Replace("مرکز ", "مرکز#");
            text = text.Replace("برج ", "برج#");
            text = text.Replace("مجموعه ", "مجموعه#");
            text = text.Replace("بلوک ", "بلوک#");
            text = text.Replace("واحد شماره ي", "واحد#");
            text = text.Replace("واحد شماره", "واحد#");
            text = text.Replace("واحدشماره ي", "واحد#");
            text = text.Replace("واحدشماره", "واحد#");
            text = text.Replace("واحد# ", "واحد#");
            text = text.Replace("شماره", "ش#");
            text = text.Replace("شماره ي", "ش#");
            text = text.Replace("پلاک", "ش#");
            text = text.Replace(" پ ", " ش#");
            text = text.Replace(" ش ", " ش#");
            text = text.Replace("ش# ", " ش#");
            text = text.Replace("کدپستي", "کدپستي#");
            text = text.Replace("کد پستي", "کدپستي#");
            text = text.Replace("کدپستي# ", "کدپستي#");


            text = text.Trim();
            return text;
        }
        public static string ToZipedMobileNumber(this string text)
        {

            string result = text.Trim();
            result = result.Replace(".", string.Empty);
            result = result.Replace("-", string.Empty);
            result = result.Replace("(", string.Empty);
            result = result.Replace(")", string.Empty);
            result = result.Replace("+", string.Empty);

            if (result.Length < 11)
            {
                result = Convert.ToInt64(result).ToString("D11");
            }

            if (result.Substring(0, 4) == "0098")
            {
                result = result.Remove(0, 4);
            }
            if (result.Substring(0, 3) == "098")
            {
                result = result.Remove(0, 3);
            }
            if (result.Substring(0, 3) == "+98")
            {
                result = result.Remove(0, 3);
            }
            if (result.Substring(0, 2) == "98")
            {
                result = result.Remove(0, 2);
            }
            if (result.Substring(0, 1) == "0")
            {
                result = result.Remove(0, 1);
            }
            return "+98" + result;
        }
        public static List<string> ToZipedList(this string text)
        {
            try
            {
                text = text.ToZipedSpaces();
                string[] str = text.Split(' ');
                List<string> list = new List<string>();
                foreach (string s in str)
                {
                    list.Add(s.ToZipedText());
                }
                return list;
            }
            catch
            {
                List<string> x = new List<string>();
                return x;
            }

        }
        public static List<string> ToZipedListOfPairs(this string text)
        {
            try
            {
                text = text.ToZipedSpaces();
                string[] str = text.Split(' ');
                List<string> list = new List<string>();
                try
                {
                    int i = 0;
                    foreach (string s in str)
                    {
                        list.Add((str[i] + str[i + 1]).ToZipedText());
                        ++i;
                    }
                }
                catch
                {
                }
                return list;
            }
            catch
            {
                List<string> x = new List<string>();
                return x;
            }

        }
        public static List<string> ToZipedListOfTriplets(this string text)
        {
            try
            {
                text = text.ToZipedSpaces();
                string[] str = text.Split(' ');
                List<string> list = new List<string>();
                try
                {
                    int i = 0;
                    foreach (string s in str)
                    {
                        list.Add((str[i] + str[i + 1] + str[i + 2]).ToZipedText());
                        ++i;
                    }
                }
                catch
                {
                }
                return list;
            }
            catch
            {
                List<string> x = new List<string>();
                return x;
            }

        }
        public static List<string> ToZipedListOfQuadruplets(this string text)
        {
            try
            {
                text = text.ToZipedSpaces();
                string[] str = text.Split(' ');
                List<string> list = new List<string>();
                try
                {
                    int i = 0;
                    foreach (string s in str)
                    {
                        list.Add((str[i] + str[i + 1] + str[i + 2] + str[i + 3]).ToZipedText());
                        ++i;
                    }
                }
                catch
                {
                }
                return list;
            }
            catch
            {
                List<string> x = new List<string>();
                return x;
            }

        }
        public static List<string> ToZipedListOfQuintuplets(this string text)
        {
            try
            {
                text = text.ToZipedSpaces();
                string[] str = text.Split(' ');
                List<string> list = new List<string>();
                try
                {
                    int i = 0;
                    foreach (string s in str)
                    {
                        list.Add((str[i] + str[i + 1] + str[i + 2] + str[i + 3] + str[i + 4]).ToZipedText());
                        ++i;
                    }
                }
                catch
                {
                }
                return list;
            }
            catch
            {
                List<string> x = new List<string>();
                return x;
            }

        }
        public static string ToZipedField(this string fieldname)
        {
            string text = fieldname;
            text += ".Replace(\" \", \"\")";
            text += ".Replace(\"   \", \"\")";
            text += ".Replace(\"‌\", \"\")";
            text += ".Replace(\"ء\", \"\")";
            text += ".Replace(\"ـ\", \"\")";
            text += ".Replace(\"&#1740;\", \"ي\")";
            text += ".Replace(\"ی\", \"ي\")";
            text += ".Replace(\"ئ\", \"ي\")";
            text += ".Replace(\"ة\", \"\")";
            text += ".Replace(\"ۀ\", \"ت\")";
            text += ".Replace(\"ؤ\", \"و\")";
            text += ".Replace(\"وو\", \"و\")";
            text += ".Replace(\"ك\", \"ک\")";
            text += ".Replace(\"الله\", \"اله\")";
            text += ".Replace(\"ا...\", \"اله\")";
            text += ".Replace(\"آ\", \"ا\")";
            text += ".Replace(\"أ\", \"ا\")";
            text += ".Replace(\"إ\", \"ا\")";
            return text;
        }
        public static bool IsUnicode(this string text)
        {
            const int MaxAnsiCode = 255;
            bool IsUnicode = true;
            try
            {
                if (text != null)
                    if (text != string.Empty)
                        IsUnicode = text.ToCharArray().Any(c => c > MaxAnsiCode);
                    else
                        IsUnicode = true;
            }
            catch { }
            return IsUnicode;
        }
        public static string ToTwoDigit(this string text)
        {
            text = text.Trim();
            if (text.Length == 0) text = "00";
            if (text.Length == 1) text = "0" + text;
            if (text.Length > 2) text = text.Substring(0, 2);
            return text;
        }
        //public static string Keyword_GetText(string keyword, Guid workspace)
        //{
        //    string result = string.Empty;
        //    string keyword2 = keyword.ToZipedText();
        //    using (DAL.DataClassesDataContext Context = new DAL.DataClassesDataContext(ConnectionStrings.SosapovertyConnectionStrings))
        //    {
        //        try
        //        {
        //            DAL.Keyword OBJ = context.Keywords.Where(kw => kw.WorkspaceId.Equals(workspace)).Single(k => k.KeywordNameZiped.Equals(keyword2));
        //            result = OBJ.KeywordText;
        //        }
        //        catch
        //        {
        //            result = keyword;
        //        }
        //    }

        //    return result;
        //}
        //public static string Keywords_GetText(string keywords, char separator, Guid workspace)
        //{
        //    string result = string.Empty;
        //    try
        //    {
        //        List<string> keysList = keywords.Trim().Split(separator).ToList();
        //        string keysString = string.Empty;
        //        foreach (string k in keysList)
        //            keysString += Common.Keyword_GetText(k, workspace) + ".";
        //        IEnumerable<string> keysIEnumerable = keysString.Replace(" ", string.Empty).Split('.').ToList().Distinct();
        //        keysString = string.Empty;
        //        foreach (string k in keysIEnumerable)
        //        {
        //            if (k.Trim() != string.Empty)
        //                keysString += k.Trim() + ". ";
        //        }
        //        keysString = ("." + keysString).Trim().ToZipedText();
        //        result = keysString;
        //    }
        //    catch
        //    {
        //        result = keywords;
        //    }
        //    return result;
        //}
        #endregion
        public static string GetTrackingNo(string Table, string PreCode, int DepartmentId)
        {
            try
            {
                if (string.IsNullOrEmpty(PreCode))
                    PreCode = _db.DepartmentRepository.GetById(DepartmentId).DepartmentCode;
                string Code = "";
                switch (Table)
                {
                    case "Family":
                        Code = (_db.FamilyMemberRepository.Get(q => q.Person.DepartmentId == DepartmentId).Select(q => q.FamilyId).Distinct().Count() + 1).ToString("D4");
                        Code = DateTime.Now.ToTimeSolar().Substring(2, 2) + PreCode + Code;
                        break;
                    case "Person":
                        Code = (_db.FamilyMemberRepository.Get(q => q.Family.FamilyCode == PreCode).Count() + 1).ToString("D2");
                        Code = PreCode + Code;
                        break;
                    case "Personnel":
                        Code = (_db.PersonnelRepository.Get().Count() + 1).ToString("D5");
                        Code = DateTime.Now.ToTimeSolar().Substring(2, 2) + PreCode + Code;
                        break;
                    case "Department":
                        Code = (_db.DepartmentRepository.Get().Max(q => Convert.ToInt16(q.DepartmentCode)) + 1).ToString("D2");
                        break;
                    default:
                        break;
                }
                return Code;
            }
            catch
            {
                return null;
            }
        }

        public static void HttpLogInsert(EventLogViewModel model)
        {
            UnitOfWork db = new UnitOfWork();
            try
            {
                DAL.HttpLog objHttpLog = new DAL.HttpLog();
                objHttpLog.APPL_MD_PATH = HttpContext.Current.Request.ServerVariables["APPL_MD_PATH"];
                objHttpLog.APPL_PHYSICAL_PATH = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];
                objHttpLog.AUTH_PASSWORD = HttpContext.Current.Request.ServerVariables["AUTH_PASSWORD"];
                objHttpLog.AUTH_TYPE = HttpContext.Current.Request.ServerVariables["AUTH_TYPE"];
                objHttpLog.AUTH_USER = HttpContext.Current.Request.ServerVariables["AUTH_USER"];
                objHttpLog.CERT_COOKIE = HttpContext.Current.Request.ServerVariables["CERT_COOKIE"];
                objHttpLog.CERT_FLAGS = HttpContext.Current.Request.ServerVariables["CERT_FLAGS"];
                objHttpLog.CERT_ISSUER = HttpContext.Current.Request.ServerVariables["CERT_ISSUER"];
                objHttpLog.CERT_KEYSIZE = HttpContext.Current.Request.ServerVariables["CERT_KEYSIZE"];
                objHttpLog.CERT_SECRETKEYSIZE = HttpContext.Current.Request.ServerVariables["CERT_SECRETKEYSIZE"];
                objHttpLog.CERT_SERIALNUMBER = HttpContext.Current.Request.ServerVariables["CERT_SERIALNUMBER"];
                objHttpLog.CERT_SERVER_ISSUER = HttpContext.Current.Request.ServerVariables["CERT_SERVER_ISSUER"];
                objHttpLog.CERT_SERVER_SUBJECT = HttpContext.Current.Request.ServerVariables["CERT_SERVER_SUBJECT"];
                objHttpLog.CERT_SUBJECT = HttpContext.Current.Request.ServerVariables["CERT_SUBJECT"];
                objHttpLog.CONTENT_LENGTH = HttpContext.Current.Request.ServerVariables["CONTENT_LENGTH"];
                objHttpLog.CONTENT_TYPE = HttpContext.Current.Request.ServerVariables["CONTENT_TYPE"];
                objHttpLog.GATEWAY_INTERFACE = HttpContext.Current.Request.ServerVariables["GATEWAY_INTERFACE"];
                objHttpLog.HTTP_ACCEPT = HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT"];
                objHttpLog.HTTP_ACCEPT_LANGUAGE = HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
                objHttpLog.HTTP_COOKIE = HttpContext.Current.Request.ServerVariables["HTTP_COOKIE"];
                objHttpLog.HTTP_HeaderName = HttpContext.Current.Request.ServerVariables["HTTP_HeaderName"];
                objHttpLog.HTTP_REFERER = HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
                objHttpLog.HTTP_USER_AGENT = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
                objHttpLog.HTTPS = HttpContext.Current.Request.ServerVariables["HTTPS"];
                objHttpLog.HTTPS_KEYSIZE = HttpContext.Current.Request.ServerVariables["HTTPS_KEYSIZE"];
                objHttpLog.HTTPS_SECRETKEYSIZE = HttpContext.Current.Request.ServerVariables["HTTPS_SECRETKEYSIZE"];
                objHttpLog.HTTPS_SERVER_ISSUER = HttpContext.Current.Request.ServerVariables["HTTPS_SERVER_ISSUER"];
                objHttpLog.HTTPS_SERVER_SUBJECT = HttpContext.Current.Request.ServerVariables["HTTPS_SERVER_SUBJECT"];
                objHttpLog.INSTANCE_ID = HttpContext.Current.Request.ServerVariables["INSTANCE_ID"];
                objHttpLog.INSTANCE_META_PATH = HttpContext.Current.Request.ServerVariables["INSTANCE_META_PATH"];
                objHttpLog.LOCAL_ADDR = HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"];
                objHttpLog.LOGON_USER = HttpContext.Current.Request.ServerVariables["LOGON_USER"];
                objHttpLog.PATH_INFO = HttpContext.Current.Request.ServerVariables["PATH_INFO"];
                objHttpLog.PATH_TRANSLATED = HttpContext.Current.Request.ServerVariables["PATH_TRANSLATED"];
                objHttpLog.QUERY_STRING = HttpContext.Current.Request.ServerVariables["QUERY_STRING"];
                objHttpLog.REMOTE_ADDR = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                objHttpLog.REMOTE_HOST = HttpContext.Current.Request.ServerVariables["REMOTE_HOST"];
                objHttpLog.REMOTE_USER = HttpContext.Current.Request.ServerVariables["REMOTE_USER"];
                objHttpLog.REQUEST_METHOD = HttpContext.Current.Request.ServerVariables["REQUEST_METHOD"];
                objHttpLog.SCRIPT_NAME = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"];
                objHttpLog.SERVER_NAME = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
                objHttpLog.SERVER_PORT = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
                objHttpLog.SERVER_PORT_SECURE = HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
                objHttpLog.SERVER_PROTOCOL = HttpContext.Current.Request.ServerVariables["SERVER_PROTOCOL"];
                objHttpLog.SERVER_SOFTWARE = HttpContext.Current.Request.ServerVariables["SERVER_SOFTWARE"];
                objHttpLog.URL = HttpContext.Current.Request.ServerVariables["URL"];
                //objHttpLog.SubSystemId = (HttpContext.Current.Request["SubSystemId"] != null) ? Convert.ToInt32(HttpContext.Current.Request["SubSystemId"]) : (int?)null;
                objHttpLog.USER_ID = model.UserId;
                objHttpLog.Area = model.Area;
                objHttpLog.Action = model.Action;
                objHttpLog.Controller = model.Controller;
                objHttpLog.Input = model.Input;
                objHttpLog.Output = model.Output;
                objHttpLog.Type = (int)model.Type;
                objHttpLog.Description = model.Description;
                objHttpLog.HttpLogDateTime = DateTime.Now;
                objHttpLog.HttpLogDateTimeSolar = Common.ToTimeSolar(DateTime.Now);

                db.HttpLogRepository.Insert(objHttpLog);
                db.Save();

            }
            catch (Exception ex)
            {
                try
                {
                    DAL.HttpLog objHttpLog = new DAL.HttpLog();
                    objHttpLog.USER_ID = model.UserId;
                    objHttpLog.Area = model.Area;
                    objHttpLog.Action = model.Action;
                    objHttpLog.Controller = model.Controller;
                    objHttpLog.Input = model.Input;
                    objHttpLog.Output = ex.InnerException.StackTrace;
                    objHttpLog.Type = (int)EventLogType.Error;
                    objHttpLog.Description = ex.Message;
                    objHttpLog.HttpLogDateTime = DateTime.Now;
                    objHttpLog.HttpLogDateTimeSolar = Common.ToTimeSolar(DateTime.Now);

                    db.HttpLogRepository.Insert(objHttpLog);
                    db.Save();

                }
                catch (Exception ex2)
                {


                }
            }

        }


    }

    public static class CheckContentImage
    {
        public const int ImageMinimumBytes = 512;

        public static bool IsImage(this HttpPostedFileBase postedFile)
        {
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            if (postedFile.ContentType.ToLower() != "image/jpg" &&
                        postedFile.ContentType.ToLower() != "image/jpeg" &&
                        postedFile.ContentType.ToLower() != "image/pjpeg" &&
                        postedFile.ContentType.ToLower() != "image/gif" &&
                        postedFile.ContentType.ToLower() != "image/x-png" &&
                        postedFile.ContentType.ToLower() != "image/png")
            {
                return false;
            }

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            if (Path.GetExtension(postedFile.FileName).ToLower() != ".jpg"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".png"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".gif"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".jpeg")
            {
                return false;
            }

            //-------------------------------------------
            //  Attempt to read the file and check the first bytes
            //-------------------------------------------
            try
            {
                if (!postedFile.InputStream.CanRead)
                {
                    return false;
                }

                if (postedFile.ContentLength < ImageMinimumBytes)
                {
                    return false;
                }

                byte[] buffer = new byte[512];
                postedFile.InputStream.Read(buffer, 0, 512);
                string content = System.Text.Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            //-------------------------------------------
            //  Try to instantiate new Bitmap, if .NET will throw exception
            //  we can assume that it's not a valid image
            //-------------------------------------------

            try
            {
                using (var bitmap = new System.Drawing.Bitmap(postedFile.InputStream))
                {
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

    }

}
